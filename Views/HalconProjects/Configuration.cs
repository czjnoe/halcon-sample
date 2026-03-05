using System;
using System.ComponentModel;
using System.Globalization;
using HalconCalibration.Common;
using HalconCalibration.Enums;
using HalconDotNet;
using S7.Net;

namespace HalconCalibration.Views.HalconProjects;

[ToolboxItem(false)]
public partial class Configuration : UserControl {
    private HWindow? _window;

    private Threshold? _threshold;
    private TemplateMatchingForm? _templateMatchingForm;
    private QRCodeForm? _qrCodeForm;

    // 像素坐标的元组。 
    private HTuple _pixelRow = new();
    private HTuple _pixelColumn = new();

    // 机械坐标数组；按照九点标定顺序一次添加
    private HTuple _realRow = new();
    private HTuple _realColumn = new();


    public Configuration(HWindow hWindow) {
        InitializeComponent();

        _window = hWindow;
        Disposed += FormClosing;
    }

    // 恢复控件到UI线程执行
    private void RunOnUIThread(Action action) {
        if (InvokeRequired) {
            Invoke(action);
        }
        else {
            action();
        }
    }

    // 拍照成功后执行
    private async void OnCaptured(object? sender, EventArgs e) {
        try {
            if (CameraCtrl.Instance.Image == null) throw new Exception("图像未加载");

            // 执行halcon,获取 像素坐标
            if (!ThresholdCtrl.Instance.HandleThreshold(_window, out var msg)) {
                RunOnUIThread(() =>
                    Logger.Instance.AddLog($"阈值分割失败请重试：{msg}", LogLevel.Error)
                );
                return;
            }


            // 保存像素坐标
            _pixelRow.Append(ThresholdCtrl.Instance.Row);
            _pixelColumn.Append(ThresholdCtrl.Instance.Column);
            // 保存物理坐标
            _realRow.Append(PlcControl.Instance.RealX);
            _realColumn.Append(PlcControl.Instance.RealY);

            RunOnUIThread(() =>
                Logger.Instance.AddLog($"像素坐标，x：{ThresholdCtrl.Instance.Row}，y：{ThresholdCtrl.Instance.Column}"));
            RunOnUIThread(() =>
                Logger.Instance.AddLog($"机械坐标，x：{PlcControl.Instance.RealX}，y：{PlcControl.Instance.RealY}"));

            try {
                if (PlcControl.Instance.IsConnected)
                    // 写入九点矫正编号给plc,表示本次点对添加完成
                    await PlcControl.Instance.Write(PlcDataAddress.NineCaliNumCheck.GetAddress(),
                        PlcControl.Instance.NineCaliNum);
            }
            catch (Exception exception) {
                RunOnUIThread(() => Logger.Instance.AddLog($"写入PLC失败：{exception.Message}", LogLevel.Error));
            }
        }
        catch (Exception exception) {
            RunOnUIThread(() => Logger.Instance.AddLog($"九点标定操作失败：{exception.Message}", LogLevel.Error));
            MessageBox.Show($@"九点标定操作失败：{exception.Message}");
        }
    }

    // 打开阈值分割窗口
    private void thresholdBtn_Click(object sender, EventArgs e) {
        if (_threshold == null || _threshold.IsDisposed) {
            _threshold = new Threshold(_window);
            _threshold.Show();
        }
        else {
            _threshold.Close();
        }
    }

    // 打开模板匹配窗口
    private void templateMatchBtn_Click(object sender, EventArgs e) {
        if (_templateMatchingForm == null || _templateMatchingForm.IsDisposed) {
            _templateMatchingForm = new TemplateMatchingForm(_window);
            _templateMatchingForm.Show();
        }
        else {
            _templateMatchingForm.Close();
        }
    }

    // 二维码识别按钮点击事件
    private void qrCodeBtn_Click(object sender, EventArgs e) {
        // 打开/关闭二维码识别窗口（与模板匹配窗口风格一致）
        if (_qrCodeForm == null || _qrCodeForm.IsDisposed) {
            _qrCodeForm = new QRCodeForm(_window);
            _qrCodeForm.Show();
        }
        else {
            _qrCodeForm.Close();
        }
    }

    // 关闭窗口就释放阈值分割窗口
    private void FormClosing(object? sender, EventArgs e) {
        _threshold?.Dispose();
        _templateMatchingForm?.Dispose();
        _qrCodeForm?.Dispose();
    }
}