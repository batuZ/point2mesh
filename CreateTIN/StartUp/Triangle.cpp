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

vector<Triangle*> Triangle::triangleList;

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

void Triangle::SuperTriangle(vector<Point*> points)
{
	double minx = points[0]->X;
	double miny = points[0]->Y;
	double maxx = minx;
	double maxy = miny;

	for (auto var : points)
	{
		minx = var->X < minx ? var->X : minx;
		miny = var->Y < miny ? var->Y : miny;
		maxx = var->X > maxx ? var->X : maxx;
		maxy = var->Y > maxy ? var->Y : maxy;
	}
	double d = (maxx - minx > maxy - miny) ? maxx - minx : maxy - miny;
	double xmid = (minx + maxx) * 0.5;
	double ymid = (miny + maxy) * 0.5;
	Point* stpA = new Point(xmid, ymid + 2 * d, 0, -1);
	Point* stpB = new Point(xmid + 2 * d, ymid - d, 0, -2);
	Point* stpC = new Point(xmid - 2 * d, ymid - d, 0, -3);

	triangleList.push_back(new Triangle(stpA, stpB, stpC));
}

void Triangle::RemoveSupers()
{
	for (auto it = triangleList.begin(); it != triangleList.end();)
		if ((*it)->A->ID < 0 || (*it)->B->ID < 0 || (*it)->C->ID < 0)
			triangleList.erase(it);
		else
			it++;
}
