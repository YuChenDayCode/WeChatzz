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
            new Thread(delegate ()
            {
                while (true)
                {
                    Thread.Sleep(59 * 1000);
                    if (DateTime.Now.Hour == 20 && DateTime.Now.Minute == 1)
                    {
                        string isWork = HttpHelp.Get("http://tool.bitefu.net/jiari/?d=" + DateTime.Now.ToString("yyyyMMdd"));
                        if (isWork == "0") MsgOperate.SendMsgToUser("日报写了吗！！\n\n日报写了吗！！\n\n日报写了吗！！");
                    }
                }
            })
            {
                IsBackground = true
            }.Start();

        }
    }
}
