using FrameWork;
using FrameWork.WeChat;
using System;
using System.Configuration;
using System.IO;
using System.Text;
using System.Web.Mvc;

namespace WeChat.Controllers
{
    public class WxController : Controller
    {

        public ActionResult Index()
        {
            string MethodType = Request.HttpMethod;
            SendXX(MethodType + "\n" + System.Web.HttpContext.Current.Request.UserHostAddress + "\n" + DateTime.Now);

            if (MethodType == "POST")
            {
                using (Stream stream = Request.InputStream)
                {
                    Byte[] postBytes = new Byte[stream.Length];
                    stream.Read(postBytes, 0, (Int32)stream.Length);
                    string postString = Encoding.UTF8.GetString(postBytes);
                    SendXX("POST内容：" + postString);
                    //Handle(postString);
                }
            }
            else
                CheckToken();

            return View();
        }

        public JsonResult One()
        {
            string msg = AccessTokenEx.AccessToken + "\n";
            //string aa = AccessTokenEx.AccessToken;
            // msg = MsgOperate.SendMsgToUser("oYvF3wfb3OuIeRJn-WenX1yy-VZ8", "text", "Yes!");

            return Json(msg, JsonRequestBehavior.AllowGet);
        }


        public void CheckToken()
        {
            string Token = "testToken";

            string echoString = Request.QueryString["echoStr"];
            string signature = Request.QueryString["signature"];
            string timestamp = Request.QueryString["timestamp"];
            string nonce = Request.QueryString["nonce"];

            if (!string.IsNullOrEmpty(echoString) && echoString == Token)
            {
                Response.Write(echoString);
                Response.End();
            }
        }

        public string SendXX(string msg)
        {
            return MsgOperate.SendMsgToUser("oYvF3wfb3OuIeRJn-WenX1yy-VZ8", MsgType.text.ToString(), msg);
        }

    }
}