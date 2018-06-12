#include "stdafx.h"
#include "Triangle.h"

Triangle::Triangle(Point * a, Point * b, Point * c)
	:m_a(a), m_b(b), m_c(c), m_e1(&Edge(a, b)), m_e2(&Edge(b, c)), m_e3(&Edge(c, a))
{
}

Triangle::Triangle(Point * point, Edge * edge)
	: m_a(point), m_b(edge->GetStart()), m_c(edge->GetEnd()), m_e1(&Edge(m_a, m_b)), m_e2(edge), m_e3(&Edge(m_c, m_a))
{
}

Triangle::~Triangle()
{
}
