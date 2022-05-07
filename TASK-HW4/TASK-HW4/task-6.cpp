#include <iostream>
using namespace std;
int partition(int arr[], int start, int end)
{
    int pivot = arr[end];
    int i = start - 1;
    for (int j = start; j <= end; j++)
    {
        if (arr[j] < pivot)
        {
            i++;
            swap(arr[i], arr[j]);
        }
    }
    i++;
    swap(arr[i], arr[end]);
    return i;
}
void quickSort(int arr[], int start, int end)
{
    if (end <= start)
    {
        return;
    }
    int pivot = partition(arr, start, end);
    quickSort(arr, start, pivot - 1);
    quickSort(arr, pivot + 1, end);
}
//void displayR(int arr[],int index)
//{ 
//    cout << arr[index++];
//    displayR(arr,index);
//}
 void display(int arr[], int size)
 {
      for (int i = 0; i < size; i++)
      {
          cout << arr[i] << " ";
      }
     /*int i=0;
     cout << arr[i]<<" ";
     display(arr,size);*/
 }

int main()
{
    int arr[] = {2, 6, 9, 3, 1, 5, 4, 7, 0, 8};
    int size = sizeof(arr) / sizeof(arr[0]);
    quickSort(arr, 0, size - 1);
    display(arr, size);
}