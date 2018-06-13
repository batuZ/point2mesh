#include "stdafx.h"
#include "Point.h"

Point::Point(double x, double y, double z, int id) :X(x), Y(y), Z(z), ID(id)
{
}

Point::~Point()
{
}

vector<Point*> Point::pointList;