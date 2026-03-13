using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppFW.InterfacePractice
{
    /// <summary>
    /// 定义形状接口
    /// </summary>
    internal interface IShape
    {
        /// <summary>
        /// 计算并返回当前形状的面积
        /// </summary>
        /// <returns>形状的面积值（double类型）</returns>
        double GetArea();
    }

    /// <summary>
    /// 表示一个圆形，实现 <see cref="IShape"/> 接口。
    /// </summary>
    public class Circle : IShape
    {
        private readonly double _radius;

        /// <summary>
        /// 获取圆形的半径。
        /// </summary>
        public double Radius => _radius;

        /// <summary>
        /// 初始化 <see cref="Circle"/> 类的新实例。
        /// </summary>
        /// <param name="radius">圆形的半径。</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// 当 <paramref name="radius"/> 小于等于 0、为 NaN 或为无穷大时抛出。
        /// </exception>
        public Circle(double radius)
        {
            if (radius<=0||double.IsNaN(radius)||double.IsInfinity(radius))
            {
                throw new ArgumentOutOfRangeException(nameof(radius),"半径必须为正数，并且不为无限");
            }
            _radius = radius; 
        }
        /// <summary>
        /// 计算圆形面积并返回
        /// </summary>
        /// <returns>圆形的面积</returns>
        public double GetArea() => Math.PI * _radius * _radius;
    }

    /// <summary>
    /// 表示一个矩形，实现 <see cref="IShape"/> 接口。
    /// </summary>
    public class Rectangle : IShape
    {
        private readonly double _width;
        private readonly double _height;

        /// <summary>
        /// 矩形的宽度。
        /// </summary>
        public double Width => _width;
        /// <summary>
        /// 矩形的高度。
        /// </summary>
        public double Height => _height;

        /// <summary>
        /// 初始化 <see cref="Rectangle"/> 类的新实例。
        /// </summary>
        /// <param name="width">矩形的宽度。</param>
        /// <param name="height">矩形的高度。</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// 当 <paramref name="width"/> 或 <paramref name="height"/> 无效时抛出。
        /// </exception>
        public Rectangle(double width,double height)
        {
            // 使用私有验证方法，并传入 nameof 以确保参数名正确
            Validate(width, nameof(width));
            Validate(height, nameof(height));
            _width = width;
            _height = height;

        }
        /// <summary>
        /// 计算矩形的面积。
        /// </summary>
        /// <returns>矩形的面积。</returns>
        public double GetArea()
        {
            return _width * _height;
        }
        /// <summary>
        /// 验证给定的数值是否为有效的正数（非 NaN，非无穷大）。
        /// </summary>
        /// <param name="value">要验证的数值。</param>
        /// <param name="paramName">参数的名称，用于异常消息。</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// 当 <paramref name="value"/> 小于等于 0、为 NaN 或为无穷大时抛出。
        /// </exception>
        private void Validate(double value, string paramname)
        {
            if (value <= 0 || double.IsNaN(value) || double.IsInfinity(value))
            {
                throw new ArgumentOutOfRangeException(paramname, $"{paramname},必须为正数，且不是无限数");
            }
        }
    }
}
