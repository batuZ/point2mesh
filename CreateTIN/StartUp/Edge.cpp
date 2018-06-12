#include "stdafx.h"
#include "Edge.h"
#include"Point.h"
Edge::Edge(Point * s, Point * e) :m_start(s), m_end(e)
{
}
Edge::~Edge()
{
}
Point * Edge::GetStart()
{
	return m_start;
}
Point * Edge::GetEnd()
{
	return m_end;
}
bool Edge::isSame(Edge * other)
{
	return (this->m_start == other->m_start && this->m_end == other->m_end) ||
		(this->m_end == other->m_start && this->m_start == other->m_end);
}
