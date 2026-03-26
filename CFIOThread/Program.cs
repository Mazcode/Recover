using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CFIOThread
{
    /// <summary>
    /// 基于10月的寒流的线程视频的学习
    /// </summary>
    internal class Program
    {
        private const int _total = 100_000;
        static int _count = 0;

        private static readonly object _lockObj = new object();
        static void Main()
        {
            //for (int i = 0; i < 10; i++)
            //{
            //    _count = 0;
            //    var t1 = new Thread(DoWork);
            //    var t2 = new Thread(DoWork);

            //    t1.Start();
            //    t2.Start();

            //    t1.Join();
            //    t2.Join();
            //    Console.WriteLine($"Count:{_count}");
            //}

            ProCon.Run();
           
        }

        private static void DoWork()
        {
            for (int i = 0; i < _total; i++)
            {
                lock (_lockObj)//加锁，只有用完才可以给别的线程用
                {
                    _count++;
                }
            }
        }
    }
}
