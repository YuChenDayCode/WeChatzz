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
    public class UserInfoModel: ErrModel
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

}
