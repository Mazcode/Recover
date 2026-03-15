using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLIArray
{
    /// <summary>
    /// Array类的用法
    /// </summary>
    internal class UseArrayClass
    {
        public UseArrayClass() {

            //声明一个数组
            int[] numbers = { 5, 2, 8, 1, 9 };

            //排序
            Array.Sort(numbers);
            PrintArr(numbers);
            //反转
            Array.Reverse(numbers);
            PrintArr(numbers);
            //查找5的位置
            Console.WriteLine($"5在数组中的位置{Array.IndexOf(numbers,5)}");

            //复制数组
            int[] copy = new int[numbers.Length + 1];

            Array.Copy(numbers, copy, numbers.Length);
            PrintArr(copy);

            //清空数组
            Array.Clear(numbers, 0, numbers.Length);

            PrintArr(numbers);

        }

        private static void PrintArr<T>(T[] arr)
        {
            Console.WriteLine($"打印数组:{string.Join(",",arr)}");
        }
    }
}
