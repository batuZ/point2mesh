using OSGeo.GDAL;
using OSGeo.OGR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stack_Heap
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Point_qt p1;
            
            List<Point_qt> list = new List<Point_qt>();
            Random ran = new Random();
            for (int i = 0; i < 8; i++)
            {
                
                int a = ran.Next(1,20);
                double b = ran.NextDouble();
                p1 = new Point_qt(a);
                list.Add(p1);
            }
            List<Point_qt> list_pre = list;


            list.Sort((p, p2) =>
            {
                return p.Rela_Ang.CompareTo(p2.Rela_Ang);
            });
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Gdal.AllRegister();
            Ogr.RegisterAll();

            string strVectorFile = @"E:\D2E\temp14\Polygo,All.shp";
            string shpPath = @"E:\D2E\temp14\t_all.shp";
            DataSource ds = Ogr.Open(strVectorFile, 0);
            if (ds == null)
            {
                Console.WriteLine("打开文件【{0}】失败！", strVectorFile);
                return;
            }
            Layer oLayer = ds.GetLayerByIndex(0);
            Feature oFeature = null;

            //
            DataSource dst_DS = CreateSMBR.Instance.Gen_Datasource(shpPath);
            Layer dst_Lyr = CreateSMBR.Instance.Gen_SimplePolygonLyrByDS(dst_DS);


            while((oFeature = oLayer.GetNextFeature())!=null)
            {
                Geometry oGeometry = oFeature.GetGeometryRef();
                Geometry ogeo = oGeometry.GetGeometryRef(0);
                QTGeometry qtGeo = new QTGeometry(ogeo);
                List<Point_qt> list = qtGeo.GetSMBR();

                Geometry dst_geo = CreateSMBR.Instance.GetSMBR_Geometry(list);
                CreateSMBR.Instance.AddGeometry2Layer(dst_Lyr, dst_geo);
            }
            dst_Lyr.Dispose();
            dst_DS.Dispose();

            MessageBox.Show("a");
        }
    }
}
