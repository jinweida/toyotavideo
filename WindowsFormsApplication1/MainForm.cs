using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VideoApplication.Kit;
using System.IO;
using System.Threading;
using System.Net;
using System.Net.NetworkInformation;
using VideoApplication.Models;

using Newtonsoft.Json;
using System.Diagnostics;

namespace VideoApplication
{
    public partial class MainForm : Form
    {
        /**
         * http://www.cnblogs.com/enjoyprogram/p/3824040.html
         **/
        public string pbInPath;
        public string pbOutPath;
        public string pbPhotoPath;
        public MainForm()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// 隐藏设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetting_Click(object sender, EventArgs e)
        {
            //this.Hide();
            SettingLoginForm sf = new SettingLoginForm();
            sf.ShowDialog();
        }

        /// <summary>
        /// 立即提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string phone = txtPhone.Text;
            string date = txtDate.Text;

            if (string.IsNullOrEmpty(phone))
            {
                MessageBox.Show(TextKit.failMsg,"操作提示");
                return;
            }
            if (!ValidateKit.isMobile(phone))
            {
                MessageBox.Show(TextKit.failMobileMsg, "操作提示");
                return;
            }
            DataGridViewRow row = new DataGridViewRow();
            //排序
            DataGridViewTextBoxCell sort = new DataGridViewTextBoxCell();
            sort.Value = Convert.ToInt32(dataGridView.Rows.Count + 1);
            row.Cells.Add(sort);

            //手机号
            DataGridViewTextBoxCell phoneCell = new DataGridViewTextBoxCell();
            phoneCell.Value =phone;
            row.Cells.Add(phoneCell);

            DataGridViewTextBoxCell starttime = new DataGridViewTextBoxCell();
            starttime.Value = date;
            row.Cells.Add(starttime);


            DataGridViewTextBoxCell transcodeCell = new DataGridViewTextBoxCell();
            transcodeCell.Value = "等待转码";
            row.Cells.Add(transcodeCell);

            DataGridViewTextBoxCell upCell = new DataGridViewTextBoxCell();
            upCell.Value = "等待资源";
            row.Cells.Add(upCell);

            DataGridViewTextBoxCell inPathCell = new DataGridViewTextBoxCell();
            inPathCell.Value = this.pbInPath;
            row.Cells.Add(inPathCell);


            DataGridViewTextBoxCell outPathCell = new DataGridViewTextBoxCell();
            outPathCell.Value = this.pbOutPath;
            row.Cells.Add(outPathCell);

            dataGridView.Rows.Add(row);

