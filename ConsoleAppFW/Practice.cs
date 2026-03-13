using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppFW
{
    internal class Practice
    {
        public Practice() { }

        //题目 1：奇偶数与倍数统计
        //编写一个程序，遍历 1 到 100 的整数：
        //统计其中有多少个奇数。
        //统计其中有多少个能同时被 3 和 5 整除 的数（即 15 的倍数）。
        //将这些能被 15 整除的数打印出来，用逗号分隔。
        //Statistics of Odd and Even Numbers and Multiples
        public static void Practice1()
        {
            int odd_Count = 0;
            int divisibleBy15Count = 0;
            List<int> divisibleBy15 = new List<int>();
            for (int i = 1; i <= 100; i++)
            {
                if (i%2!=0) odd_Count++;
                if (i % 3 == 0 && i % 5 == 0)
                {
                    divisibleBy15.Add(i);
                    divisibleBy15Count++;
                    
                }

            }
            Console.WriteLine($"1-100中奇数的数量{odd_Count}");
            Console.WriteLine($"能同时被 3 和 5 整除的数的数量{divisibleBy15Count}，以下是这些数");
            Console.WriteLine(string.Join(",",divisibleBy15));
                
        }


        //题目 2：简单的成绩等级判断
        //定义一个 int score = 85;。
        //使用 if-else 或 switch 表达式输出等级：
        //90-100: "优秀"
        //80-89: "良好"
        //60-79: "及格"
        //0-59: "不及格"
        //其他: "无效分数"

        public static void Practice2()
        {
            int score = 85;
            string level = string.Empty;
            //8.0版本以上写法
            //string level = score switch
            //{
            //    >= 90 and <= 100 => "优秀",
            //    >= 80 and < 90 => "良好",
            //    >= 60 and < 80 => "及格",
            //    >= 0 and < 60 => "不及格",
            //    _ => "无效分数"
            //};
            //Console.WriteLine($"等级: {level}");

            //if写法
            if (score<=0||score>100)
            {
                level = "无效分数";
            }
            else if (score>=90&&score<=100)
            {
                level = "优秀";
            }
            else if (score >= 80 && score <90)
            {
                level = "良好";
            }
            else if (score >= 90 && score <= 100)
            {
                level = "及格";
            }
            else if (score >= 90 && score <= 100)
            {
                level = "不及格";
            }

            Console.WriteLine($"if-else 写法输出结果：{level}");

            //全版本通用Switch
            //除以10
            int score2 = score / 10;
            if (score2 <= 0 || score2 > 10)
            {
                level = "无效分数";
            }
            switch (score2)
            {
                case 10: // 100 分
                case 9:  // 90-99 分
                    level = "优秀";
                    break;
                case 8:  // 80-89 分
                    level = "良好";
                    break;
                case 7:  // 70-79 分
                case 6:  // 60-69 分
                    level = "及格";
                    break;
                default: // 0-59 分
                    level = "不及格";
                    break;
            }
            Console.WriteLine($"switch 写法输出结果：{level}");

        }


        //题目 3：列表去重与排序
        //有一个包含重复数字的列表：{ 5, 2, 9, 2, 8, 5, 1, 9 }。
        //使用 HashSet 或 LINQ 去除重复项。
        //将去重后的数字按从大到小排序。
        //打印结果。

        public static void Practice3()
        {
            List<int> list = new []{ 5, 2, 9, 2, 8, 5, 1, 9 }.ToList();

      
            HashSet<int> set = new HashSet<int>(list.OrderBy(x => x));
            Console.WriteLine(string.Join(",", set));

            //LINQ写法
            var beSorted = list.Distinct().OrderBy(x => x).ToList();
            Console.WriteLine(string.Join(",", beSorted));
        }

        //题目 4：字典统计词频
        //给定字符串："apple banana apple orange banana apple"。
        //使用 Dictionary<string, int> 统计每个单词出现的次数。
        //找出出现次数最多的单词并打印。
        public static void Practice4()
        {
            string str = "apple banana apple orange banana apple";

            var list = str.Split(' ');

            Dictionary<string,int> keyValuePairs = new Dictionary<string,int>();
            foreach (var word in list)
            {
                if (keyValuePairs.ContainsKey(word))
                {
                    keyValuePairs[word]++;
                }
                else
                {
                    keyValuePairs[word]=1;
                 }

            }

            foreach (var item in keyValuePairs)
            {
                Console.WriteLine($"{item.Key}:{item.Value}");
            }

            // 找最大值
            var maxWord = keyValuePairs.OrderByDescending(kvp => kvp.Value).First();
            Console.WriteLine($"出现最多的是: {maxWord.Key}, 次数: {maxWord.Value}");
        }


        //题目 5：动物继承与多态
        //定义一个抽象类 Animal，包含一个抽象方法 MakeSound()。
        //创建两个子类 Dog 和 Cat，分别实现 MakeSound() 输出 "汪汪" 和 "喵喵"。
        //创建一个 List<Animal>，放入一只狗和一只猫。
        //遍历列表，调用每只动物的 MakeSound() 方法。

        public static void Practice5()
        {
            List<Animal> animals = new List<Animal>();
            animals.Add(new Dog());
            animals.Add(new Cat());
            for (int i = 0; i < animals.Count; i++)
            {
                animals[i].MakeSound();
            }
        }

        //创建一个 BankAccount 类：
        //包含私有字段 _balance(decimal)。
        //提供一个只读属性 Balance 获取余额。
        //构造函数必须接收初始金额，如果金额小于 0，抛出异常。
        //提供 Deposit(decimal amount) 方法（存款），如果金额 <= 0 则不操作。
        //提供 Withdraw(decimal amount) 方法（取款），如果余额不足则返回 false，否则扣除并返回 true。
        public static void Practice6()
        {
            //BankAccount ba = new BankAccount(-1);//抛出异常
            BankAccount ba2 = new BankAccount(100);
            ba2.Deposit(20m);
            Console.WriteLine(ba2.Balance);
            ba2.Deposit(0);
            Console.WriteLine(ba2.Balance);
            Console.WriteLine(ba2.Withdraw(200));
            Console.WriteLine(ba2.Balance);
            Console.WriteLine(ba2.Withdraw(40));
            Console.WriteLine(ba2.Balance);
        }

        public static void Practice9()
        {
            CartItem cartItem1 = new CartItem("叉烧濑粉", 10, 1);
            CartItem cartItem2 = new CartItem("柠檬红茶", 20, 2);

            ShoppingCart cart = new ShoppingCart();
            cart.AddItem(cartItem1);
            cart.AddItem(cartItem2);
            Console.WriteLine($"总价：{cart.GetTotalPrice()}"  ); 
            cart.PrintReceipt();
        }
    }

    #region 题目5
    internal abstract class Animal
    {
        protected internal virtual void MakeSound() { }
    }

    internal class Dog : Animal
    {
        protected internal override void MakeSound()
        {
            Console.WriteLine("汪汪");
        }
    }
    internal class Cat : Animal
    {
        protected internal override void MakeSound()
        {
            Console.WriteLine("喵喵");
        }
    }
    #endregion

    #region 题目6
    class BankAccount
    {
        private decimal _balance;

        //public decimal Balance => _balance;
        public decimal Balance
        {
            get
            {
                return _balance;
            }
        }

        public BankAccount(decimal initialAmount)
        {
            if (initialAmount < 0)
            {
                throw new Exception("初始金额不能小于0");
            }
            _balance = initialAmount;
        }

        public void Deposit(decimal amount)
        {
            if (amount > 0) _balance += amount;

        }
        public bool Withdraw(decimal amount)
        {
            if (amount > 0 && _balance >= amount)
            {
                _balance -= amount;
                return true;
            }
            return false;
        }
    }
    #endregion

    #region 题目9
    //题目 9：简易购物车
    //定义一个 CartItem 类（含 ProductName, Price, Quantity，使用 init 保护）。
    //定义一个 ShoppingCart 类：
    //内部维护一个 List<CartItem>。
    //提供 AddItem 方法。
    //提供 GetTotalPrice 方法计算总价。
    //提供 PrintReceipt 方法打印清单（格式：商品名 x 数量 = 小计）。
    //在 Main 函数中模拟添加 2 个商品并打印小票。

    class CartItem
    {
        
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        private int _quantity;
        public int Quantity { get { return _quantity; } }

        public CartItem(string productName,decimal price,int quantity)
        {
            this.ProductName = productName; 
            this.Price = price;
            this._quantity = quantity;
        }
    }

    class ShoppingCart
    {
        List<CartItem> items = new List<CartItem>();
        public void AddItem(CartItem item)
        {
            if (item!=null)
            {
                items.Add(item);
            }
        }
        public decimal GetTotalPrice()
        {
            var total = items.Sum(x => x.Price*x.Quantity);
            return total;
        }

        public void PrintReceipt()
        {
            //商品名 x 数量 = 小计
            StringBuilder sbReceipt = new StringBuilder();

            foreach (var item in items)
            {
                sbReceipt.AppendLine($"商品名：{item.ProductName} x {item.Quantity}={item.Price * item.Quantity}");
            }
            Console.WriteLine(sbReceipt);

        }

    }
    #endregion
}
