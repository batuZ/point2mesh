#pragma once
class Point
{
protected:
	double* m_x;
	double* m_y;
	double* m_z;
	int id;
public:
	vector<Point*> PointList;
	Point(double* x, double* y, double* z, int id = -1);
	~Point();
	double* GetX();
	double* GetY();
	double* GetZ();
	int GetID();
};

