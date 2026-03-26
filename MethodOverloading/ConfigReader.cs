using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodOverloading
{
    internal class ConfigReader
    {
        private readonly Dictionary<string, string> _config;
#pragma warning disable IDE0290 // 使用主构造函数
        public ConfigReader(Dictionary<string,string> config) {
            _config = config;   
        }
#pragma warning restore IDE0290 // 使用主构造函数

        public  string  GetValue(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key),$"传入的参数为空。");
            }

            if (!_config.TryGetValue(key, out var value))
            {
                throw new DirectoryNotFoundException($"传入的参数：{nameof(key)}不存在");
            }
            return value;

        }

        
        public string GetValue(string key, string defaultValue)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key), $"传入的参数为空。");
            }
            return _config.TryGetValue(key, out var value) ? value : defaultValue;
        }

        public T GetValue<T>(string key, T defaultValue = default)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key), $"传入的参数为空。");
            }

            if (!_config.TryGetValue(key, out var stringValue))
            {
                return defaultValue;
            }

            if (string.IsNullOrEmpty(stringValue))  //先检查 null
            {
                return defaultValue;
            }

            try
            {
                // 处理 nullable 类型
                var targetType = typeof(T);
                if (targetType != null)
                {


                    if (targetType.IsGenericType && targetType.GetGenericTypeDefinition() == typeof(Nullable<>))
                    {
                        targetType = Nullable.GetUnderlyingType(targetType)!;
                    }
                    

                    // 类型转换
                    var converted = Convert.ChangeType(stringValue, targetType);
                    if (converted is null)
                    {
                        return defaultValue;
                    }
                    return (T)converted;
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                // 转换失败返回默认值
                return defaultValue;
            }
        }
    }
}
