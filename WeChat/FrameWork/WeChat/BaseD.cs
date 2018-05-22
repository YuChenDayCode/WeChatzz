﻿using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
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
            string url = "https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid=" + appid + "&secret=" + appSecret;
            string result = HttpHelp.Get(url);
            if (result.Contains("errcode")) WeChatExtensions.ErrorMsg(result);

            XDocument xml = JsonConvert.DeserializeXNode(result, "root");
            XElement root = xml.Root;
            if (root != null)
            {
                XElement access_token = root.Element("access_token");
                if (access_token != null)
                {
                    //AccessToken_Time = DateTime.Now;
                    if (root.Element("expires_in") != null)
                    {
                        int Expires_Period = int.Parse(root.Element("expires_in").Value);
                        AccessToken_Time = DateTime.Now.AddSeconds(Expires_Period);
                    }
                    return access_token.Value;
                }
            }
            return null;
        }

        /// <summary>
        /// 是否过期
        /// </summary>
        /// <returns></returns>
        private static bool HasExpired()
        {
            if (AccessToken_Time != null)
            {
                if (DateTime.Now > AccessToken_Time.AddSeconds(-30))
                {
                    return true;
                }
            }
            return false;
        }




        private static List<string> _UserList;
        public static List<string> UserList
        {
            get
            {
                _UserList = GetUserList();
                return _UserList;
            }
        }
        public static List<string> GetUserList()
        {
            string url = "https://api.weixin.qq.com/cgi-bin/user/get?access_token=" + BaseD.AccessToken + "&next_openid=";
            string result = HttpHelp.Get(url);
            if (result.Contains("errcode")) WeChatExtensions.ErrorMsg(result);

            var obj = (Dictionary<string, Object>)new JavaScriptSerializer().DeserializeObject(result);
            var objs = JsonConvert.DeserializeObject(result);
            XDocument xml = JsonConvert.DeserializeXNode(result, "root");
            XElement root = xml.Root;
            if (root != null)
            {
                XElement access_token = root.Element("data");
                if (access_token != null)
                    return null;
            }
            return null;
        }


    }
}