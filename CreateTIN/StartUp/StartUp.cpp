// StartUp.cpp : �������̨Ӧ�ó������ڵ㡣
//

#include "stdafx.h"
#include "Triangle.h"
#include "Edge.h"
#include "Point.h"

int main()
{
	Triangle::SuperTriangle(Point::pointList);
	for (size_t i = 0; i < Point::pointList.size() - 3; i++)
	{
		vector<Edge*> tEdges;
		vector<Triangle*>::iterator it = Triangle::triangleList.begin();
		for (; it != Triangle::triangleList.end();it++)
		{
			
			Triangle::triangleList.erase(it);
		}
	}
	return 0;
}

