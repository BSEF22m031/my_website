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
	void setMaxSpeed(int maxSpeed1)
	{
		maxSpeed = maxSpeed1;
	}
	int getMaxSpeed()const
	{
		return maxSpeed;
	}
	void displayVehicleClass()
	{
		cout << "\tthe Max speed of Vehicle is " << maxSpeed << endl;
	}
};
class Car :public Vehicle
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
	}
	void displayBaseClass()
	{
		cout << "\tthe speed of Car is " << speed << endl;
		//cout << "\tthe Max speed of Car is " << getMaxSpeed() << endl;
		displayVehicleClass();
	}
};
class Bicycle :public Vehicle
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
	}
	void displayBaseClass()
	{
		cout << "\tthe speed of Bicycle is " << speed << endl;
		cout << "\tthe Max speed of Bicycle is " << getMaxSpeed() << endl;
	}
};
int main()
{
	Car c1(60,140);
	Bicycle b1(10,30);
	c1.displayBaseClass();
	cout << "--------------------------\n";
	b1.displayBaseClass();

}