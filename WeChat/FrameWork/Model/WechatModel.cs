using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameWork.Model
{
    public class ErrModel
    {
        public int Errcode { get; set; }

        public string Errmsg { get; set; }
    }

    public class CodeModel
    {
        public int code { get; set; }

        public string text { get; set; }
    }

    public class AccessTokenModel
    {
        /// <summary>
        /// 获取到的凭证
        /// </summary>
        public string Access_Token { get; set; }
        /// <summary>
        /// 凭证有效时间，单位：秒
        /// </summary>
        public int Expires_in { get; set; }

        public DateTime ExpiresTime { get; set; }

        public int Errcode { get; set; }

        public string Errmsg { get; set; }
    }

    public class UserInfoModel : ErrModel
    {
        public int total { get; set; }

        public int count { get; set; }

        public user data { get; set; }

        public string next_openid { get; set; }

    }
    public class user
    {
        public List<string> openid { get; set; }
    }

    public class DetailUserInfo
    {
        public List<user_info_list> user_info_list { get; set; }
    }
    public class user_info_list
    {
        public string subscribe { get; set; }
        public string openid { get; set; }
        public string nickname { get; set; }
        public string sex { get; set; }
        public string language { get; set; }
        public string city { get; set; }
        public string province { get; set; }
        public string country { get; set; }
        public string headimgurl { get; set; }
        public string subscribe_time { get; set; }
        public string remark { get; set; }
        public string groupid { get; set; }
        public List<string> tagid_list { get; set; }
        public string subscribe_scene { get; set; }
        public string qr_scene { get; set; }
        public string qr_scene_str { get; set; }
    }

}
