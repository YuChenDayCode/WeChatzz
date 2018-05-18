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
            string url = "https://api.weixin.qq.com/cgi-bin/message/custom/send?access_token=" + AccessTokenEx.AccessToken;
            object xml = new { touser = user, msgtype = msgType, text = new { content = msg } };
            string msgs = HttpHelp.Post(url, JsonConvert.SerializeObject(xml));

            return WeChatExtensions.ErrorMsg(msgs);
        }

        /// <summary>
        /// 回复信息
        /// </summary>
        /// <param name="user"></param>
        /// <param name="msgType"></param>
        /// <param name="msg"></param>
        //public static string ReplyMsg(string msg, string FromUserName, string msgType = "text")
        //{
        //    string url = "https://api.weixin.qq.com/cgi-bin/message/custom/send?access_token=" + AccessTokenEx.AccessToken;
        //    object xml = new { ToUserName = FromUserName, FromUserName = FromUserName, CreateTime = (int)(DateTime.Now - new System.DateTime(1970, 1, 1)).TotalSeconds, Msgtype = msgType, Text = new { Content = msg }, MsgId = new Random().Next(100000) };

        //    string msgs = HttpHelp.Post(url, JsonConvert.SerializeObject(xml));

        //    return WeChatExtensions.ErrorMsg(msgs);
        //}
    }
}
