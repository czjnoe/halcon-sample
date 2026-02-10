namespace HalconCalibration.Views.HalconProjects;

partial class TemplateMatchingForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        importTemplateBtn = new Button();
        clipTemplateBtn = new Button();
        cancelClipBtn = new Button();
        matchBtn = new Button();
        importMatchImageBtn = new Button();
        label1 = new Label();
        minScoreTextBox = new TextBox();
        hSmartWindowControlOriginal = new HalconDotNet.HSmartWindowControl();
        hSmartWindowControlTemplate = new HalconDotNet.HSmartWindowControl();
        SuspendLayout();
        // 
        // importTemplateBtn
        // 
        importTemplateBtn.Location = new Point(220, 415);
        importTemplateBtn.Name = "importTemplateBtn";
        importTemplateBtn.Size = new Size(140, 45);
        importTemplateBtn.TabIndex = 0;
        importTemplateBtn.Text = "导入模板";
        importTemplateBtn.UseVisualStyleBackColor = true;
        importTemplateBtn.Click += importTemplateBtn_Click;
        // 
        // clipTemplateBtn
        // 
        clipTemplateBtn.Location = new Point(392, 415);
        clipTemplateBtn.Name = "clipTemplateBtn";
        clipTemplateBtn.Size = new Size(140, 45);
        clipTemplateBtn.TabIndex = 1;
        clipTemplateBtn.Text = "剪辑模板";
        clipTemplateBtn.UseVisualStyleBackColor = true;
        clipTemplateBtn.Click += clipTemplateBtn_Click;
        // 
        // cancelClipBtn
        // 
        cancelClipBtn.Location = new Point(569, 415);
        cancelClipBtn.Name = "cancelClipBtn";
        cancelClipBtn.Size = new Size(119, 45);
        cancelClipBtn.TabIndex = 7;
        cancelClipBtn.Text = "取消剪辑";
        cancelClipBtn.UseVisualStyleBackColor = true;
        cancelClipBtn.Click += cancelClipBtn_Click;
        // 
        // matchBtn
        // 
        matchBtn.Location = new Point(12, 485);
        matchBtn.Name = "matchBtn";
        matchBtn.Size = new Size(190, 45);
        matchBtn.TabIndex = 2;
        matchBtn.Text = "匹配";
        matchBtn.UseVisualStyleBackColor = true;
        matchBtn.Click += matchBtn_Click;
        // 
        // importMatchImageBtn
        // 
        importMatchImageBtn.Location = new Point(12, 415);
        importMatchImageBtn.Name = "importMatchImageBtn";
        importMatchImageBtn.Size = new Size(170, 45);
        importMatchImageBtn.TabIndex = 6;
        importMatchImageBtn.Text = "导入匹配原图像";
        importMatchImageBtn.UseVisualStyleBackColor = true;
        importMatchImageBtn.Click += importMatchImageBtn_Click;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(12, 557);
        label1.Name = "label1";
        label1.Size = new Size(114, 20);
        label1.TabIndex = 3;
        label1.Text = "最小匹配分数：";
        // 
        // minScoreTextBox
        // 
        minScoreTextBox.Location = new Point(132, 553);
        minScoreTextBox.Name = "minScoreTextBox";
        minScoreTextBox.Size = new Size(86, 27);
        minScoreTextBox.TabIndex = 4;
        minScoreTextBox.Text = "0.60";
        minScoreTextBox.TextChanged += minScoreTextBox_TextChanged;
        // 
        // hSmartWindowControlOriginal
        // 
        hSmartWindowControlOriginal.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        hSmartWindowControlOriginal.AutoValidate = AutoValidate.EnableAllowFocusChange;
        hSmartWindowControlOriginal.HDoubleClickToFitContent = true;
        hSmartWindowControlOriginal.HDrawingObjectsModifier = HalconDotNet.HSmartWindowControl.DrawingObjectsModifier.None;
        hSmartWindowControlOriginal.HImagePart = new Rectangle(0, 0, 512, 384);
        hSmartWindowControlOriginal.HKeepAspectRatio = true;
        hSmartWindowControlOriginal.HMoveContent = false;
        hSmartWindowControlOriginal.HZoomContent = HalconDotNet.HSmartWindowControl.ZoomContent.WheelForwardZoomsIn;
        hSmartWindowControlOriginal.Location = new Point(12, 12);
        hSmartWindowControlOriginal.Margin = new Padding(0);
        hSmartWindowControlOriginal.Name = "hSmartWindowControlOriginal";
        hSmartWindowControlOriginal.Size = new Size(520, 380);
        hSmartWindowControlOriginal.TabIndex = 5;
        hSmartWindowControlOriginal.WindowSize = new Size(520, 380);
        // 
        // hSmartWindowControlTemplate
        // 
        hSmartWindowControlTemplate.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        hSmartWindowControlTemplate.AutoValidate = AutoValidate.EnableAllowFocusChange;
        hSmartWindowControlTemplate.HDoubleClickToFitContent = true;
        hSmartWindowControlTemplate.HDrawingObjectsModifier = HalconDotNet.HSmartWindowControl.DrawingObjectsModifier.None;
        hSmartWindowControlTemplate.HImagePart = new Rectangle(0, 0, 512, 384);
        hSmartWindowControlTemplate.HKeepAspectRatio = true;
        hSmartWindowControlTemplate.HMoveContent = false;
        hSmartWindowControlTemplate.HZoomContent = HalconDotNet.HSmartWindowControl.ZoomContent.WheelForwardZoomsIn;
        hSmartWindowControlTemplate.Location = new Point(560, 12);
        hSmartWindowControlTemplate.Margin = new Padding(0);
        hSmartWindowControlTemplate.Name = "hSmartWindowControlTemplate";
        hSmartWindowControlTemplate.Size = new Size(520, 380);
        hSmartWindowControlTemplate.TabIndex = 6;
        hSmartWindowControlTemplate.WindowSize = new Size(520, 380);
        // 
        // TemplateMatchingForm
        // 
        AutoScaleDimensions = new SizeF(9F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1100, 620);
        Controls.Add(hSmartWindowControlTemplate);
        Controls.Add(hSmartWindowControlOriginal);
        Controls.Add(minScoreTextBox);
        Controls.Add(label1);
        Controls.Add(cancelClipBtn);
        Controls.Add(matchBtn);
        Controls.Add(importMatchImageBtn);
        Controls.Add(clipTemplateBtn);
        Controls.Add(importTemplateBtn);
        Name = "TemplateMatchingForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "模板匹配";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private System.Windows.Forms.Button importTemplateBtn;
    private System.Windows.Forms.Button clipTemplateBtn;
    private System.Windows.Forms.Button cancelClipBtn;
    private System.Windows.Forms.Button matchBtn;
    private System.Windows.Forms.Button importMatchImageBtn;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox minScoreTextBox;
    private HalconDotNet.HSmartWindowControl hSmartWindowControlOriginal;
    private HalconDotNet.HSmartWindowControl hSmartWindowControlTemplate;
}

