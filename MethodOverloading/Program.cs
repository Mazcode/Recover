namespace MethodOverloading
{
    internal class Program
    {
        static void Main()
        {
            //Question2();
            Question3();
            Console.ReadLine();
        }

        private static void Question3()
        {

            try
            {
                // 测试 GetAverage
                Console.WriteLine($"平均值: {Statistics.GetAverage(1, 2, 3, 4, 5):F2}");  // 3.00
                Console.WriteLine($"平均值: {Statistics.GetAverage(10.5, 20.5):F2}");    // 15.50

                // 测试 GetMinMax (out 参数)
                Statistics.GetMinMax(out int min1, out int max1, 5, 2, 9, 1, 7);
                Console.WriteLine($"最小值: {min1}, 最大值: {max1}");  // 1, 9

                // 测试负数情况（关键测试）
                Statistics.GetMinMax(out int min2, out int max2, -5, -10, -3);
                Console.WriteLine($"负数测试 - 最小值: {min2}, 最大值: {max2}");  // -10, -3 

                // 测试单个元素
                Statistics.GetMinMax(out int min3, out int max3, 42);
                Console.WriteLine($"单个元素 - 最小值: {min3}, 最大值: {max3}");  // 42, 42 

                // 测试空参数（应该抛异常）
                try
                {
                    Statistics.GetAverage();
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"捕获异常: {ex.Message}");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine( ex.Message );
            }
        }

        private static void Question2()
        {
            try
            {
                // 只传必需参数 
                // 其他参数自动使用默认值 (couponCode=null, isExpress=false, notes="")
                Order.CreateOrder("机械键盘", 1);

                // 传必需参数 + 优惠码
                // 按位置传递第三个参数 (couponCode)
                Console.WriteLine("按位置传递第三个参数 传必需参数 + 优惠码");
                Order.CreateOrder("无线鼠标", 2, "XXX1024");

                // 使用命名参数跳过中间参数
                // 需求：只想设置 isExpress 和 notes，不想管 couponCode
                // 直接指定参数名，忽略顺序，中间的 couponCode 保持默认值 (null)
                Console.WriteLine("使用命名参数跳过中间参数 加急配送 + 特殊备注，无优惠券");
                Order.CreateOrder(
                    "游戏手柄",
                    1,
                    isExpress: true,                //  couponCode 保持默认值 (null)，直接赋值 isExpress
                    notes: "请放在门口，不要敲门" // 继续赋值 notes
                );


                Console.WriteLine("完全乱序的命名参数调用");
                Order.CreateOrder(
                    notes: "生日礼物，请包装精美",
                    productName: "乐高积木",
                    isExpress: true,
                    quantity: 1
                // couponCode 默认为 null
                );
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}
