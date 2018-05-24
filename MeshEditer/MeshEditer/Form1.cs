using OSGeo.GDAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MeshEditer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void but_dom_Click(object sender, EventArgs e)
        {
            open_dom.ShowDialog();
        }

        private void but_dem_Click(object sender, EventArgs e)
        {
            open_dem.ShowDialog();
        }

        private void but_txt_Click(object sender, EventArgs e)
        {
            open_txt.ShowDialog();
        }

        private void open_txt_FileOk(object sender, CancelEventArgs e)
        {
            but_txt.Text = open_txt.FileName;
            txtFile = open_txt.FileName;
            if (open_dom.FileName != "" && open_dem.FileName != "")
                but_run.Enabled = true;
        }

        private void open_dem_FileOk(object sender, CancelEventArgs e)
        {
            but_dem.Text = open_dem.FileName;
            demFile = open_dem.FileName;
            if (open_dom.FileName != "" && open_txt.FileName != "")
                but_run.Enabled = true;
        }

        private void open_dom_FileOk(object sender, CancelEventArgs e)
        {
            but_dom.Text = open_dom.FileName;
            domFile = open_dom.FileName;
            if (open_dem.FileName != "" && open_txt.FileName != "")
                but_run.Enabled = true;
        }

        //实例化一个点列表对象
        PointList points = new PointList();
        //定义一个三角形列表对象，并将三角形列表对象初始化为null，作为后续条件
        TriangleList triangles = null;

        string txtFile, demFile, domFile;
        double yuzhi;
        private void but_run_Click(object sender, EventArgs e)
        {
            if (txtFile == "" && demFile == "" && domFile == "" && yuzhi == null)
            {
                MessageBox.Show("请指定必要数据！");
                return;
            }
            using (System.IO.StreamWriter log = new System.IO.StreamWriter("a", false))
            {
                log.WriteLine(domFile);
                log.WriteLine(demFile);
                log.WriteLine(txtFile);
                log.WriteLine(yuzhi);
                log.Close();
            }
            string outMap = txtFile.Substring(0, txtFile.LastIndexOf(".")) + "_map.tif";
            if (File.Exists(outMap))
                File.Delete(outMap);
            //get三角形
            GetPointGroup afeat = new GetPointGroup(txtFile, demFile, yuzhi, domFile, outMap);
            points.pointList.AddRange(afeat.mapP);
            Construction_TIN delaunay = new Construction_TIN(this.points);
            triangles = delaunay.Triangle_const();
            // delaunay.getUsefulTriangles(afeat.geom);
            //输出脚本
            string outPath = txtFile.Substring(0, txtFile.LastIndexOf(".")) + "_res.txt";
            if (File.Exists(outPath))
                File.Delete(outPath);

            //输出所有点坐标
            //StreamWriter第二个参数为false覆盖现有文件，为true则把文本追加到文件末尾

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(outPath, true))
            {
                string vertices = "mesh vertices:#(";
                file.Write(vertices);
                for (int i = 0; i < afeat.mapP.Count; i++)
                {
                    string x = afeat.mapP[i].X.ToString();
                    string y = afeat.mapP[i].Y.ToString();
                    string z = afeat.mapP[i].Z.ToString();
                    string coor = x + "," + y + "," + z;
                    vertices = "[" + coor + "],";
                    if (i == (afeat.mapP.Count - 1))
                        vertices = "[" + coor + "]) ";
                    file.Write(vertices);
                }
                string faces = "faces:#(";
                file.Write(faces);
                for (int i = 0; i < triangles.Count; i++)
                {
                    string a = triangles[i].A.ids.ToString();
                    string b = triangles[i].B.ids.ToString();
                    string c = triangles[i].C.ids.ToString();
                    string ids = c + "," + b + "," + a;
                    faces = "[" + ids + "],";
                    if (i == (triangles.Count - 1))
                        faces = "[" + ids + "]) isSelected:on";
                    file.Write(faces);
                }

                file.Close();
            }
            MessageBox.Show("OK");
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            double userset;
            if (MetarnetRegex.IsNumber(textBox1.Text))
            {
                userset = Convert.ToDouble(textBox1.Text);
                textBox1.Text = userset.ToString();
                yuzhi = userset;
            }
            else
            {
                textBox1.Text = null;
                textBox1.Focus();
                MessageBox.Show("输入网格间距");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists("a"))
            {
                string[] lines = System.IO.File.ReadAllLines("a");
                domFile = lines[0]; but_dom.Text = lines[0];
                demFile = lines[1]; but_dem.Text = lines[1];
                txtFile = lines[2]; but_txt.Text = lines[2];
                yuzhi = Convert.ToDouble(lines[3]); textBox1.Text = lines[3];
                but_run.Enabled = true;
            }
        }

        /*  OUTput JPG
        private void btnOzil_Click(object sender, EventArgs e)
        {
            string openFileName = "";

            Gdal.AllRegister();

            //jpg格式不支持update        
            Dataset srcDs = Gdal.Open(openFileName, Access.GA_ReadOnly);
            Band srcBand1 = srcDs.GetRasterBand(1);
            Band srcBand2 = srcDs.GetRasterBand(2);
            Band srcBand3 = srcDs.GetRasterBand(3);

            DataType srcType = srcDs.GetRasterBand(1).DataType;

            //byte类型         

            int bandCount = srcDs.RasterCount;
            int srcWidth = srcDs.RasterXSize;
            int srcHeight = srcDs.RasterYSize;

            Debug.WriteLine("原始影像数据类型是：{0}", srcType);
            Debug.WriteLine("原始影像的列数：{0}", srcWidth);
            Debug.WriteLine("原始影像的行数：{0}", srcHeight);

            int[] bandArray = new int[bandCount];

            for (int i = 0; i < bandCount; i++)
            {
                bandArray[i] = i + 1;
            }

            int[] dstBandArray = new int[] { 1, 2, 3 };

            int[] dataArray1 = new int[srcWidth * srcHeight * bandCount];
            int[] dataArray2 = new int[srcWidth * srcHeight * bandCount];
            int[] dataArray3 = new int[srcWidth * srcHeight * bandCount];
            srcBand1.ReadRaster(0, 0, srcWidth, srcHeight, dataArray1, srcWidth, srcHeight, 0, 0);
            srcBand2.ReadRaster(0, 0, srcWidth, srcHeight, dataArray2, srcWidth, srcHeight, 0, 0);
            srcBand3.ReadRaster(0, 0, srcWidth, srcHeight, dataArray3, srcWidth, srcHeight, 0, 0);

            //注意，JPG没有实现Create方法来创建      
            //Dataset dstDs= drv.Create(dstFileName,srcWidth,srcHeight,bandCount,DataType.GDT_Byte,null); 

            //首先创建一个内存的驱动             
            string strMemory = @"E:tempMemory.jpg";
            Driver dryMemory = Gdal.GetDriverByName("MEM");

            //Dataset dsMemory = dryMemory.Create(strMemory, srcWidth, srcHeight,bandCount, DataType.GDT_Byte, null);
            Dataset dsMemory = dryMemory.Create(strMemory, srcWidth, srcHeight, 3, DataType.GDT_Byte, null);
            Band memBand1 = dsMemory.GetRasterBand(1);
            Band memBand2 = dsMemory.GetRasterBand(2);
            Band memBand3 = dsMemory.GetRasterBand(3);

            if (srcType == DataType.GDT_Byte)
            {
                int[] dataArray = new int[srcWidth * srcHeight * bandCount];

                srcDs.ReadRaster(0, 0, srcWidth, srcHeight, dataArray, srcWidth, srcHeight, bandCount, bandArray, 0, 0, 0);

                ///////////////////水平镜像实现//////////////////////
                //输出改变前的第200行             
                //Debug.WriteLine("改变前");         
                //for(int ii=0;ii<srcWidth;++ii)             
                //{                
                //    Debug.Write(dataArray[200*srcWidth+ii].ToString() + "  ");        
                //}               
                //Debug.WriteLine("改变后");       
                int temp;
                for (int i = 0; i < srcHeight; i++)
                {
                    for (int j = 0; j < srcWidth / 2; j++)
                    {
                        temp = dataArray1[i * srcWidth + j];
                        dataArray1[i * srcWidth + j] = dataArray1[i * srcWidth + (srcWidth - 1 - j)];
                        dataArray1[i * srcWidth + (srcWidth - 1 - j)] = temp;
                    }
                }
                for (int i = 0; i < srcHeight; i++)
                {
                    for (int j = 0; j < srcWidth / 2; j++)
                    {
                        temp = dataArray2[i * srcWidth + j];
                        dataArray2[i * srcWidth + j] = dataArray2[i * srcWidth + (srcWidth - 1 - j)];
                        dataArray2[i * srcWidth + (srcWidth - 1 - j)] = temp;
                    }
                }
                for (int i = 0; i < srcHeight; i++)
                {
                    for (int j = 0; j < srcWidth / 2; j++)
                    {
                        temp = dataArray3[i * srcWidth + j];
                        dataArray3[i * srcWidth + j] = dataArray3[i * srcWidth + (srcWidth - 1 - j)];
                        dataArray3[i * srcWidth + (srcWidth - 1 - j)] = temp;
                    }
                }
                memBand1.WriteRaster(0, 0, srcWidth, srcHeight, dataArray1, srcWidth, srcHeight, 0, 0);
                memBand2.WriteRaster(0, 0, srcWidth, srcHeight, dataArray2, srcWidth, srcHeight, 0, 0);
                memBand3.WriteRaster(0, 0, srcWidth, srcHeight, dataArray3, srcWidth, srcHeight, 0, 0);
            }
            Driver drvJPG = Gdal.GetDriverByName("JPEG");
            string dstFileName = @"E:right_result_gyy.jpg";
            drvJPG.CreateCopy(dstFileName, dsMemory, 1, null, null, null);
            //最后释放资源           
            srcDs.Dispose();
            dsMemory.Dispose();
            MessageBox.Show("水平镜像：success");
        }*/
    }
}
