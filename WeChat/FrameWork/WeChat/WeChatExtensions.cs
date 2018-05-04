using FrameWork.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameWork.WeChat
{
    public static class WeChatExtensions
    {
        public static string ErrorMsg(string errmsg)
        {
            ErrorModel model = JsonConvert.DeserializeObject<ErrorModel>(errmsg);
            string msg = new ErrorCode().ReturnErrorMsg(model.errcode);// Enum.GetName(typeof(ErrCode), model.errcode);
            return msg + "。\n详情" + errmsg;
        }
    }
}
