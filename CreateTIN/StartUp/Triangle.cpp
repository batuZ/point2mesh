#include "stdafx.h"
#include "Triangle.h"

Triangle::Triangle(Point * a, Point * b, Point * c)
	:A(a), B(b), C(c), E1(new Edge(a, b)), E2(new Edge(b, c)), E3(new Edge(c, a))
{
	GetCenterPro();
}

Triangle::Triangle(Point * point, Edge * edge)
	: A(point), B(edge->Start), C(edge->End), E1(new Edge(point, edge->Start)), E2(edge), E3(new Edge(edge->End, point))
{
	GetCenterPro();
}

Triangle::~Triangle()
{
}

void Triangle::GetCenterPro()
{
	double x1, y1, x2, y2, x3, y3;
	x1 = A->X;
	y1 = A->Y;
	x2 = B->X;
	y2 = B->Y;
	x3 = C->X;
	y3 = C->Y;
	*m_centerX = ((y2 - y1) * (y3 * y3 - y1 * y1 + x3 * x3 - x1 * x1) - (y3 - y1) * (y2 * y2 - y1 * y1 + x2 * x2 - x1 * x1)) / (2 * (x3 - x1) * (y2 - y1) - 2 * ((x2 - x1) * (y3 - y1)));
	*m_centerY = ((x2 - x1) * (x3 * x3 - x1 * x1 + y3 * y3 - y1 * y1) - (x3 - x1) * (x2 * x2 - x1 * x1 + y2 * y2 - y1 * y1)) / (2 * (y3 - y1) * (x2 - x1) - 2 * ((y2 - y1) * (x3 - x1)));
	*m_Radius = pow(*m_centerX - x1, 2) + pow(*m_centerY - y1, 2);
}

bool Triangle::IsInCirclecircle(Point * point)
{
	return pow(point->X - *m_centerX, 2) + pow(point->Y - *m_centerY, 2) <= *m_Radius;
}

void Triangle::SuperTriangle()
{
	double minx = Point::pointList[0]->X;
	double miny = Point::pointList[0]->Y;
	double maxx = minx;
	double maxy = miny;

	for (size_t i = 0; i < Point::pointList.size; i++)
	{
		minx = Point::pointList[i]->X < minx ? Point::pointList[i]->X : minx;
		miny = Point::pointList[i]->Y < miny ? Point::pointList[i]->Y : miny;
		maxx = Point::pointList[i]->X > maxx ? Point::pointList[i]->X : maxx;
		maxy = Point::pointList[i]->Y > maxy ? Point::pointList[i]->Y : maxy;
	}
	double d = (maxx - minx > maxy - miny) ? maxx - minx : maxy - miny;
	double xmid = (minx + maxx) * 0.5;
	double ymid = (miny + maxy) * 0.5;
	Point* stpA = new Point(xmid, ymid + 2 * d, 0, -1);
	Point* stpB = new Point(xmid + 2 * d, ymid - d, 0, -2);
	Point* stpC = new Point(xmid - 2 * d, ymid - d, 0, -3);

	Triangle::triangleList.push_back(new Triangle(stpA,stpB,stpC));
}
