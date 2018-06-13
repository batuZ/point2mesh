#pragma once
#include"Point.h"

class Edge
{
public:
	Edge(Point* start,Point* end);
	~Edge();
	Point *Start, *End;
	bool isSame(Edge* other);
	static vector<Edge*> edgeList;
};

