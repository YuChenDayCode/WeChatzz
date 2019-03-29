using FrameWork.Model;
using FrameWork.Redis;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Script.Serialization;
using System.Xml.Linq;

namespace FrameWork.WeChat
{
    /// <summary>
    /// AccessToken 衍生类
    /// </summary>
    public class BaseD
    {
        /// <summary>
        /// 有效时间
        /// </summary>
        private static DateTime AccessToken_Time;

        private static string appid = ConfigurationManager.AppSettings["appId"];
        private static string appSecret = ConfigurationManager.AppSettings["appSecret"];

        private static string _AccessToken;

        #region 获取token
        public static string AccessToken
        {
            get
            {
                if (string.IsNullOrEmpty(_AccessToken) || HasExpired())
                {
                    _AccessToken = GetAccess_token();
                }
                return _AccessToken;
            }
        }


        /// <summary>
        /// 获取Access_token
        /// </summary>
        /// <returns></returns>
        public static string GetAccess_token()
        {
            string token = RedisUtil.Instance.Get<string>("token");
            if (!string.IsNullOrEmpty(token)) return token;


            string url = "https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid=" + appid + "&secret=" + appSecret;
            string result = HttpHelp.Get(url);

            var data = JsonConvert.DeserializeObject<AccessTokenModel>(result);
            if (data.Errcode == 0)
            {
                AccessToken_Time = DateTime.Now.AddSeconds(data.Expires_in);
                RedisUtil.Instance.Set<string>("token", data.Access_Token, DateTime.Now.AddSeconds(7200));
                return data.Access_Token;
            }
            else
            {
                string msg = ErrorCode.ReturnErrorMsg(data.Errcode + "") + "， " + data.Errmsg;
                Common.WriteLog($"GetAccess_token -> { msg }");
                throw new Exception(msg); //中断
            }
        }

        /// <summary>
        /// 是否过期
        /// </summary>
        /// <returns></returns>
        private static bool HasExpired()
        {
            if (AccessToken_Time != null)
            {
                if (DateTime.Now > AccessToken_Time)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion


        private static List<user_info_list> _UserList;
        #region 获取关注用户
        public static List<user_info_list> UserList
        {
            get
            {
                if (_UserList == null || _UserList?.Count() <= 0)
                    _UserList = GetUserList();
                return _UserList;
            }
        }
        public static List<user_info_list> GetUserList()
        {
            List<user_info_list> list = new List<user_info_list>();
            var dic = RedisUtil.Instance.GetHashAll("WatchUser");
            dic.ForEach((key, value) =>
            {
                JObject detail = JObject.Parse(value);
                list.Add(new user_info_list
                {
                    openid = key,
                    nickname = detail["NickName"].ToString(),
                    subscribe_time = detail["WatchTime"].ToString()
                });
            });
            Common.WriteLog($"GetUserList -> 获取用户详情成功！总关注用户 {list.Count()} ");
            return list;
            ////直接从缓存中取，没有api权限
            //string url = "https://api.weixin.qq.com/cgi-bin/user/get?access_token=" + AccessToken + "&next_openid=";
            //string result = HttpHelp.Get(url);
            //JObject jobject = JObject.Parse(result);
            ////var data = JsonConvert.DeserializeObject<UserInfoModel>(result);
            //if (!jobject.ContainsKey("errcode"))
            //{
            //    var openid_list = jobject["data"]["openid"].ToList();
            //    var para = new { user_list = new ArrayList() };
            //    openid_list.ForEach(f => { para.user_list.Add(new { openid = f.ToString() }); });

            //    url = "https://api.weixin.qq.com/cgi-bin/user/info/batchget?access_token=" + AccessToken; //根据openID获取详细信息
            //    result = HttpHelp.Post(url, JsonConvert.SerializeObject(para));
            //    DetailUserInfo userinfo = JsonConvert.DeserializeObject<DetailUserInfo>(result);
            //    Common.WriteLog($"GetUserList -> 获取用户详情成功！总关注用户 {openid_list.Count()} ,获取详情 {userinfo.user_info_list.Count()} ");
            //    return userinfo.user_info_list;
            //}
            //else
            //{
            //    Common.WriteLog($"GetUserList -> {ErrorCode.ReturnErrorMsg(jobject["errcode"] + "," + ErrorCode.ReturnErrorMsg(jobject["errcode"].ToString()))}");
            //    //通过redis读取已有的

            //}
        }

        #endregion


    }
}
