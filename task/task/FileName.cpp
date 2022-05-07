#include <iostream>
using namespace std;
class Vehicle
{
	int maxSpeed;
public:
	Vehicle()
	{
		maxSpeed = 0;
	}
	void setMaxSpeed(int speed1)
	{
		maxSpeed = speed1;
	}
	int getMaxSpeed() const
	{
		return maxSpeed;
	}
};
class Car: public Vehicle
{
	int speed;
public:
	Car()
	{
		speed = 0;
	}
	Car(int speed1, int maxSpeed1) : speed(speed1)
	{
		setMaxSpeed(maxSpeed1);
	};
	void display()
	{
		cout << "\tthe speed of car is " << speed << endl;
		cout << "\tthe max speed of car is " << getMaxSpeed() << endl;
	}
};
class Bicycle : public Vehicle
{
	int speed;
public:
	Bicycle()
	{
		speed = 0;
	}
	Bicycle(int speed1, int maxSpeed1) : speed(speed1)
	{
		setMaxSpeed(maxSpeed1);
	};
	void display()
	{
		cout << "\tthe speed of Bicycle is " << speed << endl;
		cout << "\tthe max speed of Bicycle is " << getMaxSpeed() << endl;
	}
};
int main()
{
	Car c1(60, 140);
	Bicycle b1(10, 30);
	c1.display();
	cout << "--------------------------";
	b1.display();
}
