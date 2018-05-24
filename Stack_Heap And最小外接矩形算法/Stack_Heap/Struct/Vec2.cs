using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stack_Heap.TIN
{
    public class Vec2
    {
        public double X;
        public double Y;
        public double Length { get { return Math.Sqrt(X * X + Y * Y); } }

        public Vec2() { }
        public Vec2(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public Vec2 GetCrossVec2()
        {
            Vec2 vec = new Vec2(Y,-X);
            return vec;
        }
        public Vec2 GetUnitVec2()
        {
            Vec2 vec = new Vec2();
            vec.X = this.X / this.Length;
            vec.Y = this.Y / this.Length;
            return vec;
        }

        public static Vec2 operator *(Vec2 lhs,double rhs)
        {
            Vec2 vec = new Vec2();
            vec.X = lhs.X * rhs;
            vec.Y = lhs.Y * rhs;
            return vec;
        }

        public static double operator *(Vec2 lhs, Vec2 rhs)
        {
            double result;
            result = lhs.X * rhs.Y - lhs.Y * rhs.X;
            return result;
        }
    }
}
