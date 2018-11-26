using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameWork.WeChat
{ 
    public class MsgOperate
    {
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="user"></param>
        /// <param name="msgType"></param>
        /// <returns></returns>
        public static string SendMsgToUser(string msg, string user = "oYvF3wfb3OuIeRJn-WenX1yy-VZ8", string msgType = "text")
        {
            string url = "https://api.weixin.qq.com/cgi-bin/message/custom/send?access_token=" + BaseD.AccessToken;
            object xml = new { touser = user, msgtype = msgType, text = new { content = msg } };
            string msgs = Task.Run(() => HttpHelp.Post(url, JsonConvert.SerializeObject(xml))).Result;
            string log = WeChatExtensions.ErrorMsg(msgs);
            Common.WriteLog($"SendMsgToUser->{log}");
            return log;
        }


    }
}
