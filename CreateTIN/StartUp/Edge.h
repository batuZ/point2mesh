#pragma once
#include"Point.h"
class Edge
{
private:
	Point* m_start;
	Point* m_end;
public:
	Edge(Point* s,Point* e);
	~Edge();
	Point* GetStart();
	Point* GetEnd();
	bool isSame(Edge* other);
	static vector<Edge*> edgeList;
};

