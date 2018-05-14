using FrameWork;
using FrameWork.Model;
using FrameWork.WeChat;
using System;
using System.Configuration;
using System.IO;
using System.Text;
using System.Web.Mvc;
using System.Xml.Linq;

namespace WeChat.Controllers
{
    public class WxController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            SendXX(Request.HttpMethod + "-Get\n" + System.Web.HttpContext.Current.Request.UserHostAddress + "\n" + DateTime.Now);

            string echoString = Request.QueryString["echoStr"];
            SendXX(echoString);
            if (!string.IsNullOrEmpty(echoString))
            {
                Response.Write(echoString);
                Response.End();
            }
            return View();
        }


        [HttpPost]
        [ActionName("Index")]
        public ActionResult IndexPost()
        {
            SendXX(Request.HttpMethod + "-Post\n" + System.Web.HttpContext.Current.Request.UserHostAddress + "\n" + DateTime.Now);
            XDocument xml = XDocument.Load(Request.InputStream);
            XMLModel model = XmlEX.ResolveXML(xml);
            SendXX(model.ToString());

         

            //Stream stream = Request.InputStream;
            //Byte[] postBytes = new Byte[stream.Length];
            //stream.Read(postBytes, 0, (Int32)stream.Length);
            //string postString = Encoding.UTF8.GetString(postBytes);
            //if (postString.Contains("[text]"))
            //{
            //    SendXX("发送内容：" + model.ToString());
            //}
            return View();
        }

        public JsonResult One()
        {
            string msg = AccessTokenEx.AccessToken + "\n";
            //string aa = AccessTokenEx.AccessToken;
            // msg = MsgOperate.SendMsgToUser("oYvF3wfb3OuIeRJn-WenX1yy-VZ8", "text", "Yes!");

            return Json(msg, JsonRequestBehavior.AllowGet);
        }




        public string SendXX(string msg)
        {
            return MsgOperate.SendMsgToUser("oYvF3wfb3OuIeRJn-WenX1yy-VZ8", MsgType.text.ToString(), msg);
        }

    }
}