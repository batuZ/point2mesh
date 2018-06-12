#pragma once
#include "Edge.h"
#include"Point.h"
class Triangle
{
private:
	Point *m_a, *m_b, *m_c;
	Edge *m_e1, *m_e2, *m_e3;
	double *m_centerX, *m_centerY, *m_Radius;
	void GetCenterPro();
public:
	Triangle(Point* a, Point* b, Point* c);
	Triangle(Point* point, Edge* edge);
	~Triangle();

	Point* GetPointA();
	Point* GetPointB();
	Point* GetPointC();
	Edge* GetEdge1();
	Edge* GetEdge2();
	Edge* GetEdge3();

	bool IsInCirclecircle(Point* point);

};

