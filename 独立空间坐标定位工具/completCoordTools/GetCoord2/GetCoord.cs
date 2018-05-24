using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetCoord2
{
    public class GetCoord
    {
        double CotMAm, CotMBm, CotMCm;
        Vec2 AB, AC, BC;

        public GetCoord(Vec2 ab, Vec2 ac, Vec2 bc)
        {
            this.AB = ab;
            this.AC = ac;
            this.BC = bc;
        }

        public void SetPAngles(double cotMAm, double cotMBm, double cotMCm)
        {
            this.CotMAm = cotMAm;
            this.CotMBm = cotMBm;
            this.CotMCm = cotMCm;
        }

        public Tuple<double, double, double> GetXYZ()
        {
            double ratio1 = CotMAm / CotMBm;
            double a = ratio1;
            Vec2 A_Cir1 = AB * (a * a / (a * a - 1));
            double r1 = 2 * a * Math.Abs(a / (a * a - 1));

            double ratio2 = CotMBm / CotMCm;
            double b = ratio2;
            Vec2 B_Cir2 = BC * (b * b / (b * b - 1));
            double r2 = 2 * b * Math.Abs(b / (b * b - 1));
            Vec2 A_Cir2 = AB + B_Cir2;

            Vec2 Cir1_2 = A_Cir2 - A_Cir1;
            Vec2 Cir1_2_Cross = Cir1_2.GetCrossVec2();

            double d = ((r1 * r1 - r2 * r2) / Cir1_2.Length + Cir1_2.Length) / 2;
            double d_cross = Math.Sqrt(r1 * r1 - d * d);
            Vec2 P_0 = A_Cir1 + Cir1_2 * d + Cir1_2_Cross / Cir1_2_Cross.Length * d_cross;
            Vec2 P_1 = A_Cir1 + Cir1_2 * d - Cir1_2_Cross / Cir1_2_Cross.Length * d_cross;

            double ratio3 = CotMAm / CotMCm;
            double c = ratio3;
            Vec2 A_Cir3 = AC * (c * c / (c * c - 1));
            double r3 = 2 * c * Math.Abs(c / (c * c - 1));

            Vec2 Cir1_3 = A_Cir3 - A_Cir1;
            Vec2 Cir1_3_Cross = Cir1_3.GetCrossVec2();
            double d2 = ((r1 * r1 - r3 * r3) / Cir1_3.Length + Cir1_3.Length) / 2;
            double d2_cross = Math.Sqrt(r1 * r1 - d2 * d2);
            Vec2 P_2 = A_Cir1 + Cir1_3 * d2 + Cir1_3_Cross / Cir1_3_Cross.Length * d2_cross;
            Vec2 P_3 = A_Cir1 + Cir1_3 * d2 - Cir1_3_Cross / Cir1_3_Cross.Length * d2_cross;
            double result_x, result_y, result_z;
            if (P_0 == P_2 || P_0 == P_3)
            {
                result_x = P_0.X;
                result_y = P_0.Y;
                result_z = P_0.Length / CotMAm;
            }
            else
            {
                result_x = P_1.X;
                result_y = P_1.Y;
                result_z = P_1.Length / CotMAm;
            }

            Tuple<double, double, double> result = Tuple.Create<double, double, double>(result_x, result_y, result_z);
            return result;
        }

        //public Tuple<double, double, double> GetXYZ(TriangleType type)
        //{
        //    double x, y, z;
        //    Tuple<double, double, double> result;
        //    if (type == TriangleType.DengBian)
        //    {
        //        Vec2 AB_Cross = AC - AB / 2;
        //        Vec2 AO = AB / 2 + AB_Cross / 3;
        //        x = AO.X;
        //        y = AO.Y;
        //        z = AO.Length / CotMAm;
        //    }
        //    else if(type == TriangleType.DengYao)
        //    {
        //        if (Math.Abs((AC - AB / 2) * AB) < 0.0000001)//说明AB为底边
        //        {
        //            double ratio3 = CotMAm / CotMCm;
        //            double c = ratio3;
        //            Vec2 A_Cir3 = AC * (c * c / (c * c - 1));
        //            double r3 = 2 * c * Math.Abs(c / (c * c - 1));
        //        }
        //        else if (Math.Abs((AC - BC / 2) * BC) < 0.0000001)//说明BC为底边
        //        {
        //        }
        //        else//说明AC为底边
        //        { 
        //        }
        //    }

        //    return result;
        //}

        private Tuple<ApolloCurveType, Vec2, Vec2> GETCurve(Vec2 AB,double CotAngleRatio)
        {
            ApolloCurveType type = new ApolloCurveType();
            Vec2 A_point,R_Direct;
            if (Math.Abs(CotAngleRatio - 1) < 0.000001)
            {
                type = ApolloCurveType.Line;
                A_point = AB / 2;
                R_Direct = AB.GetCrossVec2();
            }
            else {
                type = ApolloCurveType.Circle;
                double a =CotAngleRatio;
                A_point = AB * (a * a / (a * a - 1));
                R_Direct = new Vec2(2 * a * Math.Abs(a / (a * a - 1)), 0);
            }
            Tuple<ApolloCurveType, Vec2, Vec2> result = new Tuple<ApolloCurveType, Vec2, Vec2>(type, A_point, R_Direct);
            return result;
        }

        enum ApolloCurveType
        {
            Circle = 0,
            Line = 1,
        };

        public enum TriangleType
        {
            DengBian,
            DengYao,
            Yiban
        };

    }

    public struct Vec2
    {
        public double X;
        public double Y;
        public double Length
        {
            get
            {
                return Math.Sqrt(this.X * this.X + this.Y * this.Y);
            }
        }

        public Vec2(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public Vec2(Vec2 vec2)
        {
            this.X = vec2.X;
            this.Y = vec2.Y;
        }
        public static Vec2 operator +(Vec2 lhs, Vec2 vec)
        {
            Vec2 result = new Vec2(lhs);

            result.X += vec.X;
            result.Y += vec.Y;

            return result;
        }

        public static Vec2 operator -(Vec2 lhs, Vec2 vec)
        {
            Vec2 result = new Vec2(lhs);

            result.X -= vec.X;
            result.Y -= vec.Y;

            return result;
        }

        public static double operator *(Vec2 lhs, Vec2 vec)
        {
            double a = lhs.X * vec.X;
            double b = lhs.Y * vec.Y;
            return a + b;
        }

        public static Vec2 operator *(Vec2 lhs, double a)
        {
            Vec2 result = new Vec2(lhs);

            result.X *= a;
            result.Y *= a;

            return result;
        }

        public static Vec2 operator /(Vec2 lhs, double a)
        {
            Vec2 result = new Vec2(lhs);

            result.X /= a;
            result.Y /= a;

            return result;
        }

        public static bool operator ==(Vec2 lhs, Vec2 vec)
        {
            if (Math.Abs(lhs.X - vec.X) < 0.0000001 && Math.Abs(lhs.Y - vec.Y) < 0.0000001)
                return true;
            else
                return false;
        }

        public static bool operator !=(Vec2 lhs, Vec2 vec)
        {
            return !(lhs == vec);
        }

        public Vec2 GetCrossVec2()
        {
            Vec2 result = new Vec2(this.Y, -this.X);

            return result;
        }

    }
     
    public class CalCoord
    {
        double CB_Length, CA_Length;

        double CosMAC, CosMCA,CosMBC,CosMCB;
        /// <summary>
        /// 默认构建一个以CB、CA为坐标轴的空间直角坐标系（CA为正北方向）
        /// </summary>
        /// <param name="CB_Length"></param>
        /// <param name="CA_Length"></param>
        public CalCoord(double CB_Length,double CA_Length)
        {
            this.CB_Length = CB_Length;
            this.CA_Length = CA_Length;
        }
        /// <summary>
        /// Pitch  俯仰角  Horiz 水平角
        /// </summary>
        /// <param name="Angle_A_Horiz">AM的水平角</param>
        /// <param name="Angle_A_Pitch">AM的俯仰角</param>
        /// <param name="Angle_B_Horiz">BM的水平角</param>
        /// <param name="Angle_B_Pitch">BM的俯仰角</param>
        /// <param name="Angle_C_Horiz">CM的水平角</param>
        /// <param name="Angle_C_Pitch">CM的俯仰角</param>
        /// <returns>返回AM,CM,BM的距离</returns>
        public Tuple<double,double,double> SetCoord(double Angle_A_Horiz, double Angle_A_Pitch,double Angle_B_Horiz, double Angle_B_Pitch,double Angle_C_Horiz, double Angle_C_Pitch)
        {
            CosMAC = Math.Cos((180 - Angle_A_Horiz) * Math.PI / 180)*Math.Cos(Angle_A_Pitch*Math.PI/180);
            CosMCA = Math.Cos(Angle_C_Horiz * Math.PI / 180) * Math.Cos(Angle_C_Pitch * Math.PI / 180);
            //D为M在线段AC上的垂足 d为AD的距离
            double d = CA_Length / (1 + Math.Tan(Math.Acos(CosMAC)) / Math.Tan(Math.Acos(CosMCA)));
            double AM = Math.Abs(d / CosMAC);
            double CM = Math.Abs((CA_Length - d) / CosMCA);

            CosMCB = Math.Cos((90 - Angle_C_Horiz) * Math.PI / 180) * Math.Cos(Angle_C_Pitch * Math.PI / 180);
            double BM = Math.Sqrt(CM * CM + CB_Length * CB_Length - 2 * CM * CB_Length * CosMCB);

            Tuple<double, double, double> result = Tuple.Create<double, double, double>(AM, CM, BM);
            return result;
        }
    }
}
