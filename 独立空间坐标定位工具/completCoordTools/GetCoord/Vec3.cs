using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetCoord
{
    struct Vec3
    {
        public double x,y,z;
        public double Length {
            get {
                return Math.Sqrt(x * x + y * y + z * z);
            }
        }

        public Vec3(double x,double y,double z) {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public Vec3(Vec3 m)
        {
            this.x=m.x;
            this.y=m.y;
            this.z=m.z;
        }

        public static Vec3 operator +(Vec3 lhs, Vec3 rhs)
        {
            Vec3 result = new Vec3(lhs);
            result.x += rhs.x;
            result.y += rhs.y;
            result.z += rhs.z;
            return result;
        }

        public static Vec3 operator -(Vec3 lhs, Vec3 rhs)
        {
            Vec3 result = new Vec3(lhs);
            result.x -= rhs.x;
            result.y -= rhs.y;
            result.z -= rhs.z;
            return result;
        }

        public static Vec3 operator *(Vec3 lhs,double a)
        {
            Vec3 result = new Vec3(lhs);
            result.x*=a;
            result.y*=a;
            result.z*=a;
            return result;
        }

        public static Vec3 operator /(Vec3 lhs, double a)
        {
            if (Math.Abs(a - 0) < 0.0000001)
                throw new ArgumentException("不能除以0");
            Vec3 result = new Vec3(lhs);
            result.x /= a;
            result.y /= a;
            result.z /= a;
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rhs"></param>
        /// <returns>根据右手定则返回一个法向量(即是向量叉乘)</returns>
        public Vec3 CrossProduct(Vec3 rhs)
        {
            Vec3 result = new Vec3(this);
            result.x = this.y * rhs.z - this.z * rhs.y;
            result.y = this.z * rhs.x - this.x * rhs.z;
            result.z = this.x * rhs.y - this.y * rhs.x;

            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rhs"></param>
        /// <returns>返回两向量余弦夹角</returns>
        public double GetCosAngle(Vec3 rhs)
        {
            return this.GetDianji(rhs) / this.Length / rhs.Length;
        }

        public double GetDianji(Vec3 rhs)
        {
            double result = 0;
            result += this.x * rhs.x;
            result += this.y * rhs.y;
            result += this.z * rhs.z;

            return result;
        }
    }
}
