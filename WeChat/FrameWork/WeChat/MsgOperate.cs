using FrameWork.Model;
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
        /// 被动回复
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="user"></param>
        /// <param name="msgType"></param>
        /// <returns></returns>
        public static string PassiveRecovery(XMLModel model)
        {
            Passive Reply = new Passive { Content = model.Content, FromUserName = model.ToUserName, ToUserName = model.FromUserName };
            return Reply.ToString();
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="user"></param>
        /// <param name="msgType"></param>
        /// <returns></returns>
        public static string SendMsgToUser(string msg, string user = "opcKtv_JgQYprmtuuDik7O5Xrz54", string msgType = "text")
        {
            string url = "https://api.weixin.qq.com/cgi-bin/message/custom/send?access_token=" + BaseD.AccessToken;
            object xml = new { touser = user, msgtype = msgType, text = new { content = msg } };

            string msgs = Task.Run(() => HttpHelp.Post(url, JsonConvert.SerializeObject(xml))).Result;
            string log = WeChatExtensions.ErrorMsg(msgs);

            string postlog = JsonConvert.SerializeObject(xml);
            var user_info = BaseD.UserList?.Where(t => t.openid == user)?.FirstOrDefault();
            if (user_info != null)
                postlog.Replace(user_info.openid, user_info.nickname);

            Common.WriteLog($"SendMsgToUser -> \r\n Para = {postlog} \r\n Result={log}");
            return log;
        }


    }
}
