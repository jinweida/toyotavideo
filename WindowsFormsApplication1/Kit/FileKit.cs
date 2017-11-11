using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.IO;
using Newtonsoft.Json;
using VideoApplication.Models;
using System.Threading;

namespace VideoApplication.Kit
{
    class FileKit
    {
        public static string settingPath = @"config\setting.json";
        public static string ftpPath = @"config\ftp.json";
        public static string dataPath = @"ffmpeg\data";
        public static string select(string title)
        {
            string filename = "";
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = false;
            fileDialog.Title = title;
            fileDialog.Filter = "视频文件|*.mp4;*.mov;*.mkv;*.rmvb";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string[] names = fileDialog.FileNames;

                foreach (string file in names)
                {
                    filename = file;
                }
            }
            return filename;
        }
        public static string selectPic(string title)
        {
            string filename = "";
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = false;
            fileDialog.Title = title;
            fileDialog.Filter = "图片文件|*.jpg;*.png;*.jpeg;*.bmp";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string[] names = fileDialog.FileNames;

                foreach (string file in names)
                {
                    filename = file;
                }
            }
            return filename;
        }
        public static bool isexist(string path)
        {
            return File.Exists(path);
        }
        public static string getData(string path){
            if (!isexist(path)) return string.Empty;
            using (StreamReader reader = new StreamReader(path))
            {
                string text = reader.ReadToEnd();
                return text;
            }
        }

        public static void setData(List<SettingModel> data)
        {
            using (StreamWriter writer = new StreamWriter(settingPath))
            {
                writer.Write(JsonConvert.SerializeObject(data));
            }
        }
        public static void setData(string txt,string path)
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.Write(txt);
            }
        }
        static ReaderWriterLockSlim LogWriteLock = new ReaderWriterLockSlim();
        /// <summary>
        /// 写入文件
        /// </summary>
        /// <param name="txt"></param>
        /// <param name="path"></param>
        public static void createFile(string txt,string path)
        {
            try
            {
                LogWriteLock.EnterWriteLock();
                using (StreamWriter tw = new StreamWriter(path))
                {
                    tw.Write(txt);
                }
            }
            catch(Exception e)
            {

            }
            finally
            {
                LogWriteLock.ExitWriteLock();
            }
        }
    }
}
