using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;  

namespace VideoApplication.Kit
{
    class ValidateKit
    {
        private static Regex RegNumber = new Regex("^[0-9]+$");
        /// <summary>
        /// 验证数字
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool isNumber(string data)
        {
            Match m = RegNumber.Match(data);
            return m.Success;
        }
        /// <summary>
        /// 验证时间格式
        /// </summary>
        /// <param name="StrSource"></param>
        /// <returns></returns>
        public static bool IsTime(string StrSource)
        {
            return Regex.IsMatch(StrSource, @"^((20|21|22|23|[0-1]?\d):[0-5]?\d:[0-5]?\d)$");
        }
        /// <summary>
        /// 验证手机号码是否合法
        /// </summary>
        /// <param name="str_handset"></param>
        /// <returns></returns>
        public static bool isMobile(string str_handset)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(str_handset, @"^1[3|4|5|7|8][0-9]\d{8}$");
        }

    }
}
