namespace SimplePaint
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            components = new System.ComponentModel.Container();
            ColorDialog colorDialog1;
            label4 = new Label();
            label3 = new Label();
            btnDel = new Button();
            label2 = new Label();
            cmbDashStyle = new ComboBox();
            btnFillColor = new Button();
            label1 = new Label();
            numPenWidth = new NumericUpDown();
            btnChangeColor = new Button();
            btnPolygon = new Button();
            btnClear = new Button();
            btnCurve = new Button();
            btnTri = new Button();
            btnRect = new Button();
            btnEllipse = new Button();
            btnLine = new Button();
            panel1 = new Panel();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            pnlMain = new Panel();
            label5 = new Label();
            contextMenuStrip1 = new ContextMenuStrip(components);
            groupToolStripMenuItem = new ToolStripMenuItem();
            unGroupToolStripMenuItem = new ToolStripMenuItem();
            fillToolStripMenuItem = new ToolStripMenuItem();
            đổiĐườngViềnToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripMenuItem();
            toolStripMenuItem3 = new ToolStripMenuItem();
            toolStripMenuItem4 = new ToolStripMenuItem();
            toolStripMenuItem5 = new ToolStripMenuItem();
            toolStripMenuItem6 = new ToolStripMenuItem();
            đổiMàuBútToolStripMenuItem = new ToolStripMenuItem();
            độDàyBútToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem7 = new ToolStripMenuItem();
            toolStripMenuItem8 = new ToolStripMenuItem();
            toolStripMenuItem9 = new ToolStripMenuItem();
            toolStripMenuItem10 = new ToolStripMenuItem();
            toolStripMenuItem11 = new ToolStripMenuItem();
            xóaHìnhToolStripMenuItem = new ToolStripMenuItem();
            colorDialog1 = new ColorDialog();
            ((System.ComponentModel.ISupportInitialize)numPenWidth).BeginInit();
            panel1.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // colorDialog1
            // 
            colorDialog1.FullOpen = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(106, 123);
            label4.Name = "label4";
            label4.Size = new Size(36, 21);
            label4.TabIndex = 17;
            label4.Text = "\U0001faa3 ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(112, 184);
            label3.Name = "label3";
            label3.Size = new Size(30, 21);
            label3.TabIndex = 16;
            label3.Text = "✎ ";
            // 
            // btnDel
            // 
            btnDel.Location = new Point(121, 239);
            btnDel.Name = "btnDel";
            btnDel.Size = new Size(90, 29);
            btnDel.TabIndex = 15;
            btnDel.Text = "\U0001f9fd  Xóa";
            btnDel.UseVisualStyleBackColor = true;
            btnDel.Click += btnDel_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.ControlDarkDark;
            label2.Location = new Point(14, 360);
            label2.Name = "label2";
            label2.Size = new Size(85, 21);
            label2.TabIndex = 14;
            label2.Text = "Đường bút";
            // 
            // cmbDashStyle
            // 
            cmbDashStyle.BackColor = SystemColors.Window;
            cmbDashStyle.FormattingEnabled = true;
            cmbDashStyle.Items.AddRange(new object[] { "____", "----", "....", ".-.-.", "..-..-.." });
            cmbDashStyle.Location = new Point(14, 384);
            cmbDashStyle.Name = "cmbDashStyle";
            cmbDashStyle.Size = new Size(83, 29);
            cmbDashStyle.TabIndex = 13;
            cmbDashStyle.SelectedIndexChanged += cmbDashStyle_SelectedIndexChanged;
            cmbDashStyle.Click += cmbDashStyle_SelectedIndexChanged;
            // 
            // btnFillColor
            // 
            btnFillColor.BackColor = SystemColors.ActiveCaptionText;
            btnFillColor.Location = new Point(140, 119);
            btnFillColor.Name = "btnFillColor";
            btnFillColor.Size = new Size(63, 29);
            btnFillColor.TabIndex = 12;
            btnFillColor.UseVisualStyleBackColor = false;
            btnFillColor.Click += btnFillColor_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.ControlDarkDark;
            label1.Location = new Point(125, 360);
            label1.Name = "label1";
            label1.Size = new Size(86, 21);
            label1.TabIndex = 11;
            label1.Text = "Độ dày bút";
            // 
            // numPenWidth
            // 
            numPenWidth.Location = new Point(130, 384);
            numPenWidth.Name = "numPenWidth";
            numPenWidth.Size = new Size(81, 29);
            numPenWidth.TabIndex = 10;
            numPenWidth.Value = new decimal(new int[] { 2, 0, 0, 0 });
            numPenWidth.ValueChanged += numPenWidth_ValueChanged;
            numPenWidth.Click += numPenWidth_ValueChanged;
            // 
            // btnChangeColor
            // 
            btnChangeColor.BackColor = SystemColors.ActiveCaptionText;
            btnChangeColor.Location = new Point(140, 185);
            btnChangeColor.Name = "btnChangeColor";
            btnChangeColor.Size = new Size(63, 20);
            btnChangeColor.TabIndex = 8;
            btnChangeColor.UseVisualStyleBackColor = false;
            btnChangeColor.Click += btnColor_Click;
            // 
            // btnPolygon
            // 
            btnPolygon.Location = new Point(63, 176);
            btnPolygon.Name = "btnPolygon";
            btnPolygon.Size = new Size(37, 29);
            btnPolygon.TabIndex = 7;
            btnPolygon.Text = "⌂";
            btnPolygon.UseVisualStyleBackColor = true;
            btnPolygon.Click += btnPolygon_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(43, 463);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(137, 59);
            btnClear.TabIndex = 5;
            btnClear.Text = "Xóa tất cả";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnCurve
            // 
            btnCurve.Location = new Point(61, 239);
            btnCurve.Name = "btnCurve";
            btnCurve.Size = new Size(39, 29);
            btnCurve.TabIndex = 4;
            btnCurve.Text = "৻";
            btnCurve.UseVisualStyleBackColor = true;
            btnCurve.Click += btnCurve_Click;
            // 
            // btnTri
            // 
            btnTri.Location = new Point(14, 239);
            btnTri.Name = "btnTri";
            btnTri.Size = new Size(39, 29);
            btnTri.TabIndex = 3;
            btnTri.Text = "△";
            btnTri.UseVisualStyleBackColor = true;
            btnTri.Click += btnTri_Click;
            // 
            // btnRect
            // 
            btnRect.Location = new Point(16, 176);
            btnRect.Name = "btnRect";
            btnRect.Size = new Size(39, 29);
            btnRect.TabIndex = 2;
            btnRect.Text = "▭";
            btnRect.UseVisualStyleBackColor = true;
            btnRect.Click += btnRect_Click;
            // 
            // btnEllipse
            // 
            btnEllipse.Location = new Point(61, 119);
            btnEllipse.Name = "btnEllipse";
            btnEllipse.Size = new Size(39, 29);
            btnEllipse.TabIndex = 1;
            btnEllipse.Text = "○";
            btnEllipse.UseVisualStyleBackColor = true;
            btnEllipse.Click += btnEllipse_Click;
            // 
            // btnLine
            // 
            btnLine.Location = new Point(14, 119);
            btnLine.Name = "btnLine";
            btnLine.Size = new Size(39, 29);
            btnLine.TabIndex = 0;
            btnLine.Text = "—";
            btnLine.UseVisualStyleBackColor = true;
            btnLine.Click += btnLine_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlLight;
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(pnlMain);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(btnDel);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(cmbDashStyle);
            panel1.Controls.Add(btnFillColor);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(numPenWidth);
            panel1.Controls.Add(btnChangeColor);
            panel1.Controls.Add(btnPolygon);
            panel1.Controls.Add(btnClear);
            panel1.Controls.Add(btnCurve);
            panel1.Controls.Add(btnTri);
            panel1.Controls.Add(btnRect);
            panel1.Controls.Add(btnEllipse);
            panel1.Controls.Add(btnLine);
            panel1.Location = new Point(5, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(1095, 563);
            panel1.TabIndex = 4;
            // 
            // button3
            // 
            button3.Location = new Point(140, 295);
            button3.Name = "button3";
            button3.Size = new Size(63, 43);
            button3.TabIndex = 21;
            button3.Text = "🏴";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Location = new Point(63, 295);
            button2.Name = "button2";
            button2.Size = new Size(39, 29);
            button2.TabIndex = 20;
            button2.Text = "🗡";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(14, 295);
            button1.Name = "button1";
            button1.Size = new Size(39, 29);
            button1.TabIndex = 19;
            button1.Text = "🔫";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // pnlMain
            // 
            pnlMain.BackColor = Color.WhiteSmoke;
            pnlMain.BorderStyle = BorderStyle.FixedSingle;
            pnlMain.Location = new Point(246, 26);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(822, 518);
            pnlMain.TabIndex = 5;
            pnlMain.Paint += pnlMain_Paint;
            pnlMain.MouseDown += pnlMain_MouseDown;
            pnlMain.MouseMove += pnlMain_MouseMove;
            pnlMain.MouseUp += pnlMain_MouseUp;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label5.ForeColor = SystemColors.WindowFrame;
            label5.Location = new Point(7, 26);
            label5.Name = "label5";
            label5.Size = new Size(188, 31);
            label5.TabIndex = 18;
            label5.Text = "🎨 Simple Paint";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { groupToolStripMenuItem, unGroupToolStripMenuItem, fillToolStripMenuItem, đổiĐườngViềnToolStripMenuItem, đổiMàuBútToolStripMenuItem, độDàyBútToolStripMenuItem, xóaHìnhToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(211, 214);
            // 
            // groupToolStripMenuItem
            // 
            groupToolStripMenuItem.Name = "groupToolStripMenuItem";
            groupToolStripMenuItem.Size = new Size(210, 26);
            groupToolStripMenuItem.Text = "Nhóm hình";
            groupToolStripMenuItem.Click += groupToolStripMenuItem_Click;
            // 
            // unGroupToolStripMenuItem
            // 
            unGroupToolStripMenuItem.Name = "unGroupToolStripMenuItem";
            unGroupToolStripMenuItem.Size = new Size(210, 26);
            unGroupToolStripMenuItem.Text = "Bỏ nhóm hình";
            unGroupToolStripMenuItem.Click += unGroupToolStripMenuItem_Click;
            // 
            // fillToolStripMenuItem
            // 
            fillToolStripMenuItem.Name = "fillToolStripMenuItem";
            fillToolStripMenuItem.Size = new Size(210, 26);
            fillToolStripMenuItem.Text = "Tô hình";
            fillToolStripMenuItem.Click += btnFillColor_Click;
            // 
            // đổiĐườngViềnToolStripMenuItem
            // 
            đổiĐườngViềnToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem2, toolStripMenuItem3, toolStripMenuItem4, toolStripMenuItem5, toolStripMenuItem6 });
            đổiĐườngViềnToolStripMenuItem.Name = "đổiĐườngViềnToolStripMenuItem";
            đổiĐườngViềnToolStripMenuItem.Size = new Size(210, 26);
            đổiĐườngViềnToolStripMenuItem.Text = "Đổi đường viền";
            đổiĐườngViềnToolStripMenuItem.Click += cmbDashStyle_SelectedIndexChanged;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(244, 26);
            toolStripMenuItem2.Text = "_____________________";
            toolStripMenuItem2.Click += toolStripMenuItem2_Click;
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new Size(244, 26);
            toolStripMenuItem3.Text = "-------------------------";
            toolStripMenuItem3.Click += toolStripMenuItem3_Click;
            // 
            // toolStripMenuItem4
            // 
            toolStripMenuItem4.Name = "toolStripMenuItem4";
            toolStripMenuItem4.Size = new Size(244, 26);
            toolStripMenuItem4.Text = "-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.";
            toolStripMenuItem4.Click += toolStripMenuItem4_Click;
            // 
            // toolStripMenuItem5
            // 
            toolStripMenuItem5.Name = "toolStripMenuItem5";
            toolStripMenuItem5.Size = new Size(244, 26);
            toolStripMenuItem5.Text = "-..-..-..-..-..-..-..-..-..-..-..-..";
            toolStripMenuItem5.Click += toolStripMenuItem5_Click;
            // 
            // toolStripMenuItem6
            // 
            toolStripMenuItem6.Name = "toolStripMenuItem6";
            toolStripMenuItem6.Size = new Size(244, 26);
            toolStripMenuItem6.Text = "...............................................";
            toolStripMenuItem6.Click += toolStripMenuItem6_Click;
            // 
            // đổiMàuBútToolStripMenuItem
            // 
            đổiMàuBútToolStripMenuItem.Name = "đổiMàuBútToolStripMenuItem";
            đổiMàuBútToolStripMenuItem.Size = new Size(210, 26);
            đổiMàuBútToolStripMenuItem.Text = "Đổi màu bút";
            đổiMàuBútToolStripMenuItem.Click += btnColor_Click;
            // 
            // độDàyBútToolStripMenuItem
            // 
            độDàyBútToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem7, toolStripMenuItem8, toolStripMenuItem9, toolStripMenuItem10, toolStripMenuItem11 });
            độDàyBútToolStripMenuItem.Name = "độDàyBútToolStripMenuItem";
            độDàyBútToolStripMenuItem.Size = new Size(210, 26);
            độDàyBútToolStripMenuItem.Text = "Độ dày bút";
            độDàyBútToolStripMenuItem.Click += độDàyBútToolStripMenuItem_Click;
            // 
            // toolStripMenuItem7
            // 
            toolStripMenuItem7.Name = "toolStripMenuItem7";
            toolStripMenuItem7.Size = new Size(103, 26);
            toolStripMenuItem7.Text = "1";
            toolStripMenuItem7.Click += toolStripMenuItem7_Click;
            // 
            // toolStripMenuItem8
            // 
            toolStripMenuItem8.Name = "toolStripMenuItem8";
            toolStripMenuItem8.Size = new Size(103, 26);
            toolStripMenuItem8.Text = "2";
            toolStripMenuItem8.Click += toolStripMenuItem8_Click;
            // 
            // toolStripMenuItem9
            // 
            toolStripMenuItem9.Name = "toolStripMenuItem9";
            toolStripMenuItem9.Size = new Size(103, 26);
            toolStripMenuItem9.Text = "3";
            toolStripMenuItem9.Click += toolStripMenuItem9_Click;
            // 
            // toolStripMenuItem10
            // 
            toolStripMenuItem10.Name = "toolStripMenuItem10";
            toolStripMenuItem10.Size = new Size(103, 26);
            toolStripMenuItem10.Text = "4";
            toolStripMenuItem10.Click += toolStripMenuItem10_Click;
            // 
            // toolStripMenuItem11
            // 
            toolStripMenuItem11.Name = "toolStripMenuItem11";
            toolStripMenuItem11.Size = new Size(103, 26);
            toolStripMenuItem11.Text = "5";
            toolStripMenuItem11.Click += toolStripMenuItem11_Click;
            // 
            // xóaHìnhToolStripMenuItem
            // 
            xóaHìnhToolStripMenuItem.Name = "xóaHìnhToolStripMenuItem";
            xóaHìnhToolStripMenuItem.Size = new Size(210, 26);
            xóaHìnhToolStripMenuItem.Text = "Xóa hình";
            xóaHìnhToolStripMenuItem.Click += btnDel_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1112, 581);
            Controls.Add(panel1);
            Name = "MainForm";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)numPenWidth).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label label4;
        private Label label3;
        private Button btnDel;
        private Label label2;
        private ComboBox cmbDashStyle;
        private Button btnFillColor;
        private Label label1;
        private NumericUpDown numPenWidth;
        private Button btnChangeColor;
        private Button btnPolygon;
        private Button btnClear;
        private Button btnCurve;
        private Button btnTri;
        private Button btnRect;
        private Button btnEllipse;
        private Button btnLine;
        private Panel panel1;
        private Panel pnlMain;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem groupToolStripMenuItem;
        private ToolStripMenuItem unGroupToolStripMenuItem;
        private ToolStripMenuItem fillToolStripMenuItem;
        private ToolStripMenuItem đổiĐườngViềnToolStripMenuItem;
        private ToolStripMenuItem đổiMàuBútToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripMenuItem toolStripMenuItem4;
        private ToolStripMenuItem toolStripMenuItem5;
        private ToolStripMenuItem toolStripMenuItem6;
        private ToolStripMenuItem độDàyBútToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem7;
        private ToolStripMenuItem toolStripMenuItem8;
        private ToolStripMenuItem toolStripMenuItem9;
        private ToolStripMenuItem toolStripMenuItem10;
        private ToolStripMenuItem toolStripMenuItem11;
        private ToolStripMenuItem xóaHìnhToolStripMenuItem;
        private Label label5;
        private Button button2;
        private Button button1;
        private Button button3;
    }
}
