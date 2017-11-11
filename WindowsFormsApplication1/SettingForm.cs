using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using VideoApplication.Kit;
using VideoApplication.Models;
using System.Threading;
using Newtonsoft.Json;

namespace VideoApplication
{
    public partial class SettingForm : Form
    {
        /**
         * ffplay.exe -autoexit C:\video\WindowsFormsApplication1\bin\Debug\ffmpeg\output\34.mp4
         * ffplay -window_title "Hello World" -ss 20 -t 10 -autoexit output.mp4
         * 问题列表
            1、软件崩溃：在以下几种情况出现崩溃。
            --①选择视频时候，选择了非视频文件。
            --②选择图片时候，选择了非图片文件。
            --③选择图片时候，选择了dng格式图片，目前不确认是因为格式支持还是图片大小导致崩溃。
            --④软件开启后，输出了两个视频后，点击选择视频按钮崩溃，很难复现。
            总体来说目前软件稳定性还需要改进，崩溃情况出现过多。崩溃信息请见本文末尾的参考。
            建议改进方案：
                --判断选择视频文件必须是 mp4
                --图片文件必须是 jpg
                --否则提示非法文件

            2、目前的音轨文件过短，导致超出20秒的视频没有声音，请替换一条1分钟以上的音轨进行测试。
            建议改进方案：
                1.如果队列有等待转码文件，禁止修改配置
                2.提供一段足够长的mp3，每次保存配置文件时，根据配置文件合成视频总长度，截取mp3用于合成背景音乐

            3、设置里边的“预览”会导致整个软件卡死或者无法预览，请尽快修复。
            建议改进方案：
                检查一下ffplay脚本， 尝试将参数 -ss “开始时间”  放在参数  -i “输入视频”  前面

            未完成功能项
            --1、设置里的排序和增删功能无效，目前虽然可以修改时间，但是并没有真的起作用。
            --2、设置里的“上移”“下移”会造成软件崩溃。
            --3、视频提交后，软件转录时候，整个软件会卡死无法操作，需要等待转录完成才可以继续操作。请修改一下，以便可以在转录的同时进行操作。
            4、转码完成后，关闭软件重新打开的话，未上传的视频也会消失，整个工作列表都会被清空。请不要清空工作列表。以便工作人员继续之前的操作。
            --5、ftp上传功能
            --6、日志上传功能
            7、打开软件，打开设置界面提示输入密码，界面右上角密码锁定按键
            给我一个时间排期
         **/
        public string pbInPath;
        public string pbOutPath;
        public string pbVideoInPath;
        public string pbVideoOutPath;
        public SettingForm()
        {
            InitializeComponent();
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (string.IsNullOrEmpty(this.pbVideoInPath))
            {
                MessageBox.Show("请选择车内视频", "操作提示");
                return;
            }
            if (string.IsNullOrEmpty(this.pbVideoOutPath))
            {
                MessageBox.Show("请选择车外视频", "操作提示");
                return;
            }
            if (e.ColumnIndex == 4)
            {
                string stime = Convert.ToString(dataGridView.Rows[e.RowIndex].Cells[2].Value);
                string duration = Convert.ToString(dataGridView.Rows[e.RowIndex].Cells[3].Value);
                string playPath = "";
                int code = 0;
                if (!ValidateKit.IsTime(stime))
                {
                    code = 1;
                }
                if (!ValidateKit.isNumber(duration))
                {
                    code = 2;
                }
                if (code == 0)
                {
                    string videoType =Convert.ToString(dataGridView.Rows[e.RowIndex].Cells[1].Value);
                    //播放车外视频
                    if (videoType == TextKit.videoOutValue)
                    {
                        playPath = this.pbVideoOutPath;
                    }
                    if (videoType == TextKit.videoInValue)
                    {
                        playPath = this.pbVideoInPath;
                    }
                    
                    //播放器
                    string paramter = string.Format("-ss {0} -t {1} -threads 1 -x 640 -y 480 -autoexit -i {2}", stime, duration, playPath);

                    //VideoHandleKit.execute(VideoHandleKit.ffplayfile, paramter);
                    //axWindowsMediaPlayer1.URL = playPath;
                    //axWindowsMediaPlayer1.Ctlcontrols.play();//播放文件
                    PlayForm play = new PlayForm(stime, duration, playPath);
                    play.ShowDialog();
                }
                else
                {
                    if (code == 1)
                    {
                        MessageBox.Show(TextKit.failTimeMsg, "操作提示");
                    }
                    if (code == 2)
                    {
                        MessageBox.Show(TextKit.failDurationMsg, "操作提示");
                    }
                }
            }
        }

