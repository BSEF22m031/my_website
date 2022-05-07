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
//	Node* sumTwoNodes(Node* temp5, Node* temp2)
//	{
//		SparseLinkedList* ll2 = new SparseLinkedList();
//		Node* temp3 = temp5;
//		
//		while (temp3 != nullptr)
//		{
//			Node* temp4 = temp2;
//			while (temp4 != nullptr)
//			{
//				if (temp3->row_position == temp4->row_position && temp3->column_position == temp4->column_position)
//				{
//					Node* temp = new Node(temp3->data + temp4->data, temp3->row_position, temp3->column_position);
//					if (ll2->root == nullptr)
//					{
//						temp->next = ll2->root;
//						ll2->root = temp;
//					}
//					else
//					{
//						Node* temp2 = ll2->root;
//						while (temp2->next != nullptr)
//						{
//							temp2 = temp2->next;
//						}
//						temp2->next = temp;
//					}
//				}
//				temp4 = temp4->next;
//			}
//			temp3 = temp3->next;
//		}
//		return ll2->root;
//	}
//};
//int main()
//{
//	SparseLinkedList* ll = new SparseLinkedList();
//	Node* first = nullptr;
//	/*first->next = new Node(6, 3, 1);
//	first->next->next = new Node(9, 3, 5);*/
//
//	Node* second = new Node(10, 1, 5);
//	second->next = new Node(16, 2, 1);
//	second->next->next = new Node(19, 3, 5);
//
//	Node* result = ll->sumTwoNodes(first, second);
//	while (result != nullptr)
//	{
//		cout << result->data << "\n";
//		result = result->next;
//	}
//}