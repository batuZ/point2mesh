﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Class1
    {
        public float[] tete(float[] a)
        {
            float[] k = null;
            if (a != null && a.Length > 0 && a.Length % 3 == 0)
            {
                PointList pList = new PointList();
                for (int i = 0; i < a.Length; i += 3)
                {
                    Point p = new Point(a[i], a[i + 1], a[i + 2]);
                    pList.pointList.Add(p);
                }

                Construction_TIN ct = new Construction_TIN(pList);
                TriangleList tl = ct.Triangle_const();

                if (tl.Count > 0)
                {
                    PointList tPoints = new PointList();
                    for (int i = 0; i < tl.Count; i++)
                    {
                        tPoints.pointList.Add(tl[i].A);
                        tPoints.pointList.Add(tl[i].B);
                        tPoints.pointList.Add(tl[i].C);
                    }
                    List<float> temp = new List<float>();
                    for (int i = 0; i < tPoints.Count; i++)
                    {
                        temp.Add(tPoints[i].X);
                        temp.Add(tPoints[i].Y);
                        temp.Add(tPoints[i].Z);
                    }
                    k = temp.ToArray();
                }
            }
            return k;
        }
    }


    // Construction_TIN核心代码

    class Construction_TIN
    {
        //声明一个点列表和一个三角形列表对象
        private PointList pointlist;
        private TriangleList triangles;

        //构造函数用于给以上声明的两个列表初始化
        public Construction_TIN(PointList points)
        {
            this.pointlist = points;
            this.triangles = new TriangleList();
        }

        //构建三角网
        public TriangleList Triangle_const()
        {

            //当点数大于等于三个时再进行三角网构建
            if (this.pointlist.Count < 3)
            {
                return null;
            }

            //点数超过两个个时，继续进行，第一步是生成超级三角形
            //调用PointList类中的SuperTriangle方法，获取超三角形
            //赋给Triangle的对象superTriangle
            Triangle superTriangle = this.pointlist.SuperTriangle();

            //将超三角形放入三角形集合（this.对象.泛型列表.对列表的操作）
            this.triangles.triangleList.Add(superTriangle);

            //定义超三角形顶点列表，仅用于装超三角形顶点
            Point[] superpoints
                = new Point[] { superTriangle.A, superTriangle.B, superTriangle.C };
            //遍历点列表中所有点
            for (int i = 0; i < this.pointlist.Count; i++)
            {
                //将点列表中第i点赋给新点类对象
                Point anewpoint = pointlist[i];
                //定义边列表类对象
                EdgeList edges = new EdgeList();

                //遍历形成的每个三角形，找出点所在的三角形
                for (int j = 0; j < triangles.Count; j++)
                {
                    //三角形列表对象（其外接圆包含插入点的三角形）
                    Triangle contain_triangle = triangles[j];

                    //当点在某个三角形（第j个）外接圆中
                    if (contain_triangle.IsInCirclecircle(anewpoint))
                    {
                        //将包含新插入点的三角形三条边插入边列表的末端
                        edges.edgeList.AddRange(new Edge[] { contain_triangle.Edge1, contain_triangle.Edge2, contain_triangle.Edge3 });
                        //在三角形列表中删除这个三角形
                        this.triangles.triangleList.Remove(contain_triangle);
                        //三角形列表减少一个，指针后退
                        j--;
                    }
                }
                //在边列表中删除重复边
                edges.RemoveDiagonal();
                //将新插点与所有边连接成三角形
                for (int m = 0; m < edges.Count; m++)
                {
                    this.triangles.triangleList.Add(new Triangle(anewpoint, edges[m]));
                }

            }
            // 遍历超级三角形的顶点，并删除超级三角形
            foreach (Point sp_point in superpoints)
            {
                // 寻找包含超级三角形顶点的三角形，存入“被删三角形列表”
                List<Triangle> rmvTriangles = this.triangles.FindByPoint(sp_point);

                // 判断“被删三角形列表”是否为空
                if (rmvTriangles != null)
                {
                    // 遍历被删三角形集合
                    foreach (Triangle rmvTriangle in rmvTriangles)
                    {
                        // 移除被删三角形
                        this.triangles.Remove(rmvTriangle);
                    }
                }
            }
            //返回三角形列表
            return this.triangles;

        }
    }




    //点类和点列表类
    class Point
    {
        //成员有两个——点的坐标
        public float X { get; private set; }
        public float Y { get; private set; }
        public float Z { get; set; }
        public int ids { get; set; }
        //构造函数：初始化点的成员
        public Point(float x, float y, float z = 0, int id = -1)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
            this.ids = id;
        }

        //方法：判断两个点是否重合，重合返回true，否则返回false
        public bool EqualPoints(Point newPoint)
        {
            const float tolerance = 0.00001f;
            if (Math.Abs(this.X - newPoint.X) < tolerance && Math.Abs(this.Y - newPoint.Y) < tolerance)
            {
                return true;
            }
            return false;
        }

    }

    //点列表的定义
    class PointList
    {
        //泛型，定义点列表
        public List<Point> pointList = new List<Point>();

        //将第i个单个点存入点列表
        public Point this[int i] { get { return pointList[i]; } }

        //定义变量Count用于存储点列表长度
        public int Count { get { return this.pointList.Count; } }

        //遍历所有已经点过的点，获取超三角形
        public Triangle SuperTriangle()
        {
            //定义四个变量，存储最大最小的横纵坐标值
            float xmax = this.pointList[0].X;
            float ymax = this.pointList[0].Y;

            float xmin = this.pointList[0].X;
            float ymin = this.pointList[0].Y;

            //遍历获取最大最小坐标值
            foreach (Point point in this.pointList)
            {
                if (point.X > xmax)
                {
                    xmax = point.X;
                }
                if (point.Y > ymax)
                {
                    ymax = point.Y;
                }
                if (point.X < xmin)
                {
                    xmin = point.X;
                }
                if (point.Y < ymin)
                {
                    ymin = point.Y;
                }
            }

            //用获取的最大最小横纵坐标值定义超三角形的三个顶点坐标
            //为保证能“包住”所有点，方法如此，不知怎么解释，不解释
            float dx = xmax - xmin;
            float dy = ymax - ymin;
            float d = (dx > dy) ? dx : dy;

            float xmid = (xmin + xmax) * 0.5f;
            float ymid = (ymin + ymax) * 0.5f;

            //用点类的构造函数定义超三角形三个顶点，并赋值
            Point superTA = new Point(xmid, ymid + 2 * d);
            Point superTB = new Point(xmid + 2 * d, ymid - d);
            Point superTC = new Point(xmid - 2 * d, ymid - d);

            //返回超三角形
            //构造函数Triangle（PointA，PointB,PointC）定义在Triangle类中
            return new Triangle(superTA, superTB, superTC);
        }
    }


    //边类和边列表类
    class Edge
    {
        //边成员声明并初始化
        public Point pa { get; private set; }
        public Point pb { get; private set; }

        //边类构造函数
        public Edge(Point pa, Point pb)
        {
            this.pa = pa;
            this.pb = pb;
        }

        //判断两条边是否相等（重合）
        public bool EqualsEdge(Edge other)
        {
            if ((this.pa.Equals(other.pa) && this.pb.Equals(other.pb))
                || (this.pa.Equals(other.pb) && this.pb.Equals(other.pa)))
            {
                return true;
            }

            return false;
        }
    }

    //边列表
    class EdgeList
    {
        //定义边列表
        public List<Edge> edgeList = new List<Edge>();

        public int Count { get { return this.edgeList.Count; } }

        public Edge this[int i] { get { return this.edgeList[i]; } }

        //删除重合边，并将重合边在列表中的序号存入indexList列表
        public void RemoveDiagonal()
        {
            List<int> indexList = new List<int>();

            for (int i = 0; i < this.edgeList.Count; i++)
            {
                for (int j = i + 1; j < this.edgeList.Count; j++)
                {
                    if (this.edgeList[i].EqualsEdge(this.edgeList[j]))
                    {
                        indexList.Add(i);
                        indexList.Add(j);
                        break;
                    }

                }
            }
            //排序
            indexList.Sort();
            //反序
            indexList.Reverse();
            //先删后画出的重合边
            foreach (int i in indexList)
            {
                this.edgeList.RemoveAt(i);
            }
        }
    }


    //三角形类及三角形列表类 
    class Triangle
    {
        //定义三角形类中点成员
        public Point A { get; private set; }
        public Point B { get; private set; }
        public Point C { get; private set; }

        //定义三角形类中的边成员
        public Edge Edge1 { get; private set; }
        public Edge Edge2 { get; private set; }
        public Edge Edge3 { get; private set; }

        //定义三角形外接圆及其半径平方
        public float circumCirlecenterX;
        public float circumCirlecenterY;
        public double circumCirleRadius2;

        //构造函数由点构成边，由点构成三角形
        public Triangle(Point A, Point B, Point C)
        {
            this.A = A;
            this.B = B;
            this.C = C;

            this.Edge1 = new Edge(A, B);
            this.Edge2 = new Edge(B, C);
            this.Edge3 = new Edge(C, A);
        }

        //构造函数“重载”，由点和边构成三角形
        public Triangle(Point point, Edge edge)
            : this(point, edge.pa, edge.pb)
        {
        }

        //判断点是否在三角形外接圆内部
        public bool IsInCirclecircle(Point Point)
        {
            //定义三角形顶点
            float x1, x2, x3, y1, y2, y3;

            //两点之间距离的平方
            double dist2;
            x1 = this.A.X;
            y1 = this.A.Y;
            x2 = this.B.X;
            y2 = this.B.Y;
            x3 = this.C.X;
            y3 = this.C.Y;

            //计算三角形外接圆圆心
            circumCirlecenterX = ((y2 - y1) * (y3 * y3 - y1 * y1 + x3 * x3 - x1 * x1) - (y3 - y1) * (y2 * y2 - y1 * y1 + x2 * x2 - x1 * x1)) / (2 * (x3 - x1) * (y2 - y1) - 2 * ((x2 - x1) * (y3 - y1)));
            circumCirlecenterY = ((x2 - x1) * (x3 * x3 - x1 * x1 + y3 * y3 - y1 * y1) - (x3 - x1) * (x2 * x2 - x1 * x1 + y2 * y2 - y1 * y1)) / (2 * (y3 - y1) * (x2 - x1) - 2 * ((y2 - y1) * (x3 - x1)));
            //计算外接圆半径的平方
            circumCirleRadius2
                = Math.Pow(circumCirlecenterX - x1, 2)
                + Math.Pow(circumCirlecenterY - y1, 2);
            //计算外接圆圆心和插入点距离的平方
            dist2
                = Math.Pow(Point.X - circumCirlecenterX, 2)
                + Math.Pow(Point.Y - circumCirlecenterY, 2);

            //在外接圆内部返回真，否则返回假
            if (dist2 <= circumCirleRadius2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //判断某一个三角形三个顶点A、B、C是否与stPoint相等，
        //有一个相等，则说明此三角形为包含超级三角形顶点的三角形,
        //则返回真
        internal bool ContainPoint(Point stPoint)
        {
            if (this.A.EqualPoints(stPoint) || this.B.EqualPoints(stPoint) || this.C.EqualPoints(stPoint))
            {
                return true;
            }

            return false;
        }
    }

    class TriangleList
    {
        //定义三角形列表
        public List<Triangle> triangleList = new List<Triangle>();

        public Triangle this[int i] { get { return this.triangleList[i]; } }

        public int Count { get { return this.triangleList.Count; } }


        //返回包含超三角形顶点的三角形列表（除去重复的，不重复的返回）
        internal List<Triangle> FindByPoint(Point stPoint)
        {

            List<Triangle> pTriangleList = new List<Triangle>();
            //遍历三角形列表
            foreach (Triangle triangle in triangleList)
            {
                //将包含超三角形顶点的三角形加入pTriangleList列表
                if (triangle.ContainPoint(stPoint))
                {
                    pTriangleList.Add(triangle);
                }
            }
            //去掉重复三角形
            //pTriangleList.Distinct();

            return pTriangleList;
        }

        //删除列表的第一个三角形
        internal void Remove(Triangle rmvTriangle)
        {
            triangleList.Remove(rmvTriangle);
        }
    }

}
/*
 fn openDWG =(
	resetMaxFile()
	filePath = getOpenFileName caption: "open DWG:" types: "DWG(*.dwg)|*.dwg|GeoTIFF(*.tif)|*.tif"
	importFile filePath
	)

fn getObjSet=(
	--points = $Point* as array
	max select all
	objSet=$
	arr=#()
	for obj in objSet do(
		append arr obj.pos.x
		append arr obj.pos.y
		append arr obj.pos.z
		)
	return arr
	)
	
fn sendToDoNet arr =(
	dotnet.loadassembly @"D:\MyCode\test\libformax\ClassLibrary1\bin\Debug\ClassLibrary1.dll"
	func = dotNetObject "ClassLibrary1.Class1"
	return func.tete(arr)
	)
	
fn createMesh res = (
	faces = #()
	faceid= #()
	for f=1 to res.count by 3 do(
		append faces [res[f],res[f+1],res[f+2]]
		) 
	for d = 1 to res.count/3 by 3 do (
		append faceid [d,d+1,d+2]
		)
	print res.count
	print faces
	faceid
 	mesh vertices:faces  faces:faceid
	)

--openDWG()
ds = getObjSet()
res = sendToDoNet(ds)
createMesh(res)
	
	
	
	
	
	
	
	
	
	
	
     
     
     
     
     
     
     
     */
