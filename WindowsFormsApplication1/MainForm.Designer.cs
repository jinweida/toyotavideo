namespace VideoApplication
{
    partial class MainForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnBlock = new System.Windows.Forms.Button();
            this.pbPhoto = new System.Windows.Forms.PictureBox();
            this.pbOut = new System.Windows.Forms.PictureBox();
            this.pbIn = new System.Windows.Forms.PictureBox();
            this.txtDate = new System.Windows.Forms.DateTimePicker();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.btnSetting = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.sort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.starttime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ftpStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inpath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.outpath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(144, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(516, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "一汽丰田汽车销售有限公司版权所有  Copyright FAW TOYOTA Motor Sales Co.,LTD.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnBlock);
            this.panel1.Controls.Add(this.pbPhoto);
            this.panel1.Controls.Add(this.pbOut);
            this.panel1.Controls.Add(this.pbIn);
            this.panel1.Controls.Add(this.txtDate);
            this.panel1.Controls.Add(this.btnSubmit);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtPhone);
            this.panel1.Controls.Add(this.btnSetting);
            this.panel1.Controls.Add(this.dataGridView);
            this.panel1.Location = new System.Drawing.Point(0, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(989, 599);
            this.panel1.TabIndex = 25;
            // 
            // btnBlock
            // 
            this.btnBlock.BackColor = System.Drawing.SystemColors.Info;
            this.btnBlock.Location = new System.Drawing.Point(13, 525);
            this.btnBlock.Name = "btnBlock";
            this.btnBlock.Size = new System.Drawing.Size(220, 27);
            this.btnBlock.TabIndex = 34;
            this.btnBlock.Text = "锁定窗口";
            this.btnBlock.UseVisualStyleBackColor = false;
            this.btnBlock.Click += new System.EventHandler(this.btnBlock_Click);
            // 
            // pbPhoto
            // 
            this.pbPhoto.Image = global::VideoApplication.Properties.Resources.image;
            this.pbPhoto.Location = new System.Drawing.Point(13, 317);
            this.pbPhoto.Name = "pbPhoto";
            this.pbPhoto.Size = new System.Drawing.Size(220, 161);
            this.pbPhoto.TabIndex = 33;
            this.pbPhoto.TabStop = false;
            this.pbPhoto.Click += new System.EventHandler(this.pbPhoto_Click);
            // 
            // pbOut
            // 
            this.pbOut.Image = global::VideoApplication.Properties.Resources._out;
            this.pbOut.Location = new System.Drawing.Point(12, 133);
            this.pbOut.Name = "pbOut";
            this.pbOut.Size = new System.Drawing.Size(220, 124);
            this.pbOut.TabIndex = 32;
            this.pbOut.TabStop = false;
            this.pbOut.Click += new System.EventHandler(this.pbOut_Click);
            // 
            // pbIn
            // 
            this.pbIn.Image = global::VideoApplication.Properties.Resources._in;
            this.pbIn.Location = new System.Drawing.Point(12, 3);
            this.pbIn.Name = "pbIn";
            this.pbIn.Size = new System.Drawing.Size(220, 124);
            this.pbIn.TabIndex = 31;
            this.pbIn.TabStop = false;
            this.pbIn.Click += new System.EventHandler(this.pbIn_Click);
            // 
            // txtDate
            // 
            this.txtDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtDate.Location = new System.Drawing.Point(73, 290);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(160, 21);
            this.txtDate.TabIndex = 30;
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSubmit.Location = new System.Drawing.Point(13, 492);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(220, 27);
            this.btnSubmit.TabIndex = 28;
            this.btnSubmit.Text = "立即提交";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 296);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 26;
            this.label5.Text = "试驾时间";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 266);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 25;
            this.label4.Text = "手机号码";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(72, 263);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(161, 21);
            this.txtPhone.TabIndex = 24;
            // 
            // btnSetting
            // 
            this.btnSetting.Location = new System.Drawing.Point(13, 558);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(220, 27);
            this.btnSetting.TabIndex = 23;
            this.btnSetting.Text = "隐藏设置";
            this.btnSetting.UseVisualStyleBackColor = true;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sort,
            this.phone,
            this.starttime,
            this.transStatus,
            this.ftpStatus,
            this.inpath,
            this.outpath});
            this.dataGridView.EnableHeadersVisualStyles = false;
            this.dataGridView.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dataGridView.Location = new System.Drawing.Point(249, 3);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersWidth = 25;
            this.dataGridView.RowTemplate.Height = 23;
            this.dataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.dataGridView.Size = new System.Drawing.Size(729, 581);
            this.dataGridView.StandardTab = true;
            this.dataGridView.TabIndex = 22;
            // 
            // sort
            // 
            this.sort.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.sort.DefaultCellStyle = dataGridViewCellStyle1;
            this.sort.FillWeight = 124.3655F;
            this.sort.Frozen = true;
            this.sort.HeaderText = "排序";
            this.sort.Name = "sort";
            this.sort.ReadOnly = true;
            this.sort.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.sort.Width = 53;
            // 
            // phone
            // 
            this.phone.FillWeight = 95.93909F;
            this.phone.HeaderText = "手机号";
            this.phone.Name = "phone";
            this.phone.ReadOnly = true;
            this.phone.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // starttime
            // 
            this.starttime.FillWeight = 95.93909F;
            this.starttime.HeaderText = "试驾时间";
            this.starttime.Name = "starttime";
            this.starttime.ReadOnly = true;
            // 
            // transStatus
            // 
            this.transStatus.FillWeight = 95.93909F;
            this.transStatus.HeaderText = "转码状态";
            this.transStatus.Name = "transStatus";
            this.transStatus.ReadOnly = true;
            this.transStatus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.transStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ftpStatus
            // 
            this.ftpStatus.FillWeight = 95.93909F;
            this.ftpStatus.HeaderText = "上传状态";
            this.ftpStatus.Name = "ftpStatus";
            this.ftpStatus.ReadOnly = true;
            // 
            // inpath
            // 
            this.inpath.HeaderText = "inpath";
            this.inpath.Name = "inpath";
            this.inpath.ReadOnly = true;
            this.inpath.Visible = false;
            // 
            // outpath
            // 
            this.outpath.HeaderText = "outpath";
            this.outpath.Name = "outpath";
            this.outpath.ReadOnly = true;
            this.outpath.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(-1, 655);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(992, 38);
            this.panel2.TabIndex = 26;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::VideoApplication.Properties.Resources.WechatIMG89;
            this.pictureBox3.Location = new System.Drawing.Point(846, 10);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(146, 35);
            this.pictureBox3.TabIndex = 23;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::VideoApplication.Properties.Resources.WechatIMG90;
            this.pictureBox2.Location = new System.Drawing.Point(11, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(198, 53);
            this.pictureBox2.TabIndex = 22;
            this.pictureBox2.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Gainsboro;
            this.panel3.Controls.Add(this.pictureBox2);
            this.panel3.Controls.Add(this.pictureBox3);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(989, 54);
            this.panel3.TabIndex = 27;
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(989, 692);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "一汽丰田城市越野公园视频客户端";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pbPhoto;
        private System.Windows.Forms.PictureBox pbOut;
        private System.Windows.Forms.PictureBox pbIn;
        private System.Windows.Forms.DateTimePicker txtDate;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Button btnSetting;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnBlock;
        private System.Windows.Forms.DataGridViewTextBoxColumn sort;
        private System.Windows.Forms.DataGridViewTextBoxColumn phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn starttime;
        private System.Windows.Forms.DataGridViewTextBoxColumn transStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn ftpStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn inpath;
        private System.Windows.Forms.DataGridViewTextBoxColumn outpath;

    }
}

