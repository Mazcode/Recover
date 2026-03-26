using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodOverloading
{
    internal class Statistics
    {
       
        public static double GetAverage(params double[] vals)
        {
            if (vals==null||vals.Length<=0)
            {
                throw new ArgumentOutOfRangeException(nameof(vals),$"{nameof(vals)}为空或者长度小于等于0");
            }
            var sum = 0d;
            for (int i = 0; i < vals.Length; i++)
            {
                sum += vals[i];
            }

            return sum / vals.Length; ;
        }

        public static void GetMinMax(out int max,out int min,params int[] vals)
        {
            if (vals == null || vals.Length <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(vals),$"{nameof(vals)}为空或者长度小于等于0");
            }
            max = vals[0];
            min = vals[0];
            for (int i = 1; i < vals.Length; i++)
            {
                var val  = vals[i];
                if (val > max) max = vals[i];
                else if(val < min) min = val;
                
            }
        }
    }
}
