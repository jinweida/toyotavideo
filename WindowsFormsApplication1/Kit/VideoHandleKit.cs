using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace VideoApplication.Kit
{
    class VideoHandleKit
    {
        public static string ffmpegfile = System.IO.Directory.GetCurrentDirectory() + @"\ffmpeg\ffmpeg.exe";
        public static string ffplayfile = System.IO.Directory.GetCurrentDirectory() + @"\ffmpeg\ffplay.exe";
        /// <summary>
        /// 获取文件时长 ffmpeg -i a.mov
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string getDuration(string filePath)
        {
            string paramter = "-i " + filePath;
            // soon will hold our video's duration in the form "HH:MM:SS.UU" 
            string result = VideoHandleKit.execute(paramter);
            string duration = result.Substring(result.IndexOf("Duration: ") + ("Duration: ").Length, ("00:00:00").Length);
            return duration;
        }
        public static string getPrewPic(string filePath)
        {
            string prewPic = getDir(filePath).ToLower() + "/" + getFilename(filePath).ToLower() + ".jpg";
            string paramter = "-y -ss 5 -i " + filePath + " -f image2 -vframes 1 -s 220x124 " + prewPic;
            execute(paramter);
            return prewPic;
        }
        /// <summary>
        /// 获取文件所在目录
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string getDir(string filePath)
        {
            return System.IO.Path.GetDirectoryName(filePath);
        }
        public static string getFilename(string filePath)
        {
            return System.IO.Path.GetFileName(filePath);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourceFile"></param>
        /// <returns></returns>
        public static string execute(string paramter)
        {
            using (System.Diagnostics.Process ffmpeg = new System.Diagnostics.Process())
            {
                 
                String result;  // temp variable holding a string representation of our video's duration  
                StreamReader errorreader;  // StringWriter to hold output from ffmpeg  

                // we want to execute the process without opening a shell  
                ffmpeg.StartInfo.UseShellExecute = false;
                ffmpeg.StartInfo.CreateNoWindow = true;
                ffmpeg.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                ffmpeg.StartInfo.RedirectStandardError = true;
 
                ffmpeg.StartInfo.FileName = ffmpegfile; 
                ffmpeg.StartInfo.Arguments = paramter;

                ffmpeg.Start();
                errorreader = ffmpeg.StandardError;

                ffmpeg.WaitForExit();
 
                result = errorreader.ReadToEnd(); 

                return result;
            }
        }
        public static string execute(string path,string paramter)
        {
            using (System.Diagnostics.Process ffmpeg = new System.Diagnostics.Process())
            {

                String result;  // temp variable holding a string representation of our video's duration  
                StreamReader errorreader;  // StringWriter to hold output from ffmpeg  

                // we want to execute the process without opening a shell  
                ffmpeg.StartInfo.UseShellExecute = false;
                ffmpeg.StartInfo.CreateNoWindow = true;
                //ffmpeg.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                ffmpeg.StartInfo.RedirectStandardError = true;

                ffmpeg.StartInfo.FileName = path;
                ffmpeg.StartInfo.Arguments = paramter;

                ffmpeg.Start();
                errorreader = ffmpeg.StandardError;

                ffmpeg.WaitForExit();

                result = errorreader.ReadToEnd();

                return result;
            }
        }  
    }
}
