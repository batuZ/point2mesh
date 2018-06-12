#include "stdafx.h"
#include "Point.h"

Point::Point(double* x, double* y, double* z, int id)
{
	this->m_x = x;
	this->m_y = y;
	this->m_z = z;
	this->id = id;
	Point::PointList.push_back(this);
}

Point::~Point()
{
}

double* Point::GetX()
{
	return m_x;
}

double* Point::GetY()
{
	return m_y;
}

double* Point::GetZ()
{
	return m_z;
}

int Point::GetID()
{
	return id;
}