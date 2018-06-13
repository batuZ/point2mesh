#include "stdafx.h"
#include "Edge.h"

Edge::Edge(Point * start, Point * end) :Start(start), End(end)
{
}

Edge::~Edge()
{
}

vector<Edge*> Edge::edgeList;

bool Edge::isSame(Edge * other)
{
	return	(Start == other->Start&&End == other->End) || (Start == other->End&&End == other->Start);
}
