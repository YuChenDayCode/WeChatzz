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
        /// 向特定用户发送信息
        /// </summary>
        /// <param name="user"></param>
        /// <param name="msgType"></param>
        /// <param name="msg"></param>
        public static void SendMsgToUser(string user, string msgType, string msg)
        {
            string url = "https://api.weixin.qq.com/cgi-bin/message/custom/send?access_token=" + AccessTokenEx.AccessToken;
            object data = new { touser = user, msgtype = msgType, text = new { content = msg } };
            string msgs = HttpHelp.Post(url, JsonConvert.SerializeObject(data));

            if (msgs.Contains("errcode")) WeChatExtensions.ErrorMsg(msgs);
        }

    }
}
