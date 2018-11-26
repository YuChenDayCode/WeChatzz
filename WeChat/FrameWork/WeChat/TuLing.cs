using FrameWork.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameWork.WeChat
{
    public class TuLing
    {

        public static string tuling_reply(string msg)
        {
            string apiUr = "http://www.tuling123.com/openapi/api";
            var para = new { key = "8edce3ce905a4c1dbb965e6b35c3834d", info = msg, userid = "wechat-robot" };
            string result = Task.Run(() => HttpHelp.Post(apiUr, JsonConvert.SerializeObject(para))).Result;
            var data = JsonConvert.DeserializeObject<CodeModel>(result);
            if (data.code == 100000)
                return data.text;
            else
                return "听不懂！要不你换个问法？？...";
        }



    }
}
