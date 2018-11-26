using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

public class Common
{
    /// <summary>
    /// 日志记录
    /// </summary>
    /// <param name="context"></param>
    public static void WriteLog(string context, bool hh = true)
    {
        ReaderWriterLockSlim loglock = new ReaderWriterLockSlim(); //线程读写锁
        try
        {
            loglock.EnterWriteLock();
            DateTime dt = DateTime.Now;
            using (StreamWriter sw = new StreamWriter(@"C:\\wxlog.txt", true))
            {
                sw.WriteLine($"========{DateTime.Now}===========");
                if (hh)
                    sw.WriteLine("=>" + context);
                else
                    sw.Write(context);
                sw.WriteLine(" ");
            }
        }
        catch (Exception ex)
        { }
        finally
        {
            loglock.ExitWriteLock();
        }
    }
    public string GetIp()
    {
        string userIP;
        HttpRequest Request = HttpContext.Current.Request;
        if (Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != "")
            userIP = Request.ServerVariables["REMOTE_ADDR"];
        else
            userIP = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

        if (userIP == null || userIP == "")
            userIP = Request.UserHostAddress;//, TYPE = "UserHostAddress" }, JsonRequestBehavior.AllowGet);


        return userIP;//, TYPE = "REMOTE_ADDR" }, JsonRequestBehavior.AllowGet);
    }


}
