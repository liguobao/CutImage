namespace CutImage
{
    partial class CutImg
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CutImg));
            this.btnSelect = new System.Windows.Forms.Button();
            this.txtSoursePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSavePath = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnStar = new System.Windows.Forms.Button();
            this.bgwCutImage = new System.ComponentModel.BackgroundWorker();
            this.pgbCutImg = new System.Windows.Forms.ProgressBar();
            this.lblMessege = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.nudCoefficient = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.bgwDownload = new System.ComponentModel.BackgroundWorker();
            this.lblCut = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtImgURL = new System.Windows.Forms.TextBox();
            this.btnDown = new System.Windows.Forms.Button();
            this.pgbDownload = new System.Windows.Forms.ProgressBar();
            this.label6 = new System.Windows.Forms.Label();
            this.lblDown = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.rdbW = new System.Windows.Forms.RadioButton();
            this.rdbH = new System.Windows.Forms.RadioButton();
            this.cbbCutLineColor = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudCoefficient)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(502, 138);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(118, 39);
            this.btnSelect.TabIndex = 0;
            this.btnSelect.Text = "选择图片";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // txtSoursePath
            // 
            this.txtSoursePath.Location = new System.Drawing.Point(114, 148);
            this.txtSoursePath.Name = "txtSoursePath";
            this.txtSoursePath.Size = new System.Drawing.Size(364, 21);
            this.txtSoursePath.TabIndex = 1;
            this.txtSoursePath.Text = ".\\download\\";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(10, 147);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "源文件路径：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(20, 200);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "保存路径：";
            // 
            // txtSavePath
            // 
            this.txtSavePath.Location = new System.Drawing.Point(114, 200);
            this.txtSavePath.Name = "txtSavePath";
            this.txtSavePath.Size = new System.Drawing.Size(364, 21);
            this.txtSavePath.TabIndex = 5;
            this.txtSavePath.Text = "D:\\切图后\\";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(502, 191);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(118, 39);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnStar
            // 
            this.btnStar.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStar.Location = new System.Drawing.Point(114, 275);
            this.btnStar.Name = "btnStar";
            this.btnStar.Size = new System.Drawing.Size(364, 73);
            this.btnStar.TabIndex = 7;
            this.btnStar.Text = "开始处理...（&I）";
            this.btnStar.UseVisualStyleBackColor = true;
            this.btnStar.Click += new System.EventHandler(this.btnStar_Click);
            // 
            // bgwCutImage
            // 
            this.bgwCutImage.WorkerReportsProgress = true;
            this.bgwCutImage.WorkerSupportsCancellation = true;
            this.bgwCutImage.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwCutImage_DoWork);
            this.bgwCutImage.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwCutImage_ProgressChanged);
            this.bgwCutImage.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwCutImage_RunWorkerCompleted);
            // 
            // pgbCutImg
            // 
            this.pgbCutImg.Location = new System.Drawing.Point(114, 365);
            this.pgbCutImg.Name = "pgbCutImg";
            this.pgbCutImg.Size = new System.Drawing.Size(333, 23);
            this.pgbCutImg.TabIndex = 8;
            // 
            // lblMessege
            // 
            this.lblMessege.AutoSize = true;
            this.lblMessege.Location = new System.Drawing.Point(137, 376);
            this.lblMessege.Name = "lblMessege";
            this.lblMessege.Size = new System.Drawing.Size(0, 12);
            this.lblMessege.TabIndex = 9;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Location = new System.Drawing.Point(502, 275);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(118, 73);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "取消（&C）";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // nudCoefficient
            // 
            this.nudCoefficient.Location = new System.Drawing.Point(151, 234);
            this.nudCoefficient.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nudCoefficient.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudCoefficient.Name = "nudCoefficient";
            this.nudCoefficient.Size = new System.Drawing.Size(45, 21);
            this.nudCoefficient.TabIndex = 11;
            this.nudCoefficient.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(9, 239);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 16);
            this.label3.TabIndex = 12;
            this.label3.Text = "分割线色差系数：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(202, 239);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(264, 16);
            this.label4.TabIndex = 13;
            this.label4.Text = "(默认100;无法分割，可适度调节。)";
            // 
            // bgwDownload
            // 
            this.bgwDownload.WorkerReportsProgress = true;
            this.bgwDownload.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwDownload_DoWork);
            this.bgwDownload.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwDownload_ProgressChanged);
            this.bgwDownload.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwDownload_RunWorkerCompleted);
            // 
            // lblCut
            // 
            this.lblCut.AutoSize = true;
            this.lblCut.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCut.Location = new System.Drawing.Point(453, 367);
            this.lblCut.Name = "lblCut";
            this.lblCut.Size = new System.Drawing.Size(29, 19);
            this.lblCut.TabIndex = 20;
            this.lblCut.Text = "0%";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(17, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 16);
            this.label5.TabIndex = 14;
            this.label5.Text = "图片URL：";
            // 
            // txtImgURL
            // 
            this.txtImgURL.Location = new System.Drawing.Point(97, 17);
            this.txtImgURL.Name = "txtImgURL";
            this.txtImgURL.Size = new System.Drawing.Size(381, 21);
            this.txtImgURL.TabIndex = 15;
            // 
            // btnDown
            // 
            this.btnDown.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDown.Location = new System.Drawing.Point(502, 22);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(118, 64);
            this.btnDown.TabIndex = 16;
            this.btnDown.Text = "下载文件(&D)";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // pgbDownload
            // 
            this.pgbDownload.Location = new System.Drawing.Point(97, 64);
            this.pgbDownload.Name = "pgbDownload";
            this.pgbDownload.Size = new System.Drawing.Size(347, 22);
            this.pgbDownload.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(9, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 16);
            this.label6.TabIndex = 18;
            this.label6.Text = "下载进度：";
            // 
            // lblDown
            // 
            this.lblDown.AutoSize = true;
            this.lblDown.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDown.Location = new System.Drawing.Point(454, 64);
            this.lblDown.Name = "lblDown";
            this.lblDown.Size = new System.Drawing.Size(24, 16);
            this.lblDown.TabIndex = 19;
            this.lblDown.Text = "0%";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(26, 369);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 16);
            this.label7.TabIndex = 21;
            this.label7.Text = "处理进度：";
            // 
            // rdbW
            // 
            this.rdbW.AutoSize = true;
            this.rdbW.Checked = true;
            this.rdbW.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdbW.Location = new System.Drawing.Point(341, 106);
            this.rdbW.Name = "rdbW";
            this.rdbW.Size = new System.Drawing.Size(60, 20);
            this.rdbW.TabIndex = 22;
            this.rdbW.TabStop = true;
            this.rdbW.Text = "横线";
            this.rdbW.UseVisualStyleBackColor = true;
            // 
            // rdbH
            // 
            this.rdbH.AutoSize = true;
            this.rdbH.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdbH.Location = new System.Drawing.Point(422, 106);
            this.rdbH.Name = "rdbH";
            this.rdbH.Size = new System.Drawing.Size(60, 20);
            this.rdbH.TabIndex = 23;
            this.rdbH.Text = "竖线";
            this.rdbH.UseVisualStyleBackColor = true;
            // 
            // cbbCutLineColor
            // 
            this.cbbCutLineColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbCutLineColor.FormattingEnabled = true;
            this.cbbCutLineColor.Items.AddRange(new object[] {
            "白分割线",
            "黑分割线"});
            this.cbbCutLineColor.Location = new System.Drawing.Point(97, 106);
            this.cbbCutLineColor.Name = "cbbCutLineColor";
            this.cbbCutLineColor.Size = new System.Drawing.Size(121, 20);
            this.cbbCutLineColor.TabIndex = 24;
            this.cbbCutLineColor.SelectionChangeCommitted += new System.EventHandler(this.cbbCutLineColor_SelectionChangeCommitted);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 109);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 12);
            this.label8.TabIndex = 25;
            this.label8.Text = "分割线颜色：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(246, 109);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 12);
            this.label9.TabIndex = 26;
            this.label9.Text = "分割线方向：";
            // 
            // CutImg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 405);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cbbCutLineColor);
            this.Controls.Add(this.rdbH);
            this.Controls.Add(this.rdbW);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblCut);
            this.Controls.Add(this.lblDown);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pgbDownload);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.txtImgURL);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nudCoefficient);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblMessege);
            this.Controls.Add(this.pgbCutImg);
            this.Controls.Add(this.btnStar);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtSavePath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSoursePath);
            this.Controls.Add(this.btnSelect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "CutImg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CutImg";
            ((System.ComponentModel.ISupportInitialize)(this.nudCoefficient)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.TextBox txtSoursePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSavePath;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnStar;
        private System.ComponentModel.BackgroundWorker bgwCutImage;
        private System.Windows.Forms.ProgressBar pgbCutImg;
        private System.Windows.Forms.Label lblMessege;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.NumericUpDown nudCoefficient;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.ComponentModel.BackgroundWorker bgwDownload;
        private System.Windows.Forms.Label lblCut;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtImgURL;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.ProgressBar pgbDownload;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblDown;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton rdbW;
        private System.Windows.Forms.RadioButton rdbH;
        private System.Windows.Forms.ComboBox cbbCutLineColor;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}

