using HalconCalibration.Common;
using HalconDotNet;

namespace HalconCalibration.Views.HalconProjects;

public partial class TemplateMatchingForm : Form
{
    private readonly HWindow? _window;

    // 本窗体内显示用的窗口：左边显示原图，右边显示模板图
    private readonly HWindow? _originWindow;
    private readonly HWindow? _templateWindow;

    // 在本窗体中交互编辑的矩形 ROI（非阻塞）
    private HDrawingObject? _roiDrawingObject;
    private bool _isDrawingRoi;

    // 模板图像
    private HImage? _templateImage;
    private HTuple? _modelId;

    // 匹配用原图（可以来自相机，也可以从文件导入）
    private HImage? _matchImage;
    private bool _matchImageFromFile;

    // 用于在匹配时画出大致模板区域
    private double _templateWidth;
    private double _templateHeight;

    // 最小匹配分数
    private double _minScore = 0.6;

    public TemplateMatchingForm(HWindow? window)
    {
        InitializeComponent();
        _window = window;

        _originWindow = hSmartWindowControlOriginal.HalconWindow;
        _templateWindow = hSmartWindowControlTemplate.HalconWindow;

        // 默认使用当前相机图像作为匹配原图
        if (CameraCtrl.Instance.Image != null)
        {
            _matchImage = CameraCtrl.Instance.Image;
            _matchImageFromFile = false;

            if (_originWindow != null)
            {
                DispImageWithZoom(_originWindow, _matchImage, 1.0);
            }
        }

        // 窗体关闭时释放模板与模型（相机图像不在此释放）
        FormClosed += (_, _) =>
        {
            _templateImage?.Dispose();
            if (_matchImageFromFile)
            {
                _matchImage?.Dispose();
                _matchImage = null;
            }
            ClearShapeModel();
        };
    }

    /// <summary>
    /// 将整幅图像完整铺满到窗口坐标系（不裁剪，只根据图像大小设置 part）
    /// </summary>
    private void DispImageWithZoom(HWindow? window, HImage image, double zoomFactor = 1.5)
    {
        if (window == null) return;

        image.GetImageSize(out HTuple w, out HTuple h);

        window.ClearWindow();
        // 按整幅图像范围设置坐标系，让图像“全铺”在窗口坐标中
        HOperatorSet.SetPart(window, 0, 0, h - 1, w - 1);
        image.DispObj(window);
    }

    // 导入模板图像
    private void importTemplateBtn_Click(object sender, EventArgs e)
    {
        try
        {
            using var dialog = new OpenFileDialog
            {
                Filter = @"图像文件|*.bmp;*.png;*.jpg;*.jpeg;*.tif;*.tiff|所有文件|*.*"
            };

            if (dialog.ShowDialog() != DialogResult.OK) return;

            // 释放旧模板
            _templateImage?.Dispose();
            ClearShapeModel();

            _templateImage = new HImage(dialog.FileName);

            // 记录模板大小并自适应显示
            HOperatorSet.GetImageSize(_templateImage, out HTuple width, out HTuple height);
            _templateWidth = width.D;
            _templateHeight = height.D;

            if (_templateWindow != null)
            {
                // 模板图默认放大一些显示
                DispImageWithZoom(_templateWindow, _templateImage, 1.5);
            }

            // 创建形状模型
            HOperatorSet.CreateShapeModel(
                _templateImage,
                "auto",
                0,
                0,
                "auto",
                "auto",
                "use_polarity",
                "auto",
                "auto",
                out HTuple modelId);
            _modelId = modelId;

            Logger.Instance.AddLog(@"模板导入并创建模型成功");
        }
        catch (Exception ex)
        {
            Logger.Instance.AddLog($@"模板导入失败：{ex.Message}", Enums.LogLevel.Error);
            MessageBox.Show($@"模板导入失败：{ex.Message}");
        }
    }

    // 导入匹配原图像（在左侧窗口显示，并作为剪辑/匹配的源图）
    private void importMatchImageBtn_Click(object sender, EventArgs e)
    {
        try
        {
            using var dialog = new OpenFileDialog
            {
                Filter = @"图像文件|*.bmp;*.png;*.jpg;*.jpeg;*.tif;*.tiff|所有文件|*.*"
            };

            if (dialog.ShowDialog() != DialogResult.OK) return;

            // 如果之前就是从文件导入的，先释放旧图
            if (_matchImageFromFile)
            {
                _matchImage?.Dispose();
            }

            _matchImage = new HImage(dialog.FileName);
            _matchImageFromFile = true;

            if (_originWindow != null)
            {
                DispImageWithZoom(_originWindow, _matchImage, 1.0);
            }

            Logger.Instance.AddLog(@"匹配原图像导入成功");
        }
        catch (Exception ex)
        {
            Logger.Instance.AddLog($@"匹配原图像导入失败：{ex.Message}", Enums.LogLevel.Error);
            MessageBox.Show($@"匹配原图像导入失败：{ex.Message}");
        }
    }

