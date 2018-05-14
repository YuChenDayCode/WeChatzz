using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace FrameWork.WeChat
{
    public class WxProcess
    {
        public void TxtProcess(string content)
        {

            string msg = Regex.Split(content, @"[ :我]")[1];
            int time = GetTime(content);
            Executor(time, msg);
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
        public void Executor(int num,string msg)
        {
            new Thread(delegate ()
            {
                Thread.Sleep(num);
                MsgOperate.SendMsgToUser(msg);
            })
            {
                IsBackground = true
            }.Start();

        }
    }
}
