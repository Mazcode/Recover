using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CFIOThread
{
    /// <summary>
    /// 生产者和消费者例子
    /// </summary>
    internal class ProCon
    {
        static readonly Queue<int> queue = new Queue<int>();
        public static void Run()
        {
            //生产者为一个队列插入从0-20
            //两个消费者，队列中有数字就拿出来
            //生产者线程
            var producer = new Thread(AddNumber);
            //消费者线程
            var consumer1 = new Thread(ReadNumber)
            {
                Name="消费者线程A"
            };
            var consumer2 = new Thread(ReadNumber)
            {
                Name = "消费者线程B"
            };
            producer.Start();
           
            consumer1.Start();
            consumer2.Start();
            producer.Join();
            //Thread.Sleep(2000); // 等2秒后停止
            consumer1.Interrupt();
            consumer2.Interrupt();
            //consumer1.Join();
            //consumer2.Join();
        }

        private static void AddNumber()
        {
            for (int i = 0; i < 20; i++)
            {
               
                queue.Enqueue(i + 1);
                Thread.Sleep(20);
            }
            Console.WriteLine(string.Join(",",queue.ToList<int>()));
        }

        private static void ReadNumber()
        {
            try
            {
                while (true)
                {
                    //if (queue.TryDequeue(out var res))
                    //{
                    //    Console.WriteLine($"当前消费者线程：{Thread.CurrentThread.Name},当前获取的数：{res}");

                    //}
                    //Thread.Sleep(1);
                    if (queue.Count > 0)
                    {
                        Thread.Sleep(100); // 故意等待，让另一个线程有机会插入 这里设置得设置大点
                        var res = queue.Dequeue(); // 这里可能异常或重复
                        Console.WriteLine($"{Thread.CurrentThread.Name}: {res}");
                    }

                }
            }
            catch (ThreadInterruptedException)
            {
                Console.WriteLine("线程被中断");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"竞态异常: {ex.Message}，{Thread.CurrentThread.Name},{ex.StackTrace}");
            }
            finally
            {
                
            }
        }
    }
}
