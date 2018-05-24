using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetCoord
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            double AB = Convert.ToDouble(AB_text.Text);
            double BC = Convert.ToDouble(BC_text.Text);
            double AC = Convert.ToDouble(AC_text.Text);

            double MA = Convert.ToDouble(MA_text.Text);
            double MB = Convert.ToDouble(MB_text.Text);
            double MC = Convert.ToDouble(MC_text.Text);

            double PA = Convert.ToDouble(PA_text.Text);
            double PB = Convert.ToDouble(PB_text.Text);
            double PC = Convert.ToDouble(PC_text.Text);
            double PM = Convert.ToDouble(PM_text.Text);

            AB = 7.15;
            BC = 14.11;
            AC = 12.60;

            MA = 6.178;
            MB = 11.84;
            MC = 8.84;

            //PA = 12.6;
            //PB = 14.11;
            //PC = 10.2;
            //PM = 6.67;

            PA = 6.04;
            PB = 4.56;
            PC = 16.84;
            PM = 11.99;

            Tuple<double, double, double> MyM = Cal2(MA, MB, MC, AB, BC, AC);
            if (MyM == null)
            {
                MessageBox.Show("控制点数据测量有误，请重新测量！");
                return;
            }
            Tuple<double, double, double> P = Cal2(PA, PB, PC, AB, BC, AC);
            if (P == null)
            {
                MessageBox.Show("此点数据测量有误，请重新测量！");
                return;
            }
            Tuple<double, double, double> P_ = Tuple.Create<double, double, double>
                ((double)P.Item1, (double)P.Item2, -(double)P.Item3);
            double D =GetDisTance(MyM,P);
            double d =GetDisTance(MyM,P_);

            if (Math.Abs(D - PM) > Math.Abs(d - PM))
            {
                P = P_;
                D = d;
            }

            px_text.Text = P.Item1.ToString("0.00");
            py_text.Text = P.Item2.ToString("0.00");
            pz_text.Text = P.Item3.ToString("0.00");
            error_text.Text = (Math.Abs(PM - D) / PM).ToString("0.00%");
        }

        /// <summary>
        /// 坐标系：以A为原点的左手坐标系
        /// </summary>
        /// <param name="MA"></param>
        /// <param name="MB"></param>
        /// <param name="MC"></param>
        /// <param name="AB"></param>
        /// <param name="BC"></param>
        /// <param name="AC"></param>
        /// <returns></returns>
        public Tuple<double,double,double> Cal2(double MA,double MB,double MC,double AB,double BC,double AC)
        {
            double CosMAB = Math_Ex.GetCos(MA, MB, AB);
            double CosMAC = Math_Ex.GetCos(MA, MC, AC);
            double CosCAB = Math_Ex.GetCos(AB, BC, AC);
          
            double TanW = (CosMAC / CosMAB - CosCAB) / (Math.Sin(Math.Acos(CosCAB)));

            double cos_ = CosMAB / (Math.Cos(Math.Atan(TanW)));
            if (cos_ > 1)
                return null;
            double AO = MA*CosMAB / (Math.Cos(Math.Atan(TanW)));
            //以下求MA在Y轴上的投影
            double X = AO * (Math.Cos(Math.Atan(TanW)));
            double Y = AO * (Math.Sin(Math.Atan(TanW)));
            double Z = Math.Sqrt(MA * MA - AO * AO);

            Tuple<double, double, double> Coord = Tuple.Create<double, double, double>(X, Y, Z);

            return Coord;
        }

        private double GetDisTance(Tuple<double, double, double> p1, Tuple<double, double, double> p2)
        {
            double x = (double)p1.Item1-(double)p2.Item1;
            double y = (double)p1.Item2-(double)p2.Item2;
            double z = (double)p1.Item3-(double)p2.Item3;

            return Math.Sqrt(x * x + y * y + z * z);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("ts.txt", FileMode.Create, FileAccess.ReadWrite);
            fs.Close();
        }
    }
}
