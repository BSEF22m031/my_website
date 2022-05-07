#include <iostream>
using namespace std;
class Animal
{
	string type;
public:
	Animal()
	{
		type = " ";
	}
	void setType(string type1)
	{
		type = type1;
	}
	string getType() const
	{
		return type;
	}
};
class Dog: public Animal
{
	string sound;
public:
	Dog()
	{
		sound = "";
	}
	Dog(string type1, string sound1) : sound(sound1)
	{
		setType(type1);
	};
	void display()
	{
		cout << "\tthe type of dog is " << getType() << endl;
		cout << "\tthe voice of dog is " << sound << endl;
	}
};
class Turtle : public Animal
{
	string sound;
public:
	Turtle()
	{
		sound = "";
	}
	Turtle(string type1, string sound1) : sound(sound1)
	{
		setType(type1);
	};
	void display()
	{
		cout << "\tthe type of turtle is " << getType() << endl;
		cout << "\tthe voice of turtle is " << sound << endl;
	}
};
int main()
{
	Dog d1("mammal", "bark-bark");
	Turtle t1("reptiles", "tur-tur");
	d1.display();
	cout << "--------------------------\n";
	t1.display();
}