    private void clipTemplateBtn_Click(object sender, EventArgs e)
    {
        try
        {
            // 第一次点击：进入矩形编辑模式（非阻塞），再次点击：完成剪辑
            if (!_isDrawingRoi)
            {
                var srcImage = _matchImage ?? CameraCtrl.Instance.Image;
                if (srcImage == null)
                {
                    MessageBox.Show(@"图像未加载，请先拍照或导入匹配原图像");
                    return;
                }

                if (_originWindow == null)
                {
                    MessageBox.Show(@"模板匹配窗体的 Halcon 窗口未初始化");
                    return;
                }

                // 左侧窗口显示当前匹配原图并全铺
                DispImageWithZoom(_originWindow, srcImage, 1.0);

                // 如果已有旧的绘制对象，先移除
                if (_roiDrawingObject != null)
                {
                    try
                    {
                        HOperatorSet.DetachDrawingObjectFromWindow(_originWindow, _roiDrawingObject);
                    }
                    catch
                    {
                        // 忽略
                    }
                    _roiDrawingObject.Dispose();
                    _roiDrawingObject = null;
                }

                // 在图像中间创建一个可交互的矩形，用户可拖拽、缩放
                srcImage.GetImageSize(out HTuple imgW, out HTuple imgH);
                double rCenter = imgH.D / 2.0;
                double cCenter = imgW.D / 2.0;
                double halfH = imgH.D / 6.0;
                double halfW = imgW.D / 6.0;

                var rectObj = new HDrawingObject();
                rectObj.CreateDrawingObjectRectangle1(
                    rCenter - halfH,
                    cCenter - halfW,
                    rCenter + halfH,
                    cCenter + halfW);

                HOperatorSet.AttachDrawingObjectToWindow(_originWindow, rectObj);
                _roiDrawingObject = rectObj;

                _isDrawingRoi = true;
                if (sender is Button btn1) btn1.Text = @"完成剪辑";
                cancelClipBtn.Enabled = true;
            }
            else
            {
                if (_roiDrawingObject == null)
                {
                    _isDrawingRoi = false;
                    if (sender is Button btnReset) btnReset.Text = @"剪辑模板";
                    MessageBox.Show(@"当前没有有效矩形，请重新剪辑。");
                    return;
                }

                var srcImage2 = _matchImage ?? CameraCtrl.Instance.Image;
                if (srcImage2 == null)
                {
                    MessageBox.Show(@"图像未加载，请先拍照或导入匹配原图像");
                    return;
                }

                // 读取交互矩形的坐标（rectangle1 的参数名是 row1/column1/row2/column2）
                HTuple row1 = _roiDrawingObject.GetDrawingObjectParams("row1");
                HTuple col1 = _roiDrawingObject.GetDrawingObjectParams("column1");
                HTuple row2 = _roiDrawingObject.GetDrawingObjectParams("row2");
                HTuple col2 = _roiDrawingObject.GetDrawingObjectParams("column2");

                if (row2.D <= row1.D || col2.D <= col1.D)
                {
                    MessageBox.Show(@"无效的矩形区域，请重新调整后再完成剪辑");
                    return;
                }

                HOperatorSet.GenRectangle1(out HObject rect, row1, col1, row2, col2);
                HOperatorSet.ReduceDomain(srcImage2, rect, out HObject reducedImage);

                // 释放旧模板和模型
                _templateImage?.Dispose();
                ClearShapeModel();

                _templateImage = new HImage(reducedImage);

                // 记录模板大小
                _templateWidth = col2.D - col1.D;
                _templateHeight = row2.D - row1.D;

                // 在右侧窗口显示剪辑后的模板并自适应
                if (_templateWindow != null)
                {
                    DispImageWithZoom(_templateWindow, _templateImage, 1.5);
                }

                // 创建形状模型
                HOperatorSet.CreateShapeModel(
                    _templateImage,
                    "auto",
                    0,
                    0,
                    "auto",
                    "auto",
                    "use_polarity",
                    "auto",
                    "auto",
                    out HTuple modelId);
                _modelId = modelId;

                rect.Dispose();
                reducedImage.Dispose();

                // 结束矩形编辑模式并移除绘制对象
                if (_originWindow != null)
                {
                    try
                    {
                        HOperatorSet.DetachDrawingObjectFromWindow(_originWindow, _roiDrawingObject);
                    }
                    catch
                    {
                        // 忽略
                    }
                }
                _roiDrawingObject.Dispose();
                _roiDrawingObject = null;
                _isDrawingRoi = false;
                if (sender is Button btn2) btn2.Text = @"剪辑模板";
                cancelClipBtn.Enabled = false;

                Logger.Instance.AddLog(@"模板剪辑并创建模型成功");
            }
        }
        catch (Exception ex)
        {
            Logger.Instance.AddLog($@"模板剪辑失败：{ex.Message}", Enums.LogLevel.Error);
            MessageBox.Show($@"模板剪辑失败：{ex.Message}");
        }
    }