        /// <summary>
        /// 选择车内视频
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbIn_Click(object sender, EventArgs e)
        {
            string title = TextKit.selectVideoText;
            //获取文件路路径
            string videoPath = FileKit.select(title);
            if (string.IsNullOrEmpty(videoPath)) return;
            string prewPic=VideoHandleKit.getPrewPic(videoPath);
            this.pbVideoInPath = videoPath;
            if(FileKit.isexist(prewPic))this.pbIn.Load(prewPic);
            else
            {
                MessageBox.Show(TextKit.thrumnailNotFoundMsg, "操作提示");
            }
            lbIn.Text = VideoHandleKit.getDuration(videoPath);

        }
        /// <summary>
        /// 选择车外视频
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbOut_Click(object sender, EventArgs e)
        {
            string title = TextKit.selectVideoText;
            //获取文件路路径
            string videoPath = FileKit.select(title);
            if (string.IsNullOrEmpty(videoPath)) return;
            string prewPic = VideoHandleKit.getPrewPic(videoPath);
            this.pbVideoOutPath = videoPath;
            if (FileKit.isexist(prewPic)) this.pbOut.Load(prewPic);
            else
            {
                MessageBox.Show(TextKit.thrumnailNotFoundMsg, "操作提示");
            }
            lbOut.Text = VideoHandleKit.getDuration(videoPath);

        }
        /// <summary>
        /// 添加规则
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddRow_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            //排序
            DataGridViewTextBoxCell sort = new DataGridViewTextBoxCell();
            sort.Value = Convert.ToInt32(dataGridView.Rows.Count+1);
            row.Cells.Add(sort);

            //视频
            DataGridViewComboBoxCell comboxcell = new DataGridViewComboBoxCell();

            comboxcell.FlatStyle = FlatStyle.Flat;
            DataTable dt = new DataTable();
            dt.Columns.Add("value", System.Type.GetType("System.String"));
            dt.Columns.Add("text", System.Type.GetType("System.String"));
            DataRow dr = dt.NewRow();
            dr["value"] = TextKit.videoInValue;
            dr["text"] = TextKit.videoIn;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["value"] = TextKit.videoOutValue;
            dr["text"] = TextKit.videoOut;
            dt.Rows.Add(dr);

            comboxcell.DataSource = dt;
            comboxcell.DisplayMember = "text";
            comboxcell.ValueMember = "value";
            comboxcell.Value = "0";
            row.Cells.Add(comboxcell);

            DataGridViewTextBoxCell stime = new DataGridViewTextBoxCell();
            stime.Value = "";
            row.Cells.Add(stime);

            DataGridViewTextBoxCell etime = new DataGridViewTextBoxCell();
            etime.Value = "";
            row.Cells.Add(etime);


            DataGridViewLinkCell play = new DataGridViewLinkCell();

            play.Value = "播放";
            row.Cells.Add(play);


            dataGridView.Rows.Add(row);
        }
        private DataTable createSouce()//创建数据源  
        {
            DataTable dt = new DataTable();//创建DataTable对象  
            dt.Columns.Add(TextKit.sortText,System.Type.GetType("System.Int32"));
            dt.Columns.Add(TextKit.videoTypeText ,System.Type.GetType("System.String"));
            dt.Columns.Add(TextKit.stimeText, System.Type.GetType("System.String"));
            dt.Columns.Add(TextKit.durationText, System.Type.GetType("System.String"));
            for (int i = 0; i < 40; i++)
            {
                DataRow dr = dt.NewRow();//创建1行  
                dr[0] = i;//添加第一列数据  
                ComboBox cb = new ComboBox();
                cb.Items.Add(TextKit.videoIn);
                cb.Items.Add(TextKit.videoOut);
                dr[1] = cb;//添加第二列数据 
                dr[2] = i + 1;
                dr[3] = i+2;

                dt.Rows.Add(dr);//把行加入到；列表中       
            }
            return dt;
        }


