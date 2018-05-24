public class MyFunc
{
    public class CalCoord
    {
        double CB_Length, CA_Length;

        double CosMAC, CosMCA, CosMBC, CosMCB;
        /// <summary>
        /// 默认构建一个以CB、CA为坐标轴的空间直角坐标系（CA为正北方向）
        /// </summary>
        /// <param name="CB_Length"></param>
        /// <param name="CA_Length"></param>
        public CalCoord(double CB_Length, double CA_Length)
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
        public Tuple<double, double, double> SetCoord(
            double Angle_A_Horiz,
            double Angle_A_Pitch, 
            double Angle_B_Horiz, 
            double Angle_B_Pitch, 
            double Angle_C_Horiz, 
            double Angle_C_Pitch)
        {
            CosMAC = Math.Cos((180 - Angle_A_Horiz) * Math.PI / 180) * Math.Cos(Angle_A_Pitch * Math.PI / 180);
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