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
            string[] arr = Regex.Split(model.Content, @"[ :我]");
            if (arr.Count() < 2) return;
            string msg = arr[1];
            Executor(GetTime(model.Content), msg, model.ToUserName);
            //线程池
        }
        public int GetTime(string str)
        {
            string num = Regex.Replace(str, @"[^0-9]+", "");
            int ms = 0;
            Dictionary<string, int> dic = new Dictionary<string, int>();
            dic.Add("天", 24 * 60 * 60 * 1000);
            dic.Add("时", 60 * 60 * 1000);
            dic.Add("分", 60 * 1000);
            dic.Add("秒", 1 * 1000);

            foreach (string key in dic.Keys)
            {
                int point = str.IndexOf(key);
                if (point == -1) continue;
                ms = int.Parse(num) * dic[key];
                break;
            }
            return ms;
        }
        public void Executor(int num, string msg, string ToUserName)
        {
            if (num <= 0) return;

            new Thread(() =>
            {
                Thread.Sleep(num);
                string sss = MsgOperate.SendMsgToUser("提醒：" + msg);
            }).Start();

        }
    }
}
