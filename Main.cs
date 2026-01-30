using HalconCalibration.Common;
using HalconCalibration.Enums;
using HalconCalibration.Views;
using HalconCalibration.Views.HalconProjects;
using HalconDotNet;

namespace HalconCalibration;

public partial class Main : Form
{
    private HWindow? _window;
    private LogForm? _logForm;
    private UserControl _currentProject;

    public Main()
    {
        InitializeComponent();
        _window = hSmartWindowControl1.HalconWindow;
    }

    private void Main_Load(object sender, EventArgs e)
    {
        _window?.SetColor("green");
        CalibrationShow();
        IniControl.Instance.Initialize();
    }

    // 需要手动绑定事件，使用【设计器】绑定不生效
    private void hSmartWindowControl1_Load(object sender, EventArgs e)
    {
        hSmartWindowControl1.MouseWheel += hSmartWindowControl1_HMouseWheel;
    }

    // hwindow鼠标滚动事件
    private void hSmartWindowControl1_HMouseWheel(object? sender, MouseEventArgs e)
    {
        Point pt = hSmartWindowControl1.Location;

        MouseEventArgs newe = new MouseEventArgs(e.Button, e.Clicks, (int)e.X - pt.X, (int)e.Y - pt.Y, e.Delta);
        hSmartWindowControl1.HSmartWindowControl_MouseWheel(sender, newe);
    }

    // 相机连接
    private void connectCamera_Click(object sender, EventArgs e)
    {
        // 连接按钮关闭
        connectCamera.Enabled = false;
        if (CameraCtrl.Instance.Connect(out var msg))
        {
            Logger.Instance.AddLog("相机连接成功");

            // 断开按钮 开启
            disconnectCamera.Enabled = true;
            // 指示灯
            indicatorLight1.IsOn = !indicatorLight1.IsOn;

            CameraCtrl.Instance.CapturedCompleted += OnCaptured;
        }
        else
        {
            connectCamera.Enabled = true;
            Logger.Instance.AddLog($"相机连接失败：{msg}", LogLevel.Error);
            MessageBox.Show(@$"相机连接失败：{msg}");
        }
    }


    // 拍照
    private void takeGraphic_Click(object sender, EventArgs e)
    {
        try
        {
            CameraCtrl.Instance.Capture();
        }
        catch (Exception exception)
        {
            Logger.Instance.AddLog($"拍照失败：{exception.Message}", LogLevel.Error);
        }
    }

    // 拍照后
    private void OnCaptured(object? sender, EventArgs e)
    {
        if (CameraCtrl.Instance.Image != null)
            CameraCtrl.Instance.Image.DispObj(_window);
    }

    // 打开日志窗口
    private void displayLogs_Click(object sender, EventArgs e)
    {
        if (_logForm == null || _logForm.IsDisposed)
        {
            _logForm = new LogForm();
            _logForm.Show();
        }
        else
        {
            _logForm.Close();
        }
    }

    // 连接PLC
    private async void connectPlc_Click(object sender, EventArgs e)
    {
        try
        {
            await PlcControl.Instance.Connect();

            if (PlcControl.Instance.IsConnected)
            {
                indicatorLight2.IsOn = !indicatorLight2.IsOn;
                connectPlc.Enabled = false;
                disconnectPlc.Enabled = true;
                Logger.Instance.AddLog("PLC连接成功");
            }
        }
        catch (Exception exception)
        {
            Logger.Instance.AddLog($"PLC连接失败：{exception.Message}", LogLevel.Error);
            MessageBox.Show(@$"PLC连接失败：{exception.Message}");
        }
    }

    private void CalibrationShow()
    {
        if (_window == null) return;
        var cali = new Configuration(_window);
        cali.Parent = panel2;
        cali.Dock = DockStyle.Fill;
    }

    // 断开相机
    private void disconnectCamera_Click(object sender, EventArgs e)
    {
        var msg = CameraCtrl.Instance.DisConnect();
        if (msg != null)
        {
            Logger.Instance.AddLog(msg);
            MessageBox.Show(msg);
            return;
        }

        connectCamera.Enabled = true;
        disconnectCamera.Enabled = false;
        indicatorLight1.IsOn = !indicatorLight1.IsOn;

        CameraCtrl.Instance.CapturedCompleted -= OnCaptured;
        Logger.Instance.AddLog("相机断开");
    }

    // 断开相机
    private void disconnectPlc_Click(object sender, EventArgs e)
    {
        PlcControl.Instance.Disconnect();

        disconnectPlc.Enabled = false;
        connectPlc.Enabled = true;
        indicatorLight2.IsOn = !indicatorLight2.IsOn;
        Logger.Instance.AddLog("PLC断开");
    }

    // 程序退出
    private void Main_FormClosing(object sender, FormClosingEventArgs e)
    {
        CameraCtrl.Instance.DisConnect();
        PlcControl.Instance.Disconnect();
    }

    // 打开相机配置窗口
    private void cameraConfig_Click(object sender, EventArgs e)
    {
        var cc = new CameraConfig();
        cc.Show();
    }

    // 打开PLC配置窗口
    private void PlcConfig_Click(object sender, EventArgs e)
    {
        var pc = new PlcConfig();
        pc.Show();
    }

    // 清除图像
    private void clearImage_Click(object sender, EventArgs e)
    {
        _window?.ClearWindow();
    }
}