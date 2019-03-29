using FrameWork;
using FrameWork.Model;
using FrameWork.Redis;
using FrameWork.WeChat;
using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;
using System.Threading;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Linq;
using WeChat.App_Start;

namespace WeChat.Controllers
{
    public class WxController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            //SendXX(Request.HttpMethod + "-Get\n" + System.Web.HttpContext.Current.Request.UserHostAddress + "\n" + DateTime.Now);
            string echoString = Request.QueryString["echoStr"];
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
            Stream stream = new MemoryStream(ActionFilter.bytes);
            XDocument xml = XDocument.Load(stream);
            XMLModel model = XmlEX.ResolveXML(xml);
            try
            {
                string msg;//被动回复
                switch (model.MsgType)
                {
                    case "text":
                        msg = new WxProcess().TxtProcess(model);
                        Response.Write(msg);
                        break;

                    case "event":
                        msg = new WxProcess().WatchEvent(model);
                        Response.Write(msg);
                        break;

                    default:
                        Response.Write("success");
                        break;

                }
                Response.End();
            }
            catch (Exception ex)
            {
                string msg = ex.Message + "=>" + ex.InnerException;
                Common.WriteLog(msg);
            }
            return View();
        }

        public JsonResult One()
        {
            string msg = BaseD.AccessToken + "\n";

            //RedisUtil.Instance.Set<string>("ddd", "ccc", DateTime.Now.AddMinutes(4));
            //RedisUtil.Instance.Set<string>("ddd", "cc1c");

            //List<KeyValuePair<string, string>> KeyValuePair = new List<KeyValuePair<string, string>>();
            //KeyValuePair.Add(new KeyValuePair<string, string>("1", "1111"));
            //KeyValuePair.Add(new KeyValuePair<string, string>("2", "2222"));
            //RedisUtil.Instance.AddHashRange("hashlist", KeyValuePair);

            //RedisUtil.Instance.GetHashAll("hashlist");
            //RedisUtil.Instance.HashSet("hashs11et", "22", "2323");
            // aaabbbcc = RedisUtil.Instance.GetAllItemsFromList("us");

            return Json(msg, JsonRequestBehavior.AllowGet);
        }


    }
}