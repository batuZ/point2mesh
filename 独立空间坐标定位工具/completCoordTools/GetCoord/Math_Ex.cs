using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetCoord
{
    public static class Math_Ex
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="LengthA"></param>
        /// <param name="LengthO">角O所对边边长</param>
        /// <param name="LengthB"></param>
        /// <returns>返回角O的余弦值</returns>
        public static double GetCos(double LengthA, double LengthO, double LengthB)
        {
            return (LengthA * LengthA + LengthB * LengthB - LengthO * LengthO) /
                (2 * LengthA * LengthB);
        }
    }
}
