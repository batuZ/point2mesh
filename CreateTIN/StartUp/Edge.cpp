#include "stdafx.h"
#include "Edge.h"
#include"Point.h"

Edge::Edge(Point * start, Point * end) :Start(start), End(end)
{
}

Edge::~Edge()
{
}

bool Edge::isSame(Edge * other)
{
	return	(Start == other->Start&&End == other->End) || (Start == other->End&&End == other->Start);
}
