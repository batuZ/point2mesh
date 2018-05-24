using OSGeo.OGR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack_Heap
{
    public class CreateSMBR
    {
        private static CreateSMBR _instance = null;
        private CreateSMBR() { }
        public static CreateSMBR Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CreateSMBR();
                }
                return _instance;
            }
        }

        public void GeneralSMBR2Shp(string shpfilePath, List<Point_qt> list)
        {
            Ogr.RegisterAll();
            // 为了支持中文路径，请添加下面这句代码
            OSGeo.GDAL.Gdal.SetConfigOption("GDAL_FILENAME_IS_UTF8", "NO");
            // 为了使属性表字段支持中文，请添加下面这句
            OSGeo.GDAL.Gdal.SetConfigOption("SHAPE_ENCODING", "");

            if (File.Exists(shpfilePath))
                File.Delete(shpfilePath);
            string strDriverName = "ESRI Shapefile";
            Driver oDriver = Ogr.GetDriverByName(strDriverName);
            if (oDriver == null)
            {
                Console.WriteLine("%s 驱动不可用！\n", shpfilePath);
                return;
            }

            // 创建数据源
            DataSource oDS = oDriver.CreateDataSource(shpfilePath, null);
            if (oDS == null)
            {
                Console.WriteLine("创建矢量文件【%s】失败！\n", shpfilePath);
                return;
            }

            Layer oLayer = oDS.CreateLayer("TestP", null, wkbGeometryType.wkbPolygon, null);
            if (oLayer == null)
            {
                Console.WriteLine("图层创建失败！\n");
                return;
            }

            FieldDefn oFieldID = new FieldDefn("FieldID", FieldType.OFTInteger);
            oLayer.CreateField(oFieldID, 1);

            FeatureDefn oDefn = oLayer.GetLayerDefn();

            Feature oFeatureRect = new Feature(oDefn);
            oFeatureRect.SetField(0, 0);
            Geometry geomRectangle = new Geometry(wkbGeometryType.wkbLinearRing);
            
            for (int i = 0; i < list.Count; i++)
            {
                geomRectangle.AddPoint_2D(list[i].X, list[i].Y);
            }
            geomRectangle.AddPoint_2D(list[0].X, list[0].Y);

            Geometry geo = new Geometry(wkbGeometryType.wkbPolygon);
            geo.AddGeometryDirectly(geomRectangle);
            oFeatureRect.SetGeometry(geo);
            
            oLayer.CreateFeature(oFeatureRect);

            oDS.Dispose();
        }

        public Geometry GetSMBR_Geometry(List<Point_qt> list)
        {
            Geometry geomRectangle = new Geometry(wkbGeometryType.wkbLinearRing);

            for (int i = 0; i < list.Count; i++)
            {
                geomRectangle.AddPoint_2D(list[i].X, list[i].Y);
            }
            geomRectangle.AddPoint_2D(list[0].X, list[0].Y);

            Geometry geo = new Geometry(wkbGeometryType.wkbPolygon);
            geo.AddGeometryDirectly(geomRectangle);
            return geo;
        }

        public void AddGeometry2Layer(Layer oLayer, Geometry geo)
        {
            if (oLayer == null||oLayer.GetGeomType()!=wkbGeometryType.wkbPolygon)
            {
                Console.WriteLine("图层读取错误！\n");
                return;
            }
            FeatureDefn oDefn = oLayer.GetLayerDefn();

            Feature oFeatureRect = new Feature(oDefn);
            oFeatureRect.SetGeometry(geo);

            oLayer.CreateFeature(oFeatureRect);
        }

        public DataSource Gen_Datasource(string shpfilePath)
        {
            Ogr.RegisterAll();
            // 为了支持中文路径，请添加下面这句代码
            OSGeo.GDAL.Gdal.SetConfigOption("GDAL_FILENAME_IS_UTF8", "NO");
            // 为了使属性表字段支持中文，请添加下面这句
            OSGeo.GDAL.Gdal.SetConfigOption("SHAPE_ENCODING", "");

            if (File.Exists(shpfilePath))
                File.Delete(shpfilePath);
            string strDriverName = "ESRI Shapefile";
            Driver oDriver = Ogr.GetDriverByName(strDriverName);
            if (oDriver == null)
            {
                Console.WriteLine("%s 驱动不可用！\n", shpfilePath);
                return null;
            }

            // 创建数据源
            DataSource oDS = oDriver.CreateDataSource(shpfilePath, null);
            if (oDS == null)
            {
                Console.WriteLine("创建矢量文件【%s】失败！\n", shpfilePath);
                return null;
            }

            return oDS;
        }

        public Layer Gen_SimplePolygonLyrByDS(DataSource oDS)
        {
            Layer oLayer = oDS.CreateLayer("TestP", null, wkbGeometryType.wkbPolygon, null);
            if (oLayer == null)
            {
                Console.WriteLine("图层创建失败！\n");
            }
            return oLayer;
        }
    }
}
