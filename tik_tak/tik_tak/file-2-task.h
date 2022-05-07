#ifndef LRU_CACHE_H
#define LRU_CACHE_H

struct Node {
    int page;
    Node* next;
    Node* prev;

    Node(int p) : page(p), next(nullptr), prev(nullptr) {}
};

class LRUCache
{
private:
    int capacity;
    int size;
    Node* front;
    Node* rear;
    int page_hits;
    int page_faults;

public:
    LRUCache(int cap);
    void accessPage(int page);
    void moveToFront(Node* node);
    void addToFront(int page);
    void removeRear();
    void printStats();
};

#endif
