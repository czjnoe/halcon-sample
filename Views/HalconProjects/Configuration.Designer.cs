using System.ComponentModel;

namespace HalconCalibration.Views.HalconProjects;

partial class Configuration
{
    /// <summary> 
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

    /// <summary> 
    /// Clean up any resources being used.
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

    #region Component Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        panel1 = new Panel();
        tableLayoutPanel1 = new TableLayoutPanel();
        thresholdBtn = new Button();
        qrCodeBtn = new Button();
        templateMatchBtn = new Button();
        panel1.SuspendLayout();
        tableLayoutPanel1.SuspendLayout();
        SuspendLayout();
        // 
        // panel1
        // 
        panel1.Controls.Add(tableLayoutPanel1);
        panel1.Dock = DockStyle.Fill;
        panel1.Location = new Point(0, 0);
        panel1.Name = "panel1";
        panel1.Size = new Size(312, 371);
        panel1.TabIndex = 0;
        // 
        // tableLayoutPanel1
        // 
        tableLayoutPanel1.ColumnCount = 2;
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tableLayoutPanel1.Controls.Add(thresholdBtn, 0, 0);
        tableLayoutPanel1.Controls.Add(qrCodeBtn, 1, 0);
        tableLayoutPanel1.Controls.Add(templateMatchBtn, 0, 1);
        tableLayoutPanel1.Dock = DockStyle.Fill;
        tableLayoutPanel1.Location = new Point(0, 0);
        tableLayoutPanel1.Name = "tableLayoutPanel1";
        tableLayoutPanel1.RowCount = 3;
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 85F));
        tableLayoutPanel1.Size = new Size(312, 371);
        tableLayoutPanel1.TabIndex = 0;
        // 
        // thresholdBtn
        // 
        thresholdBtn.Dock = DockStyle.Fill;
        thresholdBtn.Location = new Point(3, 3);
        thresholdBtn.Name = "thresholdBtn";
        thresholdBtn.Size = new Size(150, 54);
        thresholdBtn.TabIndex = 0;
        thresholdBtn.Text = "阈值分割";
        thresholdBtn.UseVisualStyleBackColor = true;
        thresholdBtn.Click += thresholdBtn_Click;
        // 
        // qrCodeBtn
        // 
        qrCodeBtn.Dock = DockStyle.Fill;
        qrCodeBtn.Location = new Point(156, 3);
        qrCodeBtn.Name = "qrCodeBtn";
        qrCodeBtn.Size = new Size(150, 54);
        qrCodeBtn.TabIndex = 1;
        qrCodeBtn.Text = "二维码识别";
        qrCodeBtn.UseVisualStyleBackColor = true;
        qrCodeBtn.Click += qrCodeBtn_Click;
        //
        // templateMatchBtn
        //
        templateMatchBtn.Dock = DockStyle.Fill;
        templateMatchBtn.Location = new Point(3, 63);
        templateMatchBtn.Name = "templateMatchBtn";
        templateMatchBtn.Size = new Size(150, 54);
        templateMatchBtn.TabIndex = 2;
        templateMatchBtn.Text = "模板匹配";
        templateMatchBtn.UseVisualStyleBackColor = true;
        templateMatchBtn.Click += templateMatchBtn_Click;
        // 
        // Calibration
        // 
        AutoScaleDimensions = new SizeF(9F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(panel1);
        Name = "Calibration";
        Size = new Size(312, 371);
        panel1.ResumeLayout(false);
        tableLayoutPanel1.ResumeLayout(false);
        ResumeLayout(false);
    }

    private System.Windows.Forms.Button thresholdBtn;
    private System.Windows.Forms.Button qrCodeBtn;
    private System.Windows.Forms.Button templateMatchBtn;

    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;

    private System.Windows.Forms.Panel panel1;

    #endregion
}