using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLIArray
{
    internal class LearnArray
    {
        //数组是一个带编号的储物柜，可以放多个相同类型的数据
        //1. 存放类型必须相同
        //2. 索引从0开始，最后一个索引是数组的长度-1,arr.Length-1;
        //3. 长度固定 可以通过.Length 获取总数

        public static void FirstArr()
        {
            //声明方式
            //1. 先声明，后初始化
            int[] numbers;

            numbers = new int[10];

            //2. 声明同时初始化
            int[] scores = new int[10];

            //3. 直接赋值
            int[] ages = { 10, 12, 18, 20, 22 };
            string[] names = { "张三", "李四", "王五" };

            
            //访问数组
            Console.WriteLine($"输出ages第一个元素:{ages[0]}");
            Console.WriteLine($"输出ages第最后一个元素:{ages[ages.Length-1]}");

            //修改元素再访问
            Console.WriteLine($"修改前:{names[1]}");
            names[1] = "马克思";
            Console.WriteLine($"修改后:{names[1]}");

            //输出上面数组的长度
            Console.WriteLine($"{nameof(ages)}数组长度:{ages.Length}");
            Console.WriteLine($"{nameof(names)}数组长度:{names.Length}");



        }

        /// <summary>
        /// 遍历数组，三种方式
        /// </summary>
        public static void Traverse()
        {
            int[] numbers = { 10, 20, 30, 40, 50 };

            //纯遍历
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine($"第{i}个元素：{numbers[i]}");
            }
            //遍历+修改
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = numbers[i] + 2;
                Console.WriteLine($"修改后第{i}个元素：{numbers[i]}");
            }

            //foreach 只读，不能赋值
            foreach (int i in numbers)
            {
                //i=i+1;//这句会报错
                Console.WriteLine($"foreac输出{i}");
            }


            Console.WriteLine("打印引用类型");
            Subject[] subjects = {
                new Subject{ Title="历史",Count=12},
                new Subject{ Title="地理",Count=10},
                new Subject{ Title="数学",Count=20},
            };
            foreach (var item in subjects)
            {
                item.Count = 10;
                Console.WriteLine(item);
            }
            
            
            foreach (var item in subjects)
            {
                //item = new Subject { Title = "循环重新赋值", Count = 33 };//这里也是会报错的，不能赋值
                item.Count = 12;//但是可以修改对象的值
                Console.WriteLine(item);
            }

            //直接打印
            foreach (var item in subjects)
            {
                Console.WriteLine(item);
            }
        }

        internal class Subject
        {
            public string Title { get; set; }

            public int Count { get; set; }

            public override string ToString()
            {
                return $"科目{Title}，总人数：{Count}";
            }
        }


        //计算平均分
        public class Demo
        {
            public static void CalAvgScore(int[] scores)
            {
                int sum = 0;
                foreach (int i in scores)
                {
                    sum += i;
                }
                Console.WriteLine($"总分:{sum}");
                Console.WriteLine($"平均:{(double)sum/scores.Length}");

            }
        }
    }
}
