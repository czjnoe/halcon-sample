using System.ComponentModel;

namespace HalconCalibration.Views.HalconProjects;

partial class Threshold
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

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        panel1 = new Panel();
        tableLayoutPanel1 = new TableLayoutPanel();
        groupBox1 = new GroupBox();
        thresholdMax = new TextBox();
        thresholdMin = new TextBox();
        label2 = new Label();
        label1 = new Label();
        groupBox2 = new GroupBox();
        selectShapeMax = new TextBox();
        selectShapeMin = new TextBox();
        label3 = new Label();
        label4 = new Label();
        panel2 = new Panel();
        operatorComboBox = new ComboBox();
        label6 = new Label();
        featuresComboBox = new ComboBox();
        label5 = new Label();
        tableLayoutPanel2 = new TableLayoutPanel();
        applyBtn = new Button();
        resetBtn = new Button();
        panel1.SuspendLayout();
        tableLayoutPanel1.SuspendLayout();
        groupBox1.SuspendLayout();
        groupBox2.SuspendLayout();
        panel2.SuspendLayout();
        tableLayoutPanel2.SuspendLayout();
        SuspendLayout();
        // 
        // panel1
        // 
        panel1.Controls.Add(tableLayoutPanel1);
        panel1.Dock = DockStyle.Fill;
        panel1.Location = new Point(0, 0);
        panel1.Name = "panel1";
        panel1.Size = new Size(293, 417);
        panel1.TabIndex = 0;
        // 
        // tableLayoutPanel1
        // 
        tableLayoutPanel1.ColumnCount = 1;
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tableLayoutPanel1.Controls.Add(groupBox1, 0, 0);
        tableLayoutPanel1.Controls.Add(groupBox2, 0, 1);
        tableLayoutPanel1.Controls.Add(panel2, 0, 2);
        tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 3);
        tableLayoutPanel1.Dock = DockStyle.Fill;
        tableLayoutPanel1.Location = new Point(0, 0);
        tableLayoutPanel1.Name = "tableLayoutPanel1";
        tableLayoutPanel1.RowCount = 4;
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 117F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 129F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 114F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 8F));
        tableLayoutPanel1.Size = new Size(293, 417);
        tableLayoutPanel1.TabIndex = 0;
        // 
        // groupBox1
        // 
        groupBox1.Controls.Add(thresholdMax);
        groupBox1.Controls.Add(thresholdMin);
        groupBox1.Controls.Add(label2);
        groupBox1.Controls.Add(label1);
        groupBox1.Dock = DockStyle.Fill;
        groupBox1.Location = new Point(3, 3);
        groupBox1.Name = "groupBox1";
        groupBox1.Size = new Size(287, 111);
        groupBox1.TabIndex = 0;
        groupBox1.TabStop = false;
        groupBox1.Text = "threshold";
        // 
        // thresholdMax
        // 
        thresholdMax.Location = new Point(116, 67);
        thresholdMax.Name = "thresholdMax";
        thresholdMax.Size = new Size(152, 27);
        thresholdMax.TabIndex = 3;
        thresholdMax.TextChanged += thresholdMax_TextChanged;
        // 
        // thresholdMin
        // 
        thresholdMin.Location = new Point(116, 26);
        thresholdMin.Name = "thresholdMin";
        thresholdMin.Size = new Size(152, 27);
        thresholdMin.TabIndex = 2;
        thresholdMin.TextChanged += thresholdMin_TextChanged;
        // 
        // label2
        // 
        label2.Location = new Point(29, 70);
        label2.Name = "label2";
        label2.Size = new Size(67, 20);
        label2.TabIndex = 1;
        label2.Text = "最大值";
        label2.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // label1
        // 
        label1.Location = new Point(29, 28);
        label1.Name = "label1";
        label1.Size = new Size(69, 23);
        label1.TabIndex = 0;
        label1.Text = "最小值";
        label1.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // groupBox2
        // 
        groupBox2.Controls.Add(selectShapeMax);
        groupBox2.Controls.Add(selectShapeMin);
        groupBox2.Controls.Add(label3);
        groupBox2.Controls.Add(label4);
        groupBox2.Dock = DockStyle.Fill;
        groupBox2.Location = new Point(3, 120);
        groupBox2.Name = "groupBox2";
        groupBox2.Size = new Size(287, 123);
        groupBox2.TabIndex = 1;
        groupBox2.TabStop = false;
        groupBox2.Text = "selectshape";
        // 
        // selectShapeMax
        // 
        selectShapeMax.Location = new Point(116, 77);
        selectShapeMax.Name = "selectShapeMax";
        selectShapeMax.Size = new Size(152, 27);
        selectShapeMax.TabIndex = 3;
        selectShapeMax.TextChanged += selectShapeMax_TextChanged;
        // 
        // selectShapeMin
        // 
        selectShapeMin.Location = new Point(116, 36);
        selectShapeMin.Name = "selectShapeMin";
        selectShapeMin.Size = new Size(152, 27);
        selectShapeMin.TabIndex = 2;
        selectShapeMin.TextChanged += selectShapeMin_TextChanged;
        // 
        // label3
        // 
        label3.Location = new Point(29, 38);
        label3.Name = "label3";
        label3.Size = new Size(69, 23);
        label3.TabIndex = 0;
        label3.Text = "最小值";
        label3.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // label4
        // 
        label4.Location = new Point(29, 80);
        label4.Name = "label4";
        label4.Size = new Size(67, 20);
        label4.TabIndex = 1;
        label4.Text = "最大值";
        label4.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // panel2
        // 
        panel2.Controls.Add(operatorComboBox);
        panel2.Controls.Add(label6);
        panel2.Controls.Add(featuresComboBox);
        panel2.Controls.Add(label5);
        panel2.Dock = DockStyle.Fill;
        panel2.Location = new Point(3, 249);
        panel2.Name = "panel2";
        panel2.Size = new Size(287, 108);
        panel2.TabIndex = 2;
        // 
        // operatorComboBox
        // 
        operatorComboBox.FormattingEnabled = true;
        operatorComboBox.Location = new Point(116, 67);
        operatorComboBox.Name = "operatorComboBox";
        operatorComboBox.Size = new Size(152, 28);
        operatorComboBox.TabIndex = 1;
        operatorComboBox.SelectionChangeCommitted += operatorComboBox_SelectionChangeCommitted;
        // 
        // label6
        // 
        label6.Location = new Point(31, 70);
        label6.Name = "label6";
        label6.Size = new Size(67, 20);
        label6.TabIndex = 1;
        label6.Text = "operator";
        label6.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // featuresComboBox
        // 
        featuresComboBox.FormattingEnabled = true;
        featuresComboBox.Location = new Point(116, 20);
        featuresComboBox.Name = "featuresComboBox";
        featuresComboBox.Size = new Size(152, 28);
        featuresComboBox.TabIndex = 1;
        featuresComboBox.SelectionChangeCommitted += featuresComboBox_SelectionChangeCommitted;
        // 
        // label5
        // 
        label5.Location = new Point(31, 23);
        label5.Name = "label5";
        label5.Size = new Size(67, 20);
        label5.TabIndex = 1;
        label5.Text = "feature";
        label5.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // tableLayoutPanel2
        // 
        tableLayoutPanel2.ColumnCount = 2;
        tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tableLayoutPanel2.Controls.Add(applyBtn, 0, 0);
        tableLayoutPanel2.Controls.Add(resetBtn, 1, 0);
        tableLayoutPanel2.Dock = DockStyle.Fill;
        tableLayoutPanel2.Location = new Point(3, 363);
        tableLayoutPanel2.Name = "tableLayoutPanel2";
        tableLayoutPanel2.RowCount = 1;
        tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
        tableLayoutPanel2.Size = new Size(287, 51);
        tableLayoutPanel2.TabIndex = 3;
        // 
        // applyBtn
        // 
        applyBtn.Dock = DockStyle.Fill;
        applyBtn.Location = new Point(3, 3);
        applyBtn.Name = "applyBtn";
        applyBtn.Size = new Size(137, 45);
        applyBtn.TabIndex = 0;
        applyBtn.Text = "应用";
        applyBtn.UseVisualStyleBackColor = true;
        applyBtn.Click += applyBtn_Click;
        // 
        // resetBtn
        // 
        resetBtn.Dock = DockStyle.Fill;
        resetBtn.Location = new Point(146, 3);
        resetBtn.Name = "resetBtn";
        resetBtn.Size = new Size(138, 45);
        resetBtn.TabIndex = 1;
        resetBtn.Text = "重置";
        resetBtn.UseVisualStyleBackColor = true;
        resetBtn.Click += resetBtn_Click;
        // 
        // Threshold
        // 
        AutoScaleDimensions = new SizeF(9F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(293, 417);
        Controls.Add(panel1);
        MaximizeBox = false;
        MaximumSize = new Size(311, 464);
        MinimumSize = new Size(311, 0);
        Name = "Threshold";
        Text = "Threshold";
        panel1.ResumeLayout(false);
        tableLayoutPanel1.ResumeLayout(false);
        groupBox1.ResumeLayout(false);
        groupBox1.PerformLayout();
        groupBox2.ResumeLayout(false);
        groupBox2.PerformLayout();
        panel2.ResumeLayout(false);
        tableLayoutPanel2.ResumeLayout(false);
        ResumeLayout(false);
    }

    private System.Windows.Forms.Button resetBtn;

    private System.Windows.Forms.Button applyBtn;

    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox thresholdMin;
    private System.Windows.Forms.TextBox thresholdMax;

    private System.Windows.Forms.GroupBox groupBox1;

    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;

    private System.Windows.Forms.Panel panel1;

    #endregion

    private GroupBox groupBox2;
    private System.Windows.Forms.TextBox selectShapeMax;
    private System.Windows.Forms.TextBox selectShapeMin;
    private Label label3;
    private Label label4;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.ComboBox featuresComboBox;
    private Label label5;
    private System.Windows.Forms.ComboBox operatorComboBox;
    private System.Windows.Forms.Label label6;
}