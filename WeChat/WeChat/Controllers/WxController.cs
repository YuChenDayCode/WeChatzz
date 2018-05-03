using FrameWork;
using FrameWork.WeChat;
using System;
using System.Configuration;
using System.Web.Mvc;

namespace WeChat.Controllers
{
    public class WxController : Controller
    {


        public ActionResult Index()
        {
            CheckToken();
            return View();
        }

        public JsonResult One()
        {
            string aaa = Enum.GetName(typeof(ErrCode), 0);

            string aa = AccessTokenEx.AccessToken;
            MsgOperate.SendMsgToUser("oYvF3wfb3OuIeRJn-WenX1yy-VZ8", "text", "Yes!");

            return Json(aa, JsonRequestBehavior.AllowGet);
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

    }
}