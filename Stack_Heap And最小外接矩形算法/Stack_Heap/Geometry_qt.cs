using OSGeo.OGR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack_Heap
{
    public struct Point_qt
    {
        public double X;
        public double Y;
        public double Z;
        public double Rela_Ang;
        public int PID;

        public Point_qt(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
            this.Rela_Ang = 2;
            this.PID = -1;
        }
        public Point_qt(double x, double y, double z, double Rela_Ang)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
            this.Rela_Ang = Rela_Ang;
            this.PID = -1;
        }

        public Point_qt(double Rela_Ang)
        {
            this.X = 0;
            this.Y = 0;
            this.Z = 0;
            this.Rela_Ang = Rela_Ang;
            this.PID = -1;
        }
    }

    /// <summary>
    /// 该结构适用于计算SMBR
    /// </summary>
    struct Edge_qt
    {
        public Point_qt FromNode;
        public Point_qt ToNode;
        public Point_qt minXNode;
        public Point_qt MaxXNode;
        public double MaxY;
        public double minX;
        public double MaxX;
        public double Area_Enve;
    }

    class Geometry_qt : Geometry
    {
        private Envelope enve_MBR;

        public Geometry_qt(wkbGeometryType type):base(type){ }
        public Geometry_qt(IntPtr cPtr, bool cMemoryOwn, object parent) : base(cPtr, cMemoryOwn, parent) { }
        public Geometry_qt(wkbGeometryType type, string wkt, int wkb, IntPtr wkb_buf, string gml) : base(type, wkt, wkb, wkb_buf, gml) { }

        private Stack<Point_qt> GetConvexPolygonStack()
        {
            Stack<Point_qt> sta_Des = new Stack<Point_qt>();

            Stack<Point_qt> sta_Pnt = PutPoints2Stack();

            return sta_Des;
        }


        private void Init_enveMBR()
        {
            if (enve_MBR == null)
                enve_MBR = new Envelope();
        }

        /// <summary>
        /// 将Geometry里的Point压入Stack
        /// </summary>
        /// <returns></returns>
        private Stack<Point_qt> PutPoints2Stack()
        {
            Point_qt pnt_qt;
            Point_qt pnt_qt_1st;

            pnt_qt_1st = new Point_qt(this.GetX(0), this.GetY(0), this.GetZ(0));
            Stack<Point_qt> stack_pnts = new Stack<Point_qt>(this.GetPointCount());
            for (int i = 1; i < stack_pnts.Count; i++)
            {
                pnt_qt = new Point_qt(this.GetX(i), this.GetY(i), this.GetZ(i));
                if (pnt_qt.X < pnt_qt_1st.X)
                {
                    Swop(ref pnt_qt_1st, ref pnt_qt);
                }
                else if ((pnt_qt.X - pnt_qt_1st.X) < 0.000001 && pnt_qt.Y < pnt_qt_1st.Y)
                {
                    Swop(ref pnt_qt_1st, ref pnt_qt);
                }
                stack_pnts.Push(pnt_qt);
            }
            stack_pnts.Push(pnt_qt_1st);

            return stack_pnts;
        }

        /// <summary>
        /// 将Geometry里的Point压入List
        /// </summary>
        /// <returns></returns>
        private List<Point_qt> PutPoints2List()
        {
            Point_qt pnt_qt;

            List<Point_qt> list_pnts = new List<Point_qt>(this.GetPointCount());
            for (int i = 0; i < list_pnts.Count; i++)
            {
                pnt_qt = new Point_qt(this.GetX(i), this.GetY(i), this.GetZ(i));
                list_pnts.Add(pnt_qt);
            }
            return list_pnts;
        }

        private void Swop(ref Point_qt p1, ref Point_qt p2)
        {
            Point_qt ptemp;

            ptemp = p1;
            p1 = p2;
            p2 = ptemp;
        }

        private Stack<Point_qt> Run(Stack<Point_qt> sta_Pnt)
        {
            Stack<Point_qt> sta_Des = new Stack<Point_qt>(sta_Pnt.Count);
            //将第一个Pnt压入目标栈
            sta_Des.Push(sta_Pnt.Pop());
            return sta_Des;
        }

        private void paixu(ref List<Point_qt> list)
        {
            list.Sort((p1, p2) =>
            {
                return p1.Rela_Ang.CompareTo(p2.Rela_Ang);
            });
        }
    }
}