        private void SettingForm_Load(object sender, EventArgs e)
        {
            List<SettingModel> data = JsonConvert.DeserializeObject<List<SettingModel>>(FileKit.getData(FileKit.settingPath));
            if (data == null) return;
            foreach(SettingModel m in data){
                DataGridViewRow row = new DataGridViewRow();
                //排序
                DataGridViewTextBoxCell sort = new DataGridViewTextBoxCell();
                sort.Value = Convert.ToInt32(m.sort);
                row.Cells.Add(sort);

                //视频
                DataGridViewComboBoxCell comboxcell = new DataGridViewComboBoxCell();
                comboxcell.FlatStyle = FlatStyle.Flat;
                DataTable dt = new DataTable();
                dt.Columns.Add("value", System.Type.GetType("System.String"));
                dt.Columns.Add("text", System.Type.GetType("System.String"));
                DataRow dr = dt.NewRow();
                dr["value"] = TextKit.videoInValue;
                dr["text"] = TextKit.videoIn;
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["value"] = TextKit.videoOutValue;
                dr["text"] = TextKit.videoOut;
                dt.Rows.Add(dr);

                comboxcell.DataSource = dt;
                comboxcell.DisplayMember = "text";
                comboxcell.ValueMember = "value";
                comboxcell.Value = m.type;
                row.Cells.Add(comboxcell);

                DataGridViewTextBoxCell stime = new DataGridViewTextBoxCell();
                stime.Value = m.stime;
                row.Cells.Add(stime);

                DataGridViewTextBoxCell duration = new DataGridViewTextBoxCell();
                duration.Value = m.duration;
                row.Cells.Add(duration);

                DataGridViewLinkCell play = new DataGridViewLinkCell();

                play.Value = "播放";
                row.Cells.Add(play);

                dataGridView.Rows.Add(row);
            }
        }
        /// <summary>
        /// 保存规则
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetting_Click(object sender, EventArgs e)
        {
            List<SettingModel> data = new List<SettingModel>();
            int code = 0;
            StringBuilder sb = new StringBuilder(@"@echo off"); 
            sb.Append("\r\n");
            sb.Append(VideoHandleKit.ffmpegfile);
            sb.Append("\r\n");

            string filelist = string.Empty;
            int totalDuration=0;
            foreach (DataGridViewRow m in dataGridView.Rows)
            {
                SettingModel model = new SettingModel();
                string sort = Convert.ToString(m.Cells["sort"].Value);
                string type = Convert.ToString(m.Cells["videotype"].Value);
                string stime = Convert.ToString(m.Cells["stime"].Value);
                string duration = Convert.ToString(m.Cells["duration"].Value);
                if (!ValidateKit.IsTime(stime))
                {
                    code = 1;
                    break;
                }
                if (!ValidateKit.isNumber(duration))
                {
                    code = 2;
                    break;
                }
                model.sort = sort;
                model.type = type;
                model.stime = stime;
                model.duration = duration;
                totalDuration+=Convert.ToInt32(model.duration);
                string paramter = "%2";
                //判断车内车外
                if (model.type == TextKit.videoOutValue)
                {
                    paramter = "%3";
                }
                string filename = "tmp/" + model.sort + ".ts";
                sb.Append("ffmpeg -y -ss " + model.stime + " -i " + paramter + " -t " + model.duration + " -vcodec copy -an tmp/t.mp4 -loglevel 16");
                sb.Append("\r\n");
                sb.Append("ffmpeg -y -i tmp/t.mp4 -b:v 1024k -s 1080x640 -f mpegts " + filename + " -loglevel 16");
                sb.Append("\r\n");
                if (!string.IsNullOrEmpty(filelist))
                {
                    filelist+="|";
                }
                filelist += filename;
                data.Add(model);

            }
            if (code == 0)
            {
                //保存文件
                FileKit.setData(data);
                
                //ffmpeg -y -ss 0 -i bg.mp3 -t 52 -acodec copy tmp/1.mp3 -loglevel 16
                sb.AppendFormat("ffmpeg -y -ss 0 -i bg.mp3 -t {0} -acodec copy tmp/b.mp3 -loglevel 16", totalDuration);
                sb.Append("\r\n");
                sb.Append("ffmpeg -y -i \"concat:" + filelist + "\" -i tmp/b.mp3 -c copy tmp/body.ts -loglevel 16");
                sb.Append("\r\n");
                sb.Append("ffmpeg -y -i \"concat:header.ts|tmp/body.ts|footer.ts\" -vcodec h264 tmp/finish.mp4 -loglevel 16");
                sb.Append("\r\n");
                sb.Append(@"move %CD%\tmp\finish.mp4  %CD%\output\%1.mp4");
                FileKit.setData(sb.ToString(), "ffmpeg/e.bat");

                MessageBox.Show(TextKit.successMsg,"操作提示");
                this.Hide();
            }
            else
            {
                MessageBox.Show(TextKit.failMsg, "操作提示");
            }
        }
        /// <summary>
        /// 删除选中行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count.Equals(0))
            {
                MessageBox.Show(TextKit.noSelectMsg);
                return;
            }
            if (MessageBox.Show(TextKit.userDeleteRowMsg, "删除确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                foreach (DataGridViewRow r in dataGridView.SelectedRows)
                {
                    if (!r.IsNewRow)
                    {
                        dataGridView.Rows.Remove(r);
                    }
                }
            }
        }

