using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetCoord2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Vec2 AB = new Vec2(10.0, 0);
            Vec2 BC = new Vec2(-10, 10);
            Vec2 AC = new Vec2(0, 10);

            double CotMAm = 1 / Math.Tan(35.26438968 * Math.PI / 180);
            double CotMBm = 1 / Math.Tan(42 * Math.PI / 180);
            double CotMCm = 1 / Math.Tan(41.8103149 * Math.PI / 180);

            GetCoord gc = new GetCoord(AB, AC, BC);
            gc.SetPAngles(CotMAm, CotMBm, CotMCm);
            Tuple<double, double, double> re = gc.GetXYZ();
        }

    }
}
