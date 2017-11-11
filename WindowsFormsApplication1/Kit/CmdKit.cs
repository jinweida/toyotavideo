using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace VideoApplication.Kit
{
    class CmdKit
    {
        public static void RunCmd(string cmd)
        {
            //cmd = cmd.Trim().TrimEnd('&') + "&exit";//说明：不管命令是否成功均执行exit命令，否则当调用ReadToEnd()方法时，会处于假死状态
            //using (System.Diagnostics.Process p = new System.Diagnostics.Process())
            //{
            //    p.StartInfo.FileName = CmdPath;
            //    p.StartInfo.UseShellExecute = false;        //是否使用操作系统shell启动
            //    p.StartInfo.RedirectStandardInput = true;   //接受来自调用程序的输入信息
            //    p.StartInfo.RedirectStandardOutput = true;  //由调用程序获取输出信息
            //    p.StartInfo.RedirectStandardError = true;   //重定向标准错误输出
            //    p.StartInfo.CreateNoWindow = true;          //不显示程序窗口
            //    p.Start();//启动程序
 
            //    //向cmd窗口写入命令
            //    p.StandardInput.WriteLine(cmd);
            //    p.StandardInput.AutoFlush = true;
 
            //    //获取cmd窗口的输出信息
            //    output = p.StandardOutput.ReadToEnd();
            //    p.WaitForExit();//等待程序执行完退出进程
            //    p.Close();
            //}
            //ProcessStartInfo start = new ProcessStartInfo(VideoApplication.Kit.VideoHandleKit.ffmpegfile, "e.bat " + cmd);
            //using (System.Diagnostics.Process ffmpeg = new System.Diagnostics.Process())
            //{

            //    String result;  // temp variable holding a string representation of our video's duration  
            //    StreamReader errorreader;  // StringWriter to hold output from ffmpeg  

            //    // we want to execute the process without opening a shell  
            //    ffmpeg.StartInfo.UseShellExecute = true;
            //    //ffmpeg.StartInfo.CreateNoWindow = true;
            //    ffmpeg.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            //    ffmpeg.StartInfo.RedirectStandardError = true;

            //    ffmpeg.StartInfo.FileName = VideoApplication.Kit.VideoHandleKit.ffmpegfile;
            //    ffmpeg.StartInfo.Arguments = "e.bat " + cmd;

            //    ffmpeg.Start();
            //    errorreader = ffmpeg.StandardError;

            //    ffmpeg.WaitForExit();

            //    result = errorreader.ReadToEnd();
            //}
            Process proc = null;
            try
            {
                string targetDir = string.Format(System.IO.Directory.GetCurrentDirectory() + "\\ffmpeg");//this is where mybatch.bat lies
                proc = new Process();
                proc.StartInfo.WorkingDirectory = targetDir;
                proc.StartInfo.FileName = "e.bat";
                proc.StartInfo.Arguments = cmd;//this is argument
                proc.StartInfo.UseShellExecute = true;
                //proc.StartInfo.CreateNoWindow = true;
                proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                proc.Start();
                proc.WaitForExit();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Occurred :{0},{1}", ex.Message, ex.StackTrace.ToString());
            }
        }
    }
}
