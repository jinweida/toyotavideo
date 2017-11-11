namespace VideoApplication
{
    partial class SettingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.btnSetting = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.sort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.videotype = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.stime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.duration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.play = new System.Windows.Forms.DataGridViewLinkColumn();
            this.btnAddRow = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.lbOutText = new System.Windows.Forms.Label();
            this.lbOut = new System.Windows.Forms.Label();
            this.lbInText = new System.Windows.Forms.Label();
            this.lbIn = new System.Windows.Forms.Label();
            this.btnDel = new System.Windows.Forms.Button();
            this.pbOut = new System.Windows.Forms.PictureBox();
            this.pbIn = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbIn)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSetting
            // 
            this.btnSetting.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSetting.Location = new System.Drawing.Point(12, 456);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(220, 27);
            this.btnSetting.TabIndex = 21;
            this.btnSetting.Text = "保存配置";
            this.btnSetting.UseVisualStyleBackColor = false;
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
            this.videotype,
            this.stime,
            this.duration,
            this.play});
            this.dataGridView.EnableHeadersVisualStyles = false;
            this.dataGridView.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dataGridView.Location = new System.Drawing.Point(238, 43);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 25;
            this.dataGridView.RowTemplate.Height = 23;
            this.dataGridView.Size = new System.Drawing.Size(503, 440);
            this.dataGridView.StandardTab = true;
            this.dataGridView.TabIndex = 20;
            this.dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellContentClick);
            this.dataGridView.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridView_UserDeletedRow);
            // 
            // sort
            // 
            this.sort.HeaderText = "排序";
            this.sort.Name = "sort";
            this.sort.ReadOnly = true;
            this.sort.Visible = false;
            // 
            // videotype
            // 
            this.videotype.HeaderText = "视频";
            this.videotype.Name = "videotype";
            // 
            // stime
            // 
            this.stime.HeaderText = "开始时间";
            this.stime.Name = "stime";
            // 
            // duration
            // 
            this.duration.HeaderText = "时长(秒)";
            this.duration.Name = "duration";
            // 
            // play
            // 
            this.play.HeaderText = "预览";
            this.play.Name = "play";
            this.play.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.play.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // btnAddRow
            // 
            this.btnAddRow.Location = new System.Drawing.Point(238, 12);
            this.btnAddRow.Name = "btnAddRow";
            this.btnAddRow.Size = new System.Drawing.Size(106, 25);
            this.btnAddRow.TabIndex = 24;
            this.btnAddRow.Text = "添加车内截取规则";
            this.btnAddRow.UseVisualStyleBackColor = true;
            this.btnAddRow.Click += new System.EventHandler(this.btnAddRow_Click);
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(406, 12);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(50, 25);
            this.btnUp.TabIndex = 25;
            this.btnUp.Text = "上移";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(462, 12);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(50, 25);
            this.btnDown.TabIndex = 26;
            this.btnDown.Text = "下移";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // lbOutText
            // 
            this.lbOutText.AutoSize = true;
            this.lbOutText.Location = new System.Drawing.Point(13, 319);
            this.lbOutText.Name = "lbOutText";
            this.lbOutText.Size = new System.Drawing.Size(89, 12);
            this.lbOutText.TabIndex = 27;
            this.lbOutText.Text = "车内视频时长：";
            // 
            // lbOut
            // 
            this.lbOut.AutoSize = true;
            this.lbOut.Location = new System.Drawing.Point(97, 319);
            this.lbOut.Name = "lbOut";
            this.lbOut.Size = new System.Drawing.Size(53, 12);
            this.lbOut.TabIndex = 29;
            this.lbOut.Text = "00:00:00";
            // 
            // lbInText
            // 
            this.lbInText.AutoSize = true;
            this.lbInText.Location = new System.Drawing.Point(13, 143);
            this.lbInText.Name = "lbInText";
            this.lbInText.Size = new System.Drawing.Size(89, 12);
            this.lbInText.TabIndex = 27;
            this.lbInText.Text = "车内视频时长：";
            // 
            // lbIn
            // 
            this.lbIn.AutoSize = true;
            this.lbIn.Location = new System.Drawing.Point(97, 143);
            this.lbIn.Name = "lbIn";
            this.lbIn.Size = new System.Drawing.Size(53, 12);
            this.lbIn.TabIndex = 28;
            this.lbIn.Text = "00:00:00";
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(350, 12);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(50, 25);
            this.btnDel.TabIndex = 30;
            this.btnDel.Text = "删除";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // pbOut
            // 
            this.pbOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbOut.Image = global::VideoApplication.Properties.Resources._out;
            this.pbOut.Location = new System.Drawing.Point(12, 180);
            this.pbOut.Name = "pbOut";
            this.pbOut.Size = new System.Drawing.Size(220, 124);
            this.pbOut.TabIndex = 23;
            this.pbOut.TabStop = false;
            this.pbOut.Click += new System.EventHandler(this.pbOut_Click);
            // 
            // pbIn
            // 
            this.pbIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbIn.Image = global::VideoApplication.Properties.Resources._in;
            this.pbIn.Location = new System.Drawing.Point(12, 12);
            this.pbIn.Name = "pbIn";
            this.pbIn.Size = new System.Drawing.Size(220, 124);
            this.pbIn.TabIndex = 22;
            this.pbIn.TabStop = false;
            this.pbIn.Click += new System.EventHandler(this.pbIn_Click);
            // 
            // SettingForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(751, 495);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.lbOut);
            this.Controls.Add(this.lbIn);
            this.Controls.Add(this.lbOutText);
            this.Controls.Add(this.lbInText);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.btnAddRow);
            this.Controls.Add(this.pbOut);
            this.Controls.Add(this.pbIn);
            this.Controls.Add(this.btnSetting);
            this.Controls.Add(this.dataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MinimizeBox = false;
            this.Name = "SettingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "隐藏设置";
            this.Load += new System.EventHandler(this.SettingForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbIn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSetting;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.PictureBox pbIn;
        private System.Windows.Forms.PictureBox pbOut;
        private System.Windows.Forms.Button btnAddRow;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Label lbOutText;
        private System.Windows.Forms.Label lbOut;
        private System.Windows.Forms.Label lbInText;
        private System.Windows.Forms.Label lbIn;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.DataGridViewTextBoxColumn sort;
        private System.Windows.Forms.DataGridViewComboBoxColumn videotype;
        private System.Windows.Forms.DataGridViewTextBoxColumn stime;
        private System.Windows.Forms.DataGridViewTextBoxColumn duration;
        private System.Windows.Forms.DataGridViewLinkColumn play;

    }
}