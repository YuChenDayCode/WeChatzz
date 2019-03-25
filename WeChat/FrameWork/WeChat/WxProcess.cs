using FrameWork.Model;
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
        public void TxtProcess(XMLModel model)
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
            MsgOperate.SendMsgToUser(msg, model.FromUserName);
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


    }
}
