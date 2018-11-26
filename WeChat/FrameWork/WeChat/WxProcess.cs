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
            string msg = TuLing.tuling_reply(model.Content);
            MsgOperate.SendMsgToUser(msg, model.FromUserName);
        }
    }
}
