using System.ComponentModel;

namespace HalconCalibration.Views.HalconProjects;

partial class QRCodeForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private IContainer? components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        addCameraImageBtn = new Button();
        importImageBtn = new Button();
        recognizeBtn = new Button();
        hSmartWindowControlQr = new HalconDotNet.HSmartWindowControl();
        SuspendLayout();
        // 
        // addCameraImageBtn
        // 
        addCameraImageBtn.Location = new Point(12, 415);
        addCameraImageBtn.Name = "addCameraImageBtn";
        addCameraImageBtn.Size = new Size(150, 45);
        addCameraImageBtn.TabIndex = 0;
        addCameraImageBtn.Text = "使用相机图像";
        addCameraImageBtn.UseVisualStyleBackColor = true;
        addCameraImageBtn.Click += addCameraImageBtn_Click;
        // 
        // importImageBtn
        // 
        importImageBtn.Location = new Point(180, 415);
        importImageBtn.Name = "importImageBtn";
        importImageBtn.Size = new Size(150, 45);
        importImageBtn.TabIndex = 1;
        importImageBtn.Text = "导入图像";
        importImageBtn.UseVisualStyleBackColor = true;
        importImageBtn.Click += importImageBtn_Click;
        // 
        // recognizeBtn
        // 
        recognizeBtn.Location = new Point(12, 480);
        recognizeBtn.Name = "recognizeBtn";
        recognizeBtn.Size = new Size(318, 45);
        recognizeBtn.TabIndex = 2;
        recognizeBtn.Text = "识别二维码";
        recognizeBtn.UseVisualStyleBackColor = true;
        recognizeBtn.Click += recognizeBtn_Click;
        // 
        // hSmartWindowControlQr
        // 
        hSmartWindowControlQr.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        hSmartWindowControlQr.AutoValidate = AutoValidate.EnableAllowFocusChange;
        hSmartWindowControlQr.HDoubleClickToFitContent = true;
        hSmartWindowControlQr.HDrawingObjectsModifier = HalconDotNet.HSmartWindowControl.DrawingObjectsModifier.None;
        hSmartWindowControlQr.HImagePart = new Rectangle(0, 0, 512, 384);
        hSmartWindowControlQr.HKeepAspectRatio = true;
        hSmartWindowControlQr.HMoveContent = false;
        hSmartWindowControlQr.HZoomContent = HalconDotNet.HSmartWindowControl.ZoomContent.WheelForwardZoomsIn;
        hSmartWindowControlQr.Location = new Point(12, 12);
        hSmartWindowControlQr.Margin = new Padding(0);
        hSmartWindowControlQr.Name = "hSmartWindowControlQr";
        hSmartWindowControlQr.Size = new Size(520, 380);
        hSmartWindowControlQr.TabIndex = 3;
        hSmartWindowControlQr.WindowSize = new Size(520, 380);
        // 
        // QRCodeForm
        // 
        AutoScaleDimensions = new SizeF(9F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(544, 541);
        Controls.Add(hSmartWindowControlQr);
        Controls.Add(recognizeBtn);
        Controls.Add(importImageBtn);
        Controls.Add(addCameraImageBtn);
        Name = "QRCodeForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "二维码识别";
        ResumeLayout(false);
    }

    #endregion

    private System.Windows.Forms.Button addCameraImageBtn;
    private System.Windows.Forms.Button importImageBtn;
    private System.Windows.Forms.Button recognizeBtn;
    private HalconDotNet.HSmartWindowControl hSmartWindowControlQr;
}

