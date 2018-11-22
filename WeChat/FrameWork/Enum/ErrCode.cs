using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameWork.WeChat
{

    public enum ErrCode
    {
        请求成功 = 0,
        获取access_token时AppSecret错误或者access_token无效请开发者认真比对AppSecret的正确性或查看是否正在为恰当的公众号调用接口 = 40001,
        不合法的凭证类型 = 40002,
        不合法的OpenID请开发者确认OpenID_该用户是否已关注公众号或是否是其他公众号的OpenID = 40003,
        不合法的媒体文件类型 = 40004,
        不合法的文件类型 = 40005,
        不合法的文件大小 = 40006,
        不合法的媒体文件id = 40007,
        不合法的消息类型 = 40008,
        不合法的图片文件大小 = 40009,
        不合法的语音文件大小 = 40010,
        不合法的视频文件大小 = 40011,
        不合法的缩略图文件大小 = 40012,
        不合法的AppID请开发者检查AppID的正确性避免异常字符注意大小写 = 40013,
        不合法的access_token请开发者认真比对access_token的有效性_如是否过期或查看是否正在为恰当的公众号调用接口 = 40014,
        不合法的菜单类型 = 40015,
        不合法的按钮个数 = 40016,
        不合法的按钮个数1 = 40017,
        不合法的按钮名字长度 = 40018,
        不合法的按钮KEY长度 = 40019,
        不合法的按钮URL长度 = 40020,
        不合法的菜单版本号 = 40021,
        不合法的子菜单级数 = 40022,
        不合法的子菜单按钮个数 = 40023,
        不合法的子菜单按钮类型 = 40024,
        不合法的子菜单按钮名字长度 = 40025,
        不合法的子菜单按钮KEY长度 = 40026,
        不合法的子菜单按钮URL长度 = 40027,
        不合法的自定义菜单使用用户 = 40028,
        不合法的oauth_code = 40029,
        不合法的refresh_token = 40030,
        不合法的openid列表 = 40031,
        不合法的openid列表长度 = 40032,
        不合法的请求字符不能包含uxxxx格式的字符 = 40033,
        不合法的参数 = 40035,
        不合法的请求格式 = 40038,
        不合法的URL长度 = 40039,
        不合法的分组id = 40050,
        分组名字不合法 = 40051,
        删除单篇图文时指定的article_idx不合法 = 40060,
        分组名字不合法1 = 40117,
        media_id大小不合法 = 40118,
        button类型错误 = 40119,
        button类型错误1 = 40120,
        不合法的media_id类型 = 40121,
        微信号不合法 = 40132,
        不支持的图片格式 = 40137,
        请勿添加其他公众号的主页链接 = 40155,
        缺少access_token参数 = 41001,
        缺少appid参数 = 41002,
        缺少refresh_token参数 = 41003,
        缺少secret参数 = 41004,
        缺少多媒体文件数据 = 41005,
        缺少media_id参数 = 41006,
        缺少子菜单数据 = 41007,
        缺少oauthcode = 41008,
        缺少openid = 41009,
        access_token超时请检查access_token的有效期请参考基础支持获取access_token中对access_token的详细机制说明 = 42001,
        refresh_token超时 = 42002,
        oauth_code超时 = 42003,
        用户修改微信密码accesstoken和refreshtoken失效需要重新授权 = 42007,
        需要GET请求 = 43001,
        需要POST请求 = 43002,
        需要HTTPS请求 = 43003,
        需要接收者关注 = 43004,
        需要好友关系 = 43005,
        需要将接收者从黑名单中移除 = 43019,
        多媒体文件为空4 = 4001,
        POST的数据包为空4 = 4002,
        图文消息内容为空4 = 4003,
        文本消息内容为空4 = 4004,
        多媒体文件大小超过限制 = 45001,
        消息内容超过限制 = 45002,
        标题字段超过限制 = 45003,
        描述字段超过限制 = 45004,
        链接字段超过限制 = 45005,
        图片链接字段超过限制 = 45006,
        语音播放时间超过限制 = 45007,
        图文消息超过限制 = 45008,
        接口调用超过限制 = 45009,
        创建菜单个数超过限制 = 45010,
        API调用太频繁请稍候再试 = 45011,
        回复时间超过限制 = 45015,
        系统分组不允许修改 = 45016,
        分组名字过长 = 45017,
        分组数量超过上限 = 45018,
        客服接口下行条数超过上限 = 45047,
        不存在媒体数据 = 46001,
        不存在的菜单版本 = 46002,
        不存在的菜单数据 = 46003,
        不存在的用户 = 46004,
        解析JSON, XML内容错误 = 47001,
        api功能未授权, 请确认公众号已获得该接口, 可以在公众平台官网, 开发者中心页中查看接口权限 = 48001,
        粉丝拒收消息_粉丝在公众号选项中关闭了接收消息 = 48002,
        api接口被封禁请登录mpweixinqqcom查看详情 = 48004,
        api禁止删除被自动回复和自定义菜单引用的素材 = 48005,
        api禁止清零调用次数因为清零次数达到上限 = 48006,
        没有该类型消息的发送权限 = 48008,
        用户未授权该api = 50001,
        用户受限, 可能是违规后接口被封禁 = 50002,
        用户未关注公众号 = 50005,
        参数错误_invalidparameter = 61451,
        无效客服账号_invalidkf_account = 61452,
        客服帐号已存在_kf_accountexsited = 61453,
        客服帐号名长度超过限制_仅允许10个英文字符 = 61454,
        客服帐号名包含非法字符_仅允许英文数字 = 61455,
        客服帐号个数超过限制_10个客服账号_kf_accountcountexceeded = 61456,
        无效头像文件类型_invalidfiletype = 61457,
        系统错误_systemerror = 61450,
        日期格式错误 = 61500,
        不存在此menuid对应的个性化菜单 = 65301,
        没有相应的用户 = 65302,
        没有默认菜单不能创建个性化菜单 = 65303,
        MatchRule信息为空 = 65304,
        个性化菜单数量受限 = 65305,
        不支持个性化菜单的帐号 = 65306,
        个性化菜单信息为空 = 65307,
        包含没有响应类型的button = 65308,
        个性化菜单开关处于关闭状态 = 65309,
        填写了省份或城市信息国家信息不能为空 = 65310,
        填写了城市信息省份信息不能为空 = 65311,
        不合法的国家信息 = 65312,
        不合法的省份信息 = 65313,
        不合法的城市信息 = 65314,
        该公众号的菜单设置了过多的域名外跳_最多跳转到3个域名的链接 = 65316,
        不合法的URL = 65317,
        POST数据参数不合法 = 9001001,
        远端服务不可用 = 9001002,
        Ticket不合法 = 9001003,
        获取摇周边用户信息失败 = 9001004,
        获取商户信息失败 = 9001005,
        获取OpenID失败 = 9001006,
        上传文件缺失 = 9001007,
        上传素材的文件类型不合法 = 9001008,
        上传素材的文件尺寸不合法 = 9001009,
        上传失败 = 9001010,
        帐号不合法 = 9001020,
        已有设备激活率低于50不能新增设备 = 9001021,
        设备申请数不合法必须为大于0的数字 = 9001022,
        已存在审核中的设备ID申请 = 9001023,
        一次查询设备ID数量不能超过50 = 9001024,
        设备ID不合法 = 9001025,
        页面ID不合法 = 9001026,
        页面参数不合法 = 9001027,
        一次删除页面ID数量不能超过10 = 9001028,
        页面已应用在设备中请先解除应用关系再删除 = 9001029,
        一次查询页面ID数量不能超过50 = 9001030,
        时间区间不合法 = 9001031,
        保存设备与页面的绑定关系参数错误 = 9001032,
        门店ID不合法 = 9001033,
        设备备注信息过长 = 9001034,
        设备申请参数不合法 = 9001035,
        查询起始值begin不合法 = 9001036
    }

    public enum MsgType
    {
        [Description("文本")]
        text,

        [Description("图片")]
        image,

        [Description("语音")]
        voice,

        [Description("视频")]
        video,

        [Description("音乐")]
        music,

        [Description("图文，限制8条")]
        news,
        [Description("图文，限制8条")]
        mpnews,

        [Description("卡券")]
        wxcard,

        [Description("小程序")]
        miniprogram
    }

    public class ErrorCode
    {
        public string ReturnErrorMsg(string code)
        {
            switch (code)
            {
                case "-1": return "系统繁忙，此时请开发者稍候再试";
                case "0": return "请求成功";
                case "40001": return "获取 access_token 时 AppSecret 错误，或者 access_token 无效。请开发者认真比对 AppSecret 的正确性，或查看是否正在为恰当的公众号调用接口";
                case "40002": return "不合法的凭证类型";
                case "40003": return "不合法的 OpenID ，请开发者确认 OpenID （该用户）是否已关注公众号，或是否是其他公众号的 OpenID";
                case "40004": return "不合法的媒体文件类型";
                case "40005": return "不合法的文件类型";
                case "40006": return "不合法的文件大小";
                case "40007": return "不合法的媒体文件 id";
                case "40008": return "不合法的消息类型";
                case "40009": return "不合法的图片文件大小";
                case "40010": return "不合法的语音文件大小";
                case "40011": return "不合法的视频文件大小";
                case "40012": return "不合法的缩略图文件大小";
                case "40013": return "不合法的 AppID ，请开发者检查 AppID 的正确性，避免异常字符，注意大小写";
                case "40014": return "不合法的 access_token ，请开发者认真比对 access_token 的有效性（如是否过期），或查看是否正在为恰当的公众号调用接口";
                case "40015": return "不合法的菜单类型";
                case "40016": return "不合法的按钮个数";
                case "40017": return "不合法的按钮个数";
                case "40018": return "不合法的按钮名字长度";
                case "40019": return "不合法的按钮 KEY 长度";
                case "40020": return "不合法的按钮 URL 长度";
                case "40021": return "不合法的菜单版本号";
                case "40022": return "不合法的子菜单级数";
                case "40023": return "不合法的子菜单按钮个数";
                case "40024": return "不合法的子菜单按钮类型";
                case "40025": return "不合法的子菜单按钮名字长度";
                case "40026": return "不合法的子菜单按钮 KEY 长度";
                case "40027": return "不合法的子菜单按钮 URL 长度";
                case "40028": return "不合法的自定义菜单使用用户";
                case "40029": return "不合法的 oauth_code";
                case "40030": return "不合法的 refresh_toke n";
                case "40031": return "不合法的 openid 列表";
                case "40032": return "不合法的 openid 列表长度";
                case "40033": return "不合法的请求字符，不能包含 \\uxxxx 格式的字符";
                case "40035": return "不合法的参数";
                case "40038": return "不合法的请求格式";
                case "40039": return "不合法的 URL 长度";
                case "40050": return "不合法的分组 id";
                case "40051": return "分组名字不合法";
                case "40060": return "删除单篇图文时，指定的 article_idx 不合法";
                case "40117": return "分组名字不合法";
                case "40118": return "media_id 大小不合法";
                case "40119": return "button 类型错误";
                case "40120": return "button 类型错误";
                case "40121": return "不合法的 media_id 类型";
                case "40132": return "微信号不合法";
                case "40137": return "不支持的图片格式";
                case "40155": return "请勿添加其他公众号的主页链接";
                case "41001": return "缺少 access_token 参数";
                case "41002": return "缺少 appid 参数";
                case "41003": return "缺少 refresh_token 参数";
                case "41004": return "缺少 secret 参数";
                case "41005": return "缺少多媒体文件数据";
                case "41006": return "缺少 media_id 参数";
                case "41007": return "缺少子菜单数据";
                case "41008": return "缺少 oauth code";
                case "41009": return "缺少 openid";
                case "42001": return "access_token 超时，请检查 access_token 的有效期，请参考基础支持 - 获取 access_token 中，对 access_token 的详细机制说明";
                case "42002": return "refresh_token 超时";
                case "42003": return "oauth_code 超时";
                case "42007": return "用户修改微信密码， accesstoken 和 refreshtoken 失效，需要重新授权";
                case "43001": return "需要 GET 请求";
                case "43002": return "需要 POST 请求";
                case "43003": return "需要 HTTPS 请求";
                case "43004": return "需要接收者关注";
                case "43005": return "需要好友关系";
                case "43019": return "需要将接收者从黑名单中移除";
                case "44001": return "多媒体文件为空";
                case "44002": return "POST 的数据包为空";
                case "44003": return "图文消息内容为空";
                case "44004": return "文本消息内容为空";
                case "45001": return "多媒体文件大小超过限制";
                case "45002": return "消息内容超过限制";
                case "45003": return "标题字段超过限制";
                case "45004": return "描述字段超过限制";
                case "45005": return "链接字段超过限制";
                case "45006": return "图片链接字段超过限制";
                case "45007": return "语音播放时间超过限制";
                case "45008": return "图文消息超过限制";
                case "45009": return "接口调用超过限制";
                case "45010": return "创建菜单个数超过限制";
                case "45011": return "API 调用太频繁，请稍候再试";
                case "45015": return "回复时间超过限制";
                case "45016": return "系统分组，不允许修改";
                case "45017": return "分组名字过长";
                case "45018": return "分组数量超过上限";
                case "45047": return "客服接口下行条数超过上限";
                case "46001": return "不存在媒体数据";
                case "46002": return "不存在的菜单版本";
                case "46003": return "不存在的菜单数据";
                case "46004": return "不存在的用户";
                case "47001": return "解析 JSON/ XML 内容错误";
                case "48001": return "api 功能未授权，请确认公众号已获得该接口，可以在公众平台官网 - 开发者中心页中查看接口权限";
                case "48002": return "粉丝拒收消息（粉丝在公众号选项中，关闭了 “ 接收消息 ” ）";
                case "48004": return "api 接口被封禁，请登录 mp.weixin.qq.com 查看详情";
                case "48005": return "api 禁止删除被自动回复和自定义菜单引用的素材";
                case "48006": return "api 禁止清零调用次数，因为清零次数达到上限";
                case "48008": return "没有该类型消息的发送权限";
                case "50001": return "用户未授权该 api";
                case "50002": return "用户受限，可能是违规后接口被封禁";
                case "50005": return "用户未关注公众号";
                case "61451": return "参数错误(invalid parameter)";
                case "61452": return "无效客服账号(invalid kf_account)";
                case "61453": return "客服帐号已存在(kf_account exsited)";
                case "61454": return "客服帐号名长度超过限制(仅允许 10 个英文字符，不包括 @ 及 @ 后的公众号的微信号)(invalid kf_acount length)";
                case "61455": return "客服帐号名包含非法字符(仅允许英文 + 数字)(illegal character in kf_account)";
                case "61456": return "客服帐号个数超过限制(10 个客服账号)(kf_account count exceeded)";
                case "61457": return "无效头像文件类型(invalid file type)";
                case "61450": return "系统错误(system error)";
                case "61500": return "日期格式错误";
                case "65301": return "不存在此 menuid 对应的个性化菜单";
                case "65302": return "没有相应的用户";
                case "65303": return "没有默认菜单，不能创建个性化菜";
                case "65304": return "MatchRule 信息为空";
                case "65305": return "个性化菜单数量受限";
                case "65306": return "不支持个性化菜单的帐号";
                case "65307": return "个性化菜单信息为空";
                case "65308": return "包含没有响应类型的 button";
                case "65309": return "个性化菜单开关处于关闭状态";
                case "65310": return "填写了省份或城市信息，国家信息不能为空";
                case "65311": return "填写了城市信息，省份信息不能为空";
                case "65312": return "不合法的国家信息";
                case "65313": return "不合法的省份信息";
                case "65314": return "不合法的城市信息";
                case "65316": return "该公众号的菜单设置了过多的域名外跳（最多跳转到 3 个域名的链接）";
                case "65317": return "不合法的 URL";
                case "9001001": return " POST 数据参数不合法";
                case "9001002": return "远端服务不可用";
                case "9001003": return " Ticket 不合法";
                case "9001004": return " 获取摇周边用户信息失败";
                case "9001005": return " 获取商户信息失败";
                case "9001006": return "获取 OpenID 失败";
                case "9001007": return "上传文件缺失";
                case "9001008": return " 上传素材的文件类型不合法";
                case "9001009": return " 上传素材的文件尺寸不合法";
                case "9001010": return "上传失败";
                case "9001020": return " 帐号不合法";
                case "9001021": return " 已有设备激活率低于 50 % ，不能新增设备";
                case "9001022": return " 设备申请数不合法，必须为大于 0 的数字";
                case "9001023": return " 已存在审核中的设备 ID 申请";
                case "9001024": return " 一次查询设备 ID 数量不能超过 50";
                case "9001025": return "设备 ID 不合法";
                case "9001026": return "页面 ID 不合法";
                case "9001027": return " 页面参数不合法";
                case "9001028": return " 一次删除页面 ID 数量不能超过 10";
                case "9001029": return "页面已应用在设备中，请先解除应用关系再删除";
                case "9001030": return "一次查询页面 ID 数量不能超过 50";
                case "9001031": return " 时间区间不合法";
                case "9001032": return " 保存设备与页面的绑定关系参数错误";
                case "9001033": return " 门店 ID 不合法";
                case "9001034": return "设备备注信息过长";
                case "9001035": return " 设备申请参数不合法";
                case "9001036": return " 查询起始值 begin 不合法";
                default: return "没有找到具体错误信息";
            }
        }
    }
}
