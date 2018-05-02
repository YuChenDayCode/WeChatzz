using FrameWork;
using FrameWork.WeChat;
using System.Configuration;
using System.Web.Mvc;

namespace WeChat.Controllers
{
    public class WxController : Controller
    {

      
        public ActionResult Index()
        {
            string access_token = "1111";
            Response.Write("access_token=" + access_token);
            return View();
        }

        public JsonResult One()
        {
            // string url = "https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid=" + appid + "&secret=" + appSecret;

            string aa = AccessTokenEx.AccessToken;


            https://api.weixin.qq.com/cgi-bin/message/custom/send?access_token=ACCESS_TOKEN

            return Json(aa, JsonRequestBehavior.AllowGet);
        }

    }
}