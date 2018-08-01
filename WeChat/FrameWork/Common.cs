using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FrameWork
{
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
                using (StreamWriter sw = new StreamWriter(@"C:/wxlog.txt", true))
                {
                    if (hh)
                        sw.WriteLine("[" + DateTime.Now + "]—" + context);
                    else
                        sw.Write(context);
                }
            }
            catch (Exception ex)
            { }
            finally
            {
                loglock.ExitWriteLock();
            }
        }
    }
}
