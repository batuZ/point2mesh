#pragma once
#include "Edge.h"
#include "Point.h"
class Triangle
{
private:
	double *m_centerX, *m_centerY, *m_Radius;
	void GetCenterPro();

public:
	Triangle(Point* a, Point* b, Point* c);
	Triangle(Point* point, Edge* edge);
	~Triangle();
	Point *A, *B, *C;
	Edge *E1, *E2, *E3;

	bool IsInCirclecircle(Point* point);

	static vector<Triangle*>triangleList;
	static void SuperTriangle(vector<Point*> points);
	static void RemoveSupers();
};

