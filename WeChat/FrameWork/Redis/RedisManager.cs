using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameWork.Redis
{
    public class RedisManager
    {
        private static PooledRedisClientManager poolrc; //连接类实例
        private static readonly object objlock = new object();//锁

        //私有构造函数
        private RedisManager() { }

        public static RedisClient GetClient()
        {
            if (poolrc == null)
            {
                lock (objlock)
                {
                    if (poolrc == null)
                    {
                        CreatePoolManager();
                    }
                }
            }
            return poolrc.GetClient() as RedisClient;
        }

        private static void CreatePoolManager()
        {
            poolrc = new PooledRedisClientManager(
                new List<string> { "" },
                new List<string> { "" },
                new RedisClientManagerConfig
                {
                    MaxReadPoolSize = 50,//读
                    MaxWritePoolSize = 50, //写
                    DefaultDb =1
                });
        }
    }
}
