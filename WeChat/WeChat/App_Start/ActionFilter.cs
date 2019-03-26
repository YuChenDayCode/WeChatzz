using FrameWork.Model;
using FrameWork.WeChat;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace WeChat.App_Start
{
    public class ActionFilter : ActionFilterAttribute, IExceptionFilter
    {
        public static byte[] bytes;
        public ActionFilter()
        {

        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var Request = filterContext.RequestContext.HttpContext.Request;
            var Response = filterContext.RequestContext.HttpContext.Response;
            //Response.Write("success"); Response.End();//避免三次请求

            Stream stream = Request.InputStream;
            XDocument xml = new XDocument();
            string msg = "";
            if (stream.Length > 0)
            {
                bytes = new byte[stream.Length]; //复制流到byte
                stream.Read(bytes, 0, bytes.Length);
                string aadaaa = System.Text.Encoding.Default.GetString(bytes);
                Stream new_stream = new MemoryStream(bytes);

                xml = XDocument.Load(new_stream);
                XMLModel model = XmlEX.ResolveXML(xml);
                msg = model.ToString();
            }
            var parameter = filterContext.ActionDescriptor.GetParameters();
            string action = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName.ToString() + " -> " + filterContext.ActionDescriptor.ActionName.ToString();

            Common.WriteLog(JsonConvert.SerializeObject(new { Action = action, Parament = msg }));
        }


        public void OnException(ExceptionContext filterContext)
        {
            string action = filterContext.RouteData.Values["controller"] + " -> " + filterContext.RouteData.Values["action"];
            string exmsg = "异常：=>>\r\n" + JsonConvert.SerializeObject(new { Action = action, Parament = filterContext.Exception.Message });
            Common.WriteLog(exmsg);
            MsgOperate.SendMsgToUser(exmsg);
        }



    }
}