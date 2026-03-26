using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodOverloading
{
    internal class Order
    {
        
        public static void CreateOrder(string productName, int quantity,string? couponCode=null,bool isExpress = false,string notes="")
        {
            
            //如果productName为null或者空字符串，触发异常抛出。
            ArgumentException.ThrowIfNullOrEmpty(productName, nameof(productName));
            //如果为0或者负数，触发异常抛出。
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(quantity,nameof(quantity));

            var orderSB= new StringBuilder();
            orderSB.AppendLine($"==产品:{productName}");
            orderSB.AppendLine($"==数量:{quantity}");
            orderSB.AppendLine($"==优惠码:{(string.IsNullOrEmpty(couponCode) ? "无" : "已使用")}");
            orderSB.AppendLine($"==配送:{(isExpress ? "加急配送" : "标准配送")}");
            orderSB.AppendLine($"==备注:{(string.IsNullOrEmpty(notes) ? "无" : "已使用")}");
            Console.WriteLine( orderSB.ToString());
        }

      

    }
}
