//#include <iostream>
//using namespace std;
//class Node
//{
//public:
//	int data;
//	int row_position;
//	int column_position;
//	Node* next;
//	Node()
//	{
//
//	}
//	Node(int data2, int row_position2, int column_position2)
//	{
//		data = data2;
//		row_position = row_position2;
//		column_position = column_position2;
//		next = nullptr;
//	}
//};
//class SparseLinkedList
//{
//public:
//	Node* root;
//	SparseLinkedList()
//	{
//		root = nullptr;
//	}
//	void insert(int data2, int row, int column)
//	{
//		Node* temp = new Node(data2, row, column);
//		if (root == nullptr)
//		{
//			temp->next = root;
//			root = temp;
//		}
//		else
//		{
//			Node* temp2 = root;
//			while (temp2->next != nullptr)
//			{
//				temp2 = temp2->next;
//			}
//			temp2->next = temp;
//		}
//	}
//	void display()
//	{
//		Node* temp = root;
//		cout << "row position  : ";
//		while (temp != nullptr)
//		{
//			cout << temp->row_position << " ";
//			temp = temp->next;
//		}
//		temp = root;
//		cout << "column position  : ";
//		while (temp != nullptr)
//		{
//			cout << temp->column_position << " ";
//			temp = temp->next;
//		}
//		temp = root;
//		cout << "data  : ";
//		while (temp != nullptr)
//		{
//			cout << temp->data << " ";
//			temp = temp->next;
//		}
//	}
//};
//int main()
//{
//	int sparseMtarix[4][5] =
//	{
//		{0,0,3,0,4},
//		{0,0,5,7,0},
//		{0,0,0,0,0},
//		{0,2,6,0,0}
//	};
//	SparseLinkedList* ll = new SparseLinkedList();
//	int data2 = 0;
//	for (int i = 0; i < 4; i++)
//	{
//		for (int j = 0; j < 5; j++)
//		{
//			data2 = sparseMtarix[i][j];
//			if (data2 > 0)
//			{
//				ll->insert(data2, i, j);
//			}
//
//		}
//	}
//	ll->display();
//}