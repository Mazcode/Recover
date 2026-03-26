using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CLIThread
{
    /// <summary>
    /// Thread 本身不支持直接返回结果，需要使用共享变量Task
    /// </summary>
    internal class ThreadReturnValue
    {
        static int _result;
        static readonly object _lockObj = new object();

        public static void Run()
        {
            Console.WriteLine($"=====获取线程返回值=====");
            //通过共享变量 需要lock，
            //在 C# 中使用 Thread 时，lock 关键字是处理线程安全（Thread Safety）最常用、最基础的机制。
            //它的核心作用是确保同一时刻只有一个线程能执行某段代码，从而防止多个线程同时修改共享数据导致的数据错乱。

            Thread t1 = new Thread(Crash);
            t1.Start();
            //t1.Join();
            Console.WriteLine($"t1 输出 :{_result}");

            Thread t2 = new Thread(Crash);
            t2.Start();
            //t2.Join();
            Console.WriteLine($"t2 输出 :{_result}");

            t1.Join();
            t2.Join();
            Console.WriteLine($"t1 输出 :{_result}");
            Console.WriteLine($"t2 输出 :{_result}");
        }


        private static void Incre()
        {
            //
            int sum = 0;
            for (int i = 0; i <=100; i++)
            {
                sum += i;
            }
            //lock (_lockObj)
            //{
            //    _result = sum;
            //}
            // 人为插入延迟，极大增加“撞车”概率
            Thread.Sleep(10); // 让线程在读和写之间停顿一下
            _result += sum;
            Console.WriteLine($"当前线程ID:{Thread.CurrentThread.ManagedThreadId},结果:{_result}");
        }


        private static void Crash()
        {
            int car = 5050;
            

            //插入延迟，提高撞车几率
            //Thread.Sleep(100);
            lock (_lockObj)
            {
                int current = _result;
                int next = current + car;
                _result = next;
            }
           

            
            Console.WriteLine($"当前线程ID:{Thread.CurrentThread.ManagedThreadId},结果:{_result}");
        }

        private static void CalculateWithShrareVal()
        {
            throw new NotImplementedException();
        }
    }
}
