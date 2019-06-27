using FrameWork.Model;
using FrameWork.Redis;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace FrameWork.WeChat
{
    public class WxProcess
    {
        #region 文本处理
        public string TxtProcess(XMLModel model)
        {
            string msg = "";

            if (Regex.Match(model.Content, @"^(\d{3})$").Success)
                msg = GetBusInfo(model.Content);
            else if (model.Content.Length > 4 && model.Content.Substring(0, 4) == "/yys")
            {
                string ss = model.Content.Substring(4);
                msg = GetYYS(ss);
            }
            else
                msg = TuLing.tuling_reply(model.Content);

            model.Content = msg;
            return MsgOperate.PassiveRecovery(model);
        }


        public string GetBusInfo(string line)
        {
            string apiUr = $"http://47.99.211.28:8088/Bus/{line}";
            string result = HttpHelp.Get(apiUr);
            return result;
        }
        public string GetYYS(string ss)
        {
            string apiUr = $"http://47.99.211.28:8088/YYS/{ss}";
            string result = HttpHelp.Get(apiUr);
            return result;
        }


        #endregion


        public string WatchEvent(XMLModel model)
        {
            switch (model.Event)
            {
                case "subscribe":
                    RedisUtil.Instance.HashSet("WatchUser", model.FromUserName, JsonConvert.SerializeObject(new { NickName = "", WatchTime = model.CreateTime }));
                    BaseD.UserList.Clear();
                    Common.WriteLog($"{model.FromUserName} 关注了你");
                    Passive Reply = new Passive { Content = "您好！欢迎关注,有什么需求可以留言", FromUserName = model.ToUserName, ToUserName = model.FromUserName };
                    return Reply.ToString();
                case "unsubscribe":
                    RedisUtil.Instance.RemoveHashItem("WatchUser", model.FromUserName);
                    BaseD.UserList.Clear();
                    Common.WriteLog($"{model.FromUserName} 取消关注了你");
                    return "";
                default:
                    return "";
            }
        }

    }
}
