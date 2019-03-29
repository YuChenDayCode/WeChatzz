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
        /// <summary>
        /// 接收人
        /// </summary>
        public string ToUserName { get; set; }

        /// <summary>
        /// 发送人
        /// </summary>
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
            var from_user_info = BaseD.UserList?.Where(t => t.openid == this.FromUserName)?.FirstOrDefault();
            var to_user_info = BaseD.UserList?.Where(t => t.openid == this.ToUserName)?.FirstOrDefault();
            if (this.MsgType == "event" && this.Event == "LOCATION")
                return $"{this.Latitude},{this.Longitude}";
            return $"{this.CreateTime }\n 发送者：{from_user_info?.nickname ?? "公众号" } \n 接收者：{to_user_info?.nickname ?? "公众号"} \n 消息类型：{   this.MsgType } \n 消息内容：{ this.Content}";
        }

    }

    public class Passive
    {
        public string ToUserName { get; set; }
        public string FromUserName { get; set; }
        public string CreateTime { get; set; }
        public string MsgType { get; set; }
        public string Content { get; set; }

        public override string ToString()
        {
            int CreateTime = (int)(DateTime.Now - TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1))).TotalSeconds;
            string recovery = $"<xml><ToUserName><![CDATA[{this.ToUserName}]]></ToUserName><FromUserName><![CDATA[{this.FromUserName}]]></FromUserName><CreateTime>{CreateTime}</CreateTime><MsgType><![CDATA[text]]></MsgType><Content><![CDATA[{this.Content}]]></Content></xml>";
            return recovery;
        }
    }


}