        private void dataGridView_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            // 删除前的用户确认。 
            if (MessageBox.Show(TextKit.userDeleteRowMsg, "删除确认",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
            {
                // 如果不是 OK，则取消。 
                
            }

        }
        /// <summary>
        /// 上移动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUp_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count.Equals(0))
            {
                MessageBox.Show(TextKit.noSelectMsg, "操作提示");
                return;
            }
            //upOrDown("up");
            int rowIndex = dataGridView.SelectedRows[0].Index;  //得到当前选中行的索引     

            if (rowIndex == 0)
            {
                MessageBox.Show("已经是第一行了!", "操作提示");
                return;
            }

            List<string> list = new List<string>();
            for (int i = 0; i < dataGridView.Columns.Count; i++)
            {
                list.Add(dataGridView.SelectedRows[0].Cells[i].Value.ToString());   //把当前选中行的数据存入list数组中     
            }

            for (int j = 0; j < dataGridView.Columns.Count; j++)
            {
                dataGridView.Rows[rowIndex].Cells[j].Value = dataGridView.Rows[rowIndex - 1].Cells[j].Value;
                dataGridView.Rows[rowIndex - 1].Cells[j].Value = list[j].ToString();
            }
            dataGridView.Rows[rowIndex - 1].Selected = true;
            dataGridView.Rows[rowIndex].Selected = false; 
        }
        /// <summary>
        /// 下移
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDown_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count.Equals(0))
            {
                MessageBox.Show(TextKit.noSelectMsg, "操作提示");
                return;
            }
            int rowIndex = dataGridView.SelectedRows[0].Index;  //得到当前选中行的索引     

            if (rowIndex == dataGridView.Rows.Count - 1)
            {
                MessageBox.Show("已经是最后一行了!", "操作提示");
                return;
            }

            List<string> list = new List<string>();
            for (int i = 0; i < dataGridView.Columns.Count; i++)
            {
                list.Add(dataGridView.SelectedRows[0].Cells[i].Value.ToString());   //把当前选中行的数据存入list数组中     
            }

            for (int j = 0; j < dataGridView.Columns.Count; j++)
            {
                dataGridView.Rows[rowIndex].Cells[j].Value = dataGridView.Rows[rowIndex + 1].Cells[j].Value;
                dataGridView.Rows[rowIndex + 1].Cells[j].Value = list[j].ToString();
            }
            dataGridView.Rows[rowIndex + 1].Selected = true;
            dataGridView.Rows[rowIndex].Selected = false;  
        }

    }
}
