using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLIArray
{
    internal class MulDimension
    {
        public MulDimension()
        {
      
        }

        public static void MDArray()
        {
            //声明一个3行4列的二维数组
            int[,] matrix = new int[3, 4];

            //初始化
            int[,] grades = {
                {
                    80, 90, 78, 92
                },
                {
                    88, 76, 95, 89
                },
                {
                    92, 85, 88, 91
                }
            };

            Console.Write($"输出{nameof(grades)}第1行第2列\t");//预计结果90
            Console.WriteLine(grades[0, 1]);

            //遍历数组
            for (int i = 0; i < grades.GetLength(0); i++)//行数
            {
                for (int j = 0; j < grades.GetLength(1); j++)
                {
                    Console.Write(grades[i, j] + " ");
                }
                Console.WriteLine();
            }
        }


        /// <summary>
        /// 锯齿数组 数组的数组
        /// </summary>
        public static void JaggedArray()
        {
            int[][] jagged = new int[3][];

            jagged[0] = new int[] { 1, 2, 3 };
            jagged[1] = new int[] { 4,5 };
            jagged[2] = new int[] { 6,7,8,9 };

            Console.WriteLine(jagged[2][3]);

            Console.WriteLine(jagged.Rank);//输出1，数组的数组不是多维数组

            for (int i = 0; i < jagged.Length; i++)
            {
                for (int j = 0; j < jagged[i].Length; j++)
                {
                    Console.Write($"{nameof(jagged)}[{i}][{j}]:{jagged[i][j]}\t");
                }
                Console.WriteLine();
            }

        }
    }
}
