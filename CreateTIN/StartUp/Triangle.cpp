#include "stdafx.h"
#include "Triangle.h"

Triangle::Triangle(Point * a, Point * b, Point * c)
	:m_a(a), m_b(b), m_c(c), m_e1(&Edge(a, b)), m_e2(&Edge(b, c)), m_e3(&Edge(c, a))
{
	GetCenterPro();
}

Triangle::Triangle(Point * point, Edge * edge)
	: m_a(point), m_b(edge->GetStart()), m_c(edge->GetEnd()), m_e1(&Edge(m_a, m_b)), m_e2(edge), m_e3(&Edge(m_c, m_a))
{
	GetCenterPro();
}

Triangle::~Triangle()
{
}

void Triangle::GetCenterPro()
{
	double x1, y1, x2, y2, x3, y3;
	x1 = *m_a->GetX();
	y1 = *m_a->GetY();
	x2 = *m_b->GetX();
	y2 = *m_b->GetY();
	x3 = *m_c->GetX();
	y3 = *m_c->GetY();
	*m_centerX = ((y2 - y1) * (y3 * y3 - y1 * y1 + x3 * x3 - x1 * x1) - (y3 - y1) * (y2 * y2 - y1 * y1 + x2 * x2 - x1 * x1)) / (2 * (x3 - x1) * (y2 - y1) - 2 * ((x2 - x1) * (y3 - y1)));
	*m_centerY = ((x2 - x1) * (x3 * x3 - x1 * x1 + y3 * y3 - y1 * y1) - (x3 - x1) * (x2 * x2 - x1 * x1 + y2 * y2 - y1 * y1)) / (2 * (y3 - y1) * (x2 - x1) - 2 * ((y2 - y1) * (x3 - x1)));
	*m_Radius = pow(*m_centerX - x1, 2) + pow(*m_centerY - y1, 2);
}