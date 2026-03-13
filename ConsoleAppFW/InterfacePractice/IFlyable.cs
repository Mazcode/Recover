using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppFW.InterfacePractice
{
    internal interface IFlyable
    {
        void Fly();
        void DoWork();
    }

    interface ISwimmable
    {
        void Swim();
        void DoWork();
    }


    class Duck : IFlyable, ISwimmable
    {
        private readonly string _name;

        public string Name => _name;
        public Duck(string name)
        {
            if (string.IsNullOrEmpty(name.TrimEnd()))
            {
                throw new ArgumentNullException($"{nameof(Duck)}参数名{nameof(name)}不能为空");
            }
            _name = name;
        }
        public void Fly()
        {
            Console.WriteLine($"{_name} 可以飞");
        }

        public void Swim()
        {
            Console.WriteLine($"{_name} 可以游");
        }

         void IFlyable.DoWork()
        {
            Console.WriteLine($"{_name} 可以飞起来干活");
        }

         void ISwimmable.DoWork()
        {
            Console.WriteLine($"{_name} 可以游起来干活");
        }
    }
}
