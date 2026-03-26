using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodOverloading.AIO
{
    internal class AIO
    {
        public static void Quesion1()
        {
            
        }

        public static void Quesion2()
        {
        }
        public static void Quesion3()
        {
        }
    }

    class ShapeArea
    {
        /// <summary>
        /// 计算圆的面积
        /// </summary>
        /// <param name="radius"></param>
        /// <returns></returns>
        public static double CalculateCircle(double radius)//要么改成独立的方法名字
        {
            //π*r的平方===>π* r*r
            return Math.PI * radius * radius;
        }
        //要么用的时候这里写上说明
        public static double CalculateArea(double width, double height)
        {
            //矩形的面积=宽*高度
            return width * height;
        }

        public static double CalculateArea(double side)
        {
            //正方形的面积=边长*边长
            return side * side;
        }

    }

    class OrderService
    {
        public static void CreateOrder(string productName, int quantity, string? couponCode = null, bool isExpress = false, string notes = "")
        {
            var orderStringBuilder = new StringBuilder();//声明一个类型为StringBuilder变量，
            orderStringBuilder.AppendLine($"==商品：{productName}");
            orderStringBuilder.AppendLine($"==数量：{quantity}");
            orderStringBuilder.AppendLine($"==优惠码：{(couponCode is not null && couponCode != "" ? couponCode : "无")}");
            orderStringBuilder.AppendLine($"==配送：{(isExpress?"加急配送":"")}");
            orderStringBuilder.AppendLine($"==备注：{notes}");
        }
    }
}
