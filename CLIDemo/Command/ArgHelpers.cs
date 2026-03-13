using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLIDemo.Command
{
    /// <summary>
    /// 参数工具类
    /// </summary>
    internal static class ArgHelpers
    {
        /// <summary>
        /// 尝试从字符串数组中解析出一个十进制数字。
        /// </summary>
        /// <remarks>
        /// 此方法会执行以下验证：
        /// <list type="bullet">
        ///     <item>检查数组是否为 null 或为空。</item>
        ///     <item>检查数组长度是否严格等于 1（不允许多余参数）。</item>
        ///     <item>尝试将第一个元素解析为 <see cref="decimal"/> 类型。</item>
        /// </list>
        /// 如果解析失败，<paramref name="number"/> 将被设置为默认值 0。
        /// </remarks>
        /// <param name="args">包含待解析数字字符串的输入数组。</param>
        /// <param name="number">
        /// 当方法返回 <see langword="true"/> 时，包含解析成功的十进制数值；
        /// 当方法返回 <see langword="false"/> 时，该值为 0 (默认值)。
        /// </param>
        /// <param name="errorMsg">
        /// 当方法返回 <see langword="false"/> 时，包含具体的错误描述信息；
        /// 当方法返回 <see langword="true"/> 时，该值为空字符串。
        /// </param>
        /// <returns>
        /// 如果参数有效且成功解析为数字，则返回 <see langword="true"/>；
        /// 否则返回 <see langword="false"/>请读取errorMsg。
        /// </returns>
        public static bool TryGetDecimal(string[] args,out decimal number,out string errorMsg)
        {
            number = 0;
            errorMsg = string.Empty;

            if (args==null||args.Length==0)
            {
                errorMsg = "缺少数字参数！";
                return false;
            }

            if (args.Length != 1)
            {
                errorMsg = "需要提供一个数字";
                return false;
            }

            if (!decimal.TryParse(args[0], out number))
            {
                errorMsg = $"{args[0]} 为无效数字格式";
                return false;
            }
       
            return true;
        }
    }
}