            DataModel data = new DataModel();
            data.phone = phone;
            data.starttime = date;
            data.op = phone + " " + pbInPath + " " + pbOutPath;;
            data.sort = dataGridView.Rows.Count-1;
            //获取个人摆拍
            if (!string.IsNullOrEmpty(this.pbPhotoPath))
            {
                data.photo = this.pbPhotoPath;
                //copy个性摆拍
                System.IO.File.Copy(data.photo, System.IO.Directory.GetCurrentDirectory() + @"\ffmpeg\output\" + data.phone + ".jpg");
            }
            UploadDataModel m = new UploadDataModel();
            m.phone = data.phone;
            m.starttime = data.starttime;
            m.mac = MacKit.GetMacString();
            FileKit.createFile(JsonConvert.SerializeObject(m), System.IO.Directory.GetCurrentDirectory() + @"\ffmpeg\output\" + data.phone + ".json");

            txtPhone.Text = "";
            txtDate.Text = "";
            pbIn.Image = global::VideoApplication.Properties.Resources._in;
            pbOut.Image = global::VideoApplication.Properties.Resources._out;
            pbPhoto.Image = global::VideoApplication.Properties.Resources.image;
            this.pbInPath = "";
            this.pbOutPath = "";
            this.pbPhotoPath = "";

            wirteGridData();
            QueueKit.q.Enqueue(data);
            
        }
        public void setQueueData()
        {

        }
        public void wirteGridData()
        {

            //加入日志
            string d = DateTime.Now.ToString("yyyy-MM-dd");
            string dataPath = FileKit.dataPath+"\\"+ d + ".json";
            List<DataModel> list = new List<DataModel>();
            foreach (DataGridViewRow m in dataGridView.Rows)
            {
                string sort = Convert.ToString(m.Cells["sort"].Value);
                string phone = Convert.ToString(m.Cells["phone"].Value);
                string starttime = Convert.ToString(m.Cells["starttime"].Value);
                string inpath = Convert.ToString(m.Cells["inpath"].Value);
                string outpath = Convert.ToString(m.Cells["outpath"].Value);
                string transStatus = Convert.ToString(m.Cells["transStatus"].Value);
                string ftpStatus = Convert.ToString(m.Cells["ftpStatus"].Value);

                DataModel model = new DataModel();
                model.phone = phone;
                model.starttime = starttime;
                model.sort = Convert.ToInt32(sort);
                model.inpath = inpath;
                model.outpath = outpath;
                model.transStatus = transStatus;
                model.ftpStatus = ftpStatus;
               
                list.Add(model);
            }

            FileKit.createFile(JsonConvert.SerializeObject(list), dataPath);
        }
        public void monitorQueue()
        {
            Thread videoThread = new Thread(delegate()
            {
                while (1 > 0)
                {
                    if (QueueKit.q.Count > 0)
                    {
                        DataModel data = (DataModel)QueueKit.q.Dequeue();
                        string phonePath = "";
                        DataGridViewRow row = dataGridView.Rows[data.sort];

                        DataGridViewTextBoxCell phone = (DataGridViewTextBoxCell)row.Cells["phone"];
                        DataGridViewTextBoxCell transStatus = (DataGridViewTextBoxCell)row.Cells["transStatus"];
                        transStatus.Value = "转码中";
                        phonePath = phone.Value.ToString();
                        wirteGridData();

                        CmdKit.RunCmd(data.op);

                        transStatus.Value = TextKit.transStatusSuccess;
                        wirteGridData();
                        QueueKit.qftp.Enqueue(data);
                    }
                    Thread.Sleep(50);
                }
            });
            videoThread.Start();

            Thread ftpThread= new Thread(delegate()
            {
                while (1 > 0)
                {
                    if (QueueKit.qftp.Count > 0)
                    {
                        DataModel data = (DataModel)QueueKit.qftp.Dequeue();

                        DataGridViewRow row = dataGridView.Rows[data.sort];

                        DataGridViewTextBoxCell phone = (DataGridViewTextBoxCell)row.Cells["phone"];
                        DataGridViewTextBoxCell ftpStatus = (DataGridViewTextBoxCell)row.Cells["ftpStatus"];
                        ftpStatus.Value = "上传中";

                        wirteGridData();

                        List<FtpModel> ftp = JsonConvert.DeserializeObject<List<FtpModel>>(FileKit.getData(FileKit.ftpPath));
                        foreach(FtpModel m in ftp){
                            FtpKit.FtpServerIP = m.ftpip;
                            FtpKit.FtpUserID = m.ftpuser;
                            FtpKit.FtpPassword = m.ftppassword;
                            string path = System.IO.Directory.GetCurrentDirectory() + @"\ffmpeg\output\" + data.phone;
                            FtpKit.MakeDir(m.ftpdir + data.phone);

                            string mp4path=path + ".mp4";
                            FtpKit.FtpUploadBroken(mp4path, m.ftpdir + data.phone);
                            string jsonpath = path + ".json";
                            if (FileKit.isexist(jsonpath))
                            {
                                FtpKit.FtpUploadBroken(jsonpath, m.ftpdir + data.phone);
                            }
                            string jpgpath = path + ".jpg";
                            if (FileKit.isexist(jpgpath))
                            {
                                FtpKit.FtpUploadBroken(jpgpath, m.ftpdir + data.phone);
                            }                            
                        }

                        ftpStatus.Value = TextKit.ftpStatusSuccess;
                        wirteGridData();
                    }
                    Thread.Sleep(50);
                }
            });
            ftpThread.Start();           
        }
       

        public bool isExist(string phone)
        {
            bool result = false;
            foreach (DataGridViewRow m in dataGridView.Rows)
            {
                if (phone.Equals(Convert.ToString(m.Cells["phone"].Value)))
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        private void pbIn_Click(object sender, EventArgs e)
        {
            string title = TextKit.selectVideoText;
            //获取文件路路径
            string videoPath = FileKit.select(title);
            if (string.IsNullOrEmpty(videoPath)) return;
            pbInPath = videoPath;
            string prewPic = VideoHandleKit.getPrewPic(videoPath);
            if (FileKit.isexist(prewPic))this.pbIn.Load(prewPic);
            else
            {
                MessageBox.Show(TextKit.thrumnailNotFoundMsg);
            }
        }

        private void pbOut_Click(object sender, EventArgs e)
        {
            
            string title = TextKit.selectVideoText;
            //获取文件路路径
            string videoPath = FileKit.select(title);
            if (string.IsNullOrEmpty(videoPath)) return;
            pbOutPath = videoPath;
            string prewPic = VideoHandleKit.getPrewPic(videoPath);
            if (FileKit.isexist(prewPic)) this.pbOut.Load(prewPic);
            else
            {
                MessageBox.Show(TextKit.thrumnailNotFoundMsg);
            }
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lbIn_Click(object sender, EventArgs e)
        {

        }

        private void timerVideo_Tick(object sender, EventArgs e)
        {
            DirectoryInfo TheFolder = new DirectoryInfo("ffmpeg/output");
            foreach (FileInfo file in TheFolder.GetFiles())
            {
                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    DataGridViewRow row = dataGridView.Rows[i];

                    DataGridViewTextBoxCell phone = (DataGridViewTextBoxCell)row.Cells["phone"];
                    DataGridViewTextBoxCell transStatus = (DataGridViewTextBoxCell)row.Cells["transStatus"];
                    if ((phone.Value + ".mp4") == file.Name)
                    {
                        transStatus.Value = "转码成功"; 
  
                    }
                    
                }
            }

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            List<DataModel> data = JsonConvert.DeserializeObject<List<DataModel>>(FileKit.getData(FileKit.dataPath+"\\"+DateTime.Now.ToString("yyyy-MM-dd")+".json"));
            if (data != null)
            {
                foreach (DataModel m in data)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    //排序
                    DataGridViewTextBoxCell sort = new DataGridViewTextBoxCell();
                    sort.Value = m.sort;
                    row.Cells.Add(sort);

                    //手机号
                    DataGridViewTextBoxCell phoneCell = new DataGridViewTextBoxCell();
                    phoneCell.Value = m.phone;
                    row.Cells.Add(phoneCell);

                    DataGridViewTextBoxCell starttime = new DataGridViewTextBoxCell();
                    starttime.Value = m.starttime;
                    row.Cells.Add(starttime);


                    DataGridViewTextBoxCell transcodeCell = new DataGridViewTextBoxCell();
                    transcodeCell.Value = m.transStatus;
                    row.Cells.Add(transcodeCell);

                    DataGridViewTextBoxCell ftpCell = new DataGridViewTextBoxCell();
                    ftpCell.Value = m.ftpStatus;
                    row.Cells.Add(ftpCell);

                    DataGridViewTextBoxCell inPathCell = new DataGridViewTextBoxCell();
                    inPathCell.Value = m.inpath;
                    row.Cells.Add(inPathCell);


                    DataGridViewTextBoxCell outPathCell = new DataGridViewTextBoxCell();
                    outPathCell.Value = m.outpath;
                    row.Cells.Add(outPathCell);

                    dataGridView.Rows.Add(row);

                    DataModel dataQueueModel = new DataModel();
                    dataQueueModel.phone = m.phone;
                    dataQueueModel.starttime = m.starttime;
                    dataQueueModel.op = m.phone + " " + m.inpath + " " + m.outpath; ;
                    dataQueueModel.sort = m.sort-1;
                    //未转码成功,重新转码
                    if (m.transStatus != TextKit.transStatusSuccess)
                    {
                        //获取个人摆拍
                        if (!string.IsNullOrEmpty(m.photo))
                        {
                            //copy个性摆拍
                            System.IO.File.Copy(m.photo, System.IO.Directory.GetCurrentDirectory() + @"\ffmpeg\output\" + m.phone + ".jpg");
                        }
                        transcodeCell.Value = "等待转码";
                        ftpCell.Value = "等待资源";
                        QueueKit.q.Enqueue(dataQueueModel);
                    }
                    else
                    {
                        //未上传成功,重新上传
                        if (m.ftpStatus != TextKit.ftpStatusSuccess)
                        {
                            UploadDataModel uploadModel = new UploadDataModel();
                            uploadModel.phone = m.phone;
                            uploadModel.starttime = m.starttime;
                            uploadModel.mac = MacKit.GetMacString();
                            FileKit.createFile(JsonConvert.SerializeObject(m), System.IO.Directory.GetCurrentDirectory() + @"\ffmpeg\output\" + m.phone + ".json");

                            ftpCell.Value = "等待资源";
                            QueueKit.qftp.Enqueue(dataQueueModel);
                        }
                    }
                    
                }
            }
            
            monitorQueue();
        }

        private void pbPhoto_Click(object sender, EventArgs e)
        {
            string photoPath = FileKit.selectPic(TextKit.selectImageText);
            if (string.IsNullOrEmpty(photoPath)) return;
            this.pbPhotoPath = photoPath;
            this.pbPhoto.Load(photoPath);
        }
        /// <summary>
        /// 个性摆拍
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPhoto_Click(object sender, EventArgs e)
        {
            string photoPath = FileKit.selectPic(TextKit.selectImageText);
            if (string.IsNullOrEmpty(photoPath)) return;
            this.pbPhotoPath = photoPath;
            this.pbPhoto.Load(photoPath);

        }

        private void btnBlock_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm login = new LoginForm();
            login.Show();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Process[] processes;
            processes = Process.GetProcesses();
            string str = "";
            foreach (Process p in processes)
            {
                try
                {
                    str = p.ProcessName;
                    if(p.ProcessName.ToLower().Equals("ffmpeg.exe"))p.Kill();
                }
                catch (Exception ex)
                {
                    
                }
            }
        }

    }
}
