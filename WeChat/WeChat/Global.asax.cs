using FrameWork;
using FrameWork.WeChat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WeChat
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            try
            {
                Random rd = new Random();
                Timer t = new Timer(delegate
                {
                    Common.WriteLog("Timer Working！！");
                    string[] tip = { "_(:з」∠)_ 打卡了吗", "打卡了吗！？ \n\n打卡了吗！？", "该回家咯！打卡了吗", "今天你打卡了吗？", "记得打卡！", "打卡。", "打卡~", "打卡！", "打卡o(╯□╰)o", "打卡(*^▽^*)" };
                    if (DateTime.Now.Hour == 17 && DateTime.Now.Minute == 32)
                    {
                        string isWorkDay = HttpHelp.Get("http://tool.bitefu.net/jiari/?d=" + DateTime.Now.ToString("yyyyMMdd"));
                        if (isWorkDay == "0")
                        {
                            MsgOperate.SendMsgToUser(tip[rd.Next(tip.Length)] + "一 " + DateTime.Now.ToString("HH:mm:ss"));
                            MsgOperate.SendMsgToUser(tip[rd.Next(tip.Length)] + "一 " + DateTime.Now.ToString("HH:mm:ss"), "oYvF3waO8ofEg8ZNb9_oxwHyo4uw");
                        }
                    }
                }, null, 0, 60000);
            }
            catch (Exception ex) { Common.WriteLog($"提醒异常！=> { ex.Message }-{DateTime.Now.ToString("yyyyMMdd HH:mm:ss")}"); }
        }
        protected void Application_End()
        {
            Common.WriteLog("IIS回收了！！！！！！");
        }
    }
}
