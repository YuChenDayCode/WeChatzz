using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WeChat.App_Start
{
    public class ActionFilter : ActionFilterAttribute, IExceptionFilter
    {
        public ActionFilter()
        {

        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var parameter = filterContext.ActionDescriptor.GetParameters();
            string action = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName.ToString() + "->" + filterContext.ActionDescriptor.ActionName.ToString();

            Common.WriteLog(JsonConvert.SerializeObject(new { Action = action, Parament = parameter }));
        }


        public void OnException(ExceptionContext filterContext)
        {
            Common.WriteLog(JsonConvert.SerializeObject(filterContext));
        }



    
    }
}