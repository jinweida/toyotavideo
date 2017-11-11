using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VideoApplication.Kit
{
    class TextKit
    {
        public static string sortText = "排序";
        public static string videoTypeText = "视频";
        public static string stimeText = "开始时间";
        public static string durationText = "时长";

        public static string videoInValue = "0";
        public static string videoIn = "车内";
        public static string videoOutValue = "1";
        public static string videoOut = "车外";

        public static string successMsg = "保存成功";
        public static string failMsg = "数据错误，请重新填写";
        public static string failTimeMsg = "时间格式错误";
        public static string failDurationMsg = "时长错误";
        public static string existMsg = "视频正在处理,请不要重复提交";
        public static string failMobileMsg = "手机号格式错误";

        public static string thrumnailNotFoundMsg = "缩略图未生成";

        public static string selectVideoText = "请选择车内视频文件";
        public static string noSelectMsg = "请选择要操作的行.";
            
        public static string selectImageText = "请选择车个性摆拍文件";
        public static string userDeleteRowMsg = "确认要删除该行数据吗？";

        public static string transStatusSuccess = "转码成功";
        public static string ftpStatusSuccess = "上传成功";
    }
}
