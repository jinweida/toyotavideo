using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.NetworkInformation;

namespace VideoApplication.Kit
{
    class MacKit
    {
        #region 返回当前系统所启用的网络连接的信息
        public static NetworkInterface[] NetCardInfo()
        {
            return NetworkInterface.GetAllNetworkInterfaces();
        }
        #endregion



        public static string GetMacString()
        {
            string strMac = "";
            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface ni in interfaces)
            {
                if (ni.OperationalStatus == OperationalStatus.Up)
                {
                    if(!string.IsNullOrEmpty(ni.GetPhysicalAddress().ToString()))
                    {
                        strMac = ni.GetPhysicalAddress().ToString();
                    }


                }
            }
            return strMac;

        }
    }
}
