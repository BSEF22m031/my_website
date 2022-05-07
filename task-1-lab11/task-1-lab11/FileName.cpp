#include <iostream>
using namespace std;

template<typename T>
T* sumArrays(const T arr1[], const T arr2[], int size)
{
    T* newArray = new T[size]; 

    for (int i = 0; i < size; ++i)
    {
        newArray[i] = arr1[i] + arr2[i];
    }

    return newArray;
}

int main() 
{
    const int size = 5;
    int integerArray1[size] = { 1, 2, 3, 4, 5 };
    int integerArray2[size] = { 6, 7, 8, 9, 10 };
    float floatArray3[size] = { 1.5, 2.5, 3.5, 4.5, 5.5 };
    float floatArray4[size] = { 6.5, 7.5, 8.5, 9.5, 10.5 };

    int* intResult = sumArrays(integerArray1, integerArray2, size);
    cout << "Sum of int arrays:";
    for (int i = 0; i < size; ++i) {
        cout << " " << intResult[i];
    }
    cout << endl;

    float* floatResult = sumArrays(floatArray3, floatArray4, size);
    cout << "Sum of float arrays:";
    for (int i = 0; i < size; ++i) {
       cout << " " << floatResult[i];
    }
    cout << endl;

    delete[] intResult;
    delete[] floatResult;

    return 0;
}