    // 取消当前剪辑（退出矩形编辑模式，不生成模板）
    private void cancelClipBtn_Click(object sender, EventArgs e)
    {
        try
        {
            if (!_isDrawingRoi)
            {
                return;
            }

            if (_originWindow != null && _roiDrawingObject != null)
            {
                try
                {
                    HOperatorSet.DetachDrawingObjectFromWindow(_originWindow, _roiDrawingObject);
                }
                catch
                {
                    // 忽略
                }
            }

            _roiDrawingObject?.Dispose();
            _roiDrawingObject = null;
            _isDrawingRoi = false;
            clipTemplateBtn.Text = @"剪辑模板";
            cancelClipBtn.Enabled = false;
        }
        catch (Exception ex)
        {
            Logger.Instance.AddLog($@"取消剪辑失败：{ex.Message}", Enums.LogLevel.Error);
        }
    }

    private void matchBtn_Click(object sender, EventArgs e)
    {
        try
        {
            var srcImage = _matchImage ?? CameraCtrl.Instance.Image;
            if (srcImage == null)
            {
                MessageBox.Show(@"图像未加载，请先拍照或导入匹配原图像");
                return;
            }

            if (_templateImage == null || _modelId == null || _modelId.Length == 0)
            {
                MessageBox.Show(@"请先导入或剪辑模板");
                return;
            }

            // 在模板匹配页左侧窗口显示当前匹配原图（只在本页面显示结果，不改主页面）
            if (_originWindow != null)
            {
                DispImageWithZoom(_originWindow, srcImage, 1.0);
            }

            // 执行形状匹配
            HOperatorSet.FindShapeModel(
                srcImage,
                _modelId,
                0,
                0,
                _minScore,
                1,
                0.5,
                "least_squares",
                0,
                0.9,
                out HTuple rows,
                out HTuple cols,
                out HTuple angles,
                out HTuple scores);

            if (scores.Length <= 0)
            {
                Logger.Instance.AddLog(@"未在原图中匹配到模板", Enums.LogLevel.Warn);
                MessageBox.Show(@"未在原图中匹配到模板");
                return;
            }

            double row = rows[0].D;
            double col = cols[0].D;
            double score = scores[0].D;

            // 以模板尺寸在匹配中心画一个矩形框作为示意
            double halfH = _templateHeight / 2.0;
            double halfW = _templateWidth / 2.0;

            HOperatorSet.GenRectangle1(
                out HObject matchRect,
                row - halfH,
                col - halfW,
                row + halfH,
                col + halfW);

            // 只在模板匹配窗体左侧窗口上显示匹配结果
            if (_originWindow != null)
            {
                HOperatorSet.SetColor(_originWindow, "red");
                HOperatorSet.SetDraw(_originWindow, "margin");
                HOperatorSet.SetLineWidth(_originWindow, 3);
                HOperatorSet.DispObj(matchRect, _originWindow);
            }
            matchRect.Dispose();

            Logger.Instance.AddLog($@"模板匹配成功，行：{row:F2}，列：{col:F2}，得分：{score:F3}");
            MessageBox.Show($@"模板匹配成功！得分：{score:F3}");
        }
        catch (Exception ex)
        {
            Logger.Instance.AddLog($@"模板匹配失败：{ex.Message}", Enums.LogLevel.Error);
            MessageBox.Show($@"模板匹配失败：{ex.Message}");
        }
    }

    private void minScoreTextBox_TextChanged(object sender, EventArgs e)
    {
        if (double.TryParse(minScoreTextBox.Text, out double v))
        {
            if (v < 0) v = 0;
            if (v > 1) v = 1;
            _minScore = v;
        }
    }

    private void ClearShapeModel()
    {
        if (_modelId is { Length: > 0 })
        {
            try
            {
                HOperatorSet.ClearShapeModel(_modelId);
            }
            catch
            {
                // 忽略清理异常
            }
            _modelId = null;
        }
    }
}