using HalconCalibration.Common;
using HalconDotNet;

namespace HalconCalibration.Views.HalconProjects;

public partial class QRCodeForm : Form
{
    private readonly HWindow? _mainWindow;
    private readonly HWindow? _qrWindow;

    // 当前用于识别的图像，可以来自相机，也可以从文件导入
    private HImage? _qrImage;
    private bool _qrImageFromFile;

    public QRCodeForm(HWindow? window)
    {
        InitializeComponent();

        _mainWindow = window;
        _qrWindow = hSmartWindowControlQr.HalconWindow;

        // 默认使用当前相机图像作为识别图像
        if (CameraCtrl.Instance.Image != null)
        {
            _qrImage = CameraCtrl.Instance.Image;
            _qrImageFromFile = false;

            if (_qrWindow != null)
            {
                DispImageWithZoom(_qrWindow, _qrImage, 1.0);
            }
        }

        FormClosed += (_, _) =>
        {
            if (_qrImageFromFile)
            {
                _qrImage?.Dispose();
                _qrImage = null;
            }
        };
    }

    private void DispImageWithZoom(HWindow? window, HImage image, double zoomFactor = 1.0)
    {
        if (window == null) return;

        image.GetImageSize(out HTuple w, out HTuple h);

        window.ClearWindow();
        HOperatorSet.SetPart(window, 0, 0, h - 1, w - 1);
        image.DispObj(window);
    }

    // 使用当前相机图像
    private void addCameraImageBtn_Click(object? sender, EventArgs e)
    {
        try
        {
            if (CameraCtrl.Instance.Image == null)
            {
                MessageBox.Show(@"图像未加载，请先拍照");
                return;
            }

            if (_qrImageFromFile)
            {
                _qrImage?.Dispose();
            }

            _qrImage = CameraCtrl.Instance.Image;
            _qrImageFromFile = false;

            if (_qrWindow != null)
            {
                DispImageWithZoom(_qrWindow, _qrImage, 1.0);
            }
        }
        catch (Exception ex)
        {
            Logger.Instance.AddLog($@"加载相机图像失败：{ex.Message}", Enums.LogLevel.Error);
            MessageBox.Show($@"加载相机图像失败：{ex.Message}");
        }
    }

    // 从文件导入图像
    private void importImageBtn_Click(object? sender, EventArgs e)
    {
        try
        {
            using var dialog = new OpenFileDialog
            {
                Filter = @"图像文件|*.bmp;*.png;*.jpg;*.jpeg;*.tif;*.tiff|所有文件|*.*"
            };

            if (dialog.ShowDialog() != DialogResult.OK) return;

            if (_qrImageFromFile)
            {
                _qrImage?.Dispose();
            }

            _qrImage = new HImage(dialog.FileName);
            _qrImageFromFile = true;

            if (_qrWindow != null)
            {
                DispImageWithZoom(_qrWindow, _qrImage, 1.0);
            }

            Logger.Instance.AddLog(@"二维码识别图像导入成功");
        }
        catch (Exception ex)
        {
            Logger.Instance.AddLog($@"二维码识别图像导入失败：{ex.Message}", Enums.LogLevel.Error);
            MessageBox.Show($@"二维码识别图像导入失败：{ex.Message}");
        }
    }

    // 识别二维码
    private void recognizeBtn_Click(object? sender, EventArgs e)
    {
        try
        {
            var srcImage = _qrImage ?? CameraCtrl.Instance.Image;
            if (srcImage == null)
            {
                MessageBox.Show(@"图像未加载，请先拍照或导入图像");
                return;
            }

            // 暂存原始相机图像，将当前图像挂到 CameraCtrl，复用现有识别逻辑
            var oldImage = CameraCtrl.Instance.Image;
            CameraCtrl.Instance.Image = srcImage;
            try
            {
                if (QRCodeCtrl.Instance.HandleQRCode(_qrWindow, out var msg))
                {
                    Logger.Instance.AddLog($@"二维码识别成功：{QRCodeCtrl.Instance.QRCodeString}");
                    if (QRCodeCtrl.Instance.Row != null && QRCodeCtrl.Instance.Column != null)
                    {
                        Logger.Instance.AddLog(
                            $@"二维码位置，行：{QRCodeCtrl.Instance.Row}，列：{QRCodeCtrl.Instance.Column}");
                    }
                }
                else
                {
                    Logger.Instance.AddLog($@"二维码识别失败：{msg}", Enums.LogLevel.Warn);
                    MessageBox.Show($@"二维码识别失败：{msg}");
                }
            }
            finally
            {
                CameraCtrl.Instance.Image = oldImage;
            }
        }
        catch (Exception ex)
        {
            Logger.Instance.AddLog($@"二维码识别操作失败：{ex.Message}", Enums.LogLevel.Error);
            MessageBox.Show($@"二维码识别操作失败：{ex.Message}");
        }
    }
}

