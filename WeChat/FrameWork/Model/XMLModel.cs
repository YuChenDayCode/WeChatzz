using FrameWork.WeChat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameWork.Model
{
    public class XMLModel
    {
        public string ToUserName { get; set; }

        public string FromUserName { get; set; }

        private string _CreateTime;
        public string CreateTime
        {
            get { return _CreateTime; }
            set
            {
                _CreateTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1)).AddSeconds(double.Parse(value)).ToString("yyyy/MM/dd HH:mm:ss");
            }
        }
        public string MsgType { get; set; }
        public string Content { get; set; }
        public string MsgId { get; set; }

        public string Event { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Precision { get; set; }


        public override string ToString()
        {
            return $"{this.CreateTime }\n 接收者：{this.ToUserName} \n 消息类型：{   Enum.GetName(typeof(MsgType), this.MsgType) } \n 消息内容：{ this.Content}";
        }


        //        <xml><ToUserName><![CDATA[gh_1e97e77b3af7]]></ToUserName>
        //<FromUserName><![CDATA[oYvF3wfb3OuIeRJn-WenX1yy-VZ8]]></FromUserName>
        //<CreateTime>1525885960</CreateTime>
        //<MsgType><![CDATA[event]]></MsgType>
        //<Event><![CDATA[LOCATION]]></Event>
        //<Latitude>30.179899</Latitude>
        //<Longitude>120.190598</Longitude>
        //<Precision>30.000000</Precision>
        //</xml>
    }
}
