//#include <iostream>
//using namespace std;
//
//void merge(int leftArr[], int leftSize, int rightArr[], int rightSize, int arr[])
//{
//    int i = 0, l = 0, r = 0;
//
//    while (l < leftSize && r < rightSize)
//    {
//        if (leftArr[l] < rightArr[r])
//        {
//            arr[i++] = leftArr[l++];
//        }
//        else
//        {
//            arr[i++] = rightArr[r++];
//        }
//    }
//
//    while (l < leftSize) {
//        arr[i++] = leftArr[l++];
//    }
//
//    while (r < rightSize) {
//        arr[i++] = rightArr[r++];
//    }
//}
//
//void mergeSort(int arr[], int size) {
//    if (size <= 1) {
//        return; 
//    }
//
//    int middle = size / 2;
//    int* leftArray = new int[middle];
//    int* rightArray = new int[size - middle];
//
//    for (int i = 0; i < middle; i++) {
//        leftArray[i] = arr[i];
//    }
//
//    for (int i = middle; i < size; i++) {
//        rightArray[i - middle] = arr[i];
//    }
//
//    mergeSort(leftArray, middle);
//    mergeSort(rightArray, size - middle);
//    merge(leftArray, middle, rightArray, size - middle, arr);
//
//    delete[] leftArray;
//    delete[] rightArray;
//}
//
//void display(int arr[], int size) {
//    for (int i = 0; i < size; i++) {
//        cout << arr[i] << " ";
//    }
//    cout << endl;
//}
//
//int main() {
//    int arr[] = { 2, 7, 8, 5, 9, 6, 4, 1, -4, -9, -0, 889, -988534, 3, 0 };
//    int size = sizeof(arr) / sizeof(arr[0]);
//    mergeSort(arr, size);
//    display(arr, size);
//}