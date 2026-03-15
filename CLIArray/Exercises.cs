using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace CLIArray
{
    /// <summary>
    /// 数组练习
    /// </summary>
    internal static class Exercises
    {
        public static void Question1()
        {
            int[] numbers = { 12, 25, 38, 41, 59 };

            int index = 0;//计算器，从0开始计数
            foreach (var num in numbers)
            {
                index++;
                if (index==numbers.Length)
                {
                    Console.Write($"第{index}个元素：{num}\n");
                    continue;
                }
                Console.Write($"第{index}个元素：{num}、");
            }
            Console.WriteLine("遍历结束。");
        }

        public static void Question2()
        {
            int[] scores = { 85, 92, 78, 90, 65, 88, 72, 95, 80, 70 };

            //计算平均分
            //统计及格人数（>=60）
            //统计优秀人数（>=90）

            int total = 0;
            int pass = 0;
            int excellent = 0;
            foreach (var score in scores)
            {
                total += score;
                if (score>=60)
                {
                    pass++;
                }
                if (score>=90)
                {
                    excellent++;
                }
            }

            Console.WriteLine($"平均分:{(double)total/scores.Length}");
            Console.WriteLine($"及格人数:{pass}");
            Console.WriteLine($"优秀人数:{excellent}");
        }

        public static void Question3()
        {
            int[] numbers = { 3, 7, 12, 19, 25, 31, 8, 44, 50,-1,-2,100};
            int max = numbers[0];
            int min = numbers[0];
            List<int> evenList = new List<int>();
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i]>max)
                {
                    max = numbers[i];
                }
                if (numbers[i] < min)
                {
                    min = numbers[i];
                }
                if (numbers[i]%2==0)
                {
                    evenList.Add(numbers[i]);
                }
            }

            Console.WriteLine($"最大值：{max}；最小值：{min}；");

            Console.WriteLine($"偶数数组内容为：{string.Join(",",evenList)}");
        }

        public static void Question4() {

            int[] numbers = { 1, 3, 5, 3, 7, 1, 9, 5, 11 };
            //去除重复元素
            List<int> locate = new List<int>();
            
            for (int i = 0; i < numbers.Length; i++)
            {
               
                int current = numbers[i];
                for (int j = i+1; j < numbers.Length; j++)
                {
                    if (current == numbers[j])
                    {
                        Console.WriteLine($"当前{current},找到了，第{j + 1}个：{numbers[j]}");
                        locate.Add(j);
                    }
                } 
            }
            List<int> result = new List<int>();
            for (int i = 0; i < numbers.Length; i++)
            {
                bool isRepeat = false;
                foreach (var item in locate)
                {
                    if (i==item)
                    {
                        isRepeat = true;
                    }
                }
                if (!isRepeat)
                {
                    result.Add(numbers[i]);
                }
            }
            Console.WriteLine($"{string.Join(",",result)}");
            
        }

        /// <summary>
        /// 纯数组实现
        /// </summary>
        public static int[] Question4_1(int[] numbers)
        {
            //int[] numbers = { 1, 3, 5, 3, 7, 1, 9, 5, 11 };

            // 边界处理
            if (numbers == null || numbers.Length == 0)
            {
                Console.WriteLine("(空数组)");
                return new int[0];
            }

            // 临时数组，假设所有的都不重复
            int[] temp = new int[numbers.Length];
            int count = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                bool isRepeat = false;
                int current = numbers[i];
                Console.WriteLine($"当前值{current}");
                for (int j = 0; j < i; j++)
                {
                    if (current == numbers[j])
                    {
                        Console.WriteLine($"当前索引{i}：{current},找到了，第{j + 1}个：{numbers[j]}");
                        isRepeat = true;
                        break;
                    }
                }
                if (!isRepeat)
                {
                    temp[count++] = numbers[i];
                }
            }
           
            // 截取有效部分
            int[] result = new int[count];
            Array.Copy(temp, result, count);
            //Console.WriteLine(string.Join(",",result));
            return result;
        }

        public static void Question5()
        {
            var scores = new int[3, 3]
            {
                { 85, 90, 78 },  // 学生1
                { 88, 76, 92 },  // 学生2
                { 92, 85, 88 }   // 学生3
            };

            var students = scores.GetLength(0);
            var subjects = scores.GetLength(1);

            //计算每个学生的平均分
            for (int i = 0; i < students; i++)
            {
                int total = 0;
                for (int j = 0; j < subjects; j++)
                {
                    total += scores[i, j];
                }
                Console.WriteLine($"学生{i + 1}的平均分是：{(double)total / subjects}");
            }
            //计算每门课的平均分
            for (int i = 0; i < subjects; i++)
            {
                int total = 0;
                for (int j = 0; j < students; j++)
                {
                    total += scores[j, i];
                }
                Console.WriteLine($"每门课的{i + 1}的平均分是：{(double)total / students}");
            }
            //找出最高分及其位置
            int max = scores[0,0];
            int maxStudentIndex = 0;
            int maxSubjectIndex = 0;
            for (int i = 0; i < students; i++)
            {
               
                for (int j = 0; j < subjects; j++)
                {
                    if (scores[i,j]>max)
                    {
                        max = scores[i, j];
                        maxStudentIndex = i; 
                        maxSubjectIndex=j;
                    }
                    
                }
            }
            Console.WriteLine($"最高分是学生{maxStudentIndex + 1}，第{maxSubjectIndex + 1}门课，成绩：{max}");

        }


        

    }
}
