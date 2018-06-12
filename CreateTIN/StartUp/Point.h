#pragma once
class Point
{
public:
	static vector<Point*> pointList;
	Point(double x, double y, double z, int id = -1);
	~Point();
	double X;
	double Y;
	double Z;
	int ID;
};

