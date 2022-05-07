#include "lru_cache.h"
#include <iostream>
using namespace std;
LRUCache::LRUCache(int cap) : capacity(cap), size(0), front(nullptr), rear(nullptr), page_hits(0), page_faults(0) {}

void LRUCache::accessPage(int page) {
    Node* temp = front;

    while (temp != nullptr) {
        if (temp->page == page) {
            page_hits++;
            moveToFront(temp);
            return;
        }
        temp = temp->next;
    }

    page_faults++;

    if (size == capacity) {
        removeRear();
    }

    addToFront(page);
}

void LRUCache::moveToFront(Node* node) {
    if (node == front) {
        return;
    }

    if (node == rear) {
        rear = rear->prev;
        rear->next = nullptr;
    }
    else {
        node->prev->next = node->next;
        node->next->prev = node->prev;
    }

    node->next = front;
    node->prev = nullptr;
    front->prev = node;
    front = node;
}

void LRUCache::addToFront(int page) {
    Node* newNode = new Node(page);

    if (size == 0) {
        front = rear = newNode;
    }
    else {
        newNode->next = front;
        front->prev = newNode;
        front = newNode;
    }

    size++;
}

void LRUCache::removeRear() {
    if (size == 0) {
        return;
    }

    Node* temp = rear;

    if (size == 1) {
        front = rear = nullptr;
    }
    else {
        rear = rear->prev;
        rear->next = nullptr;
    }

    delete temp;
    size--;
}

void LRUCache::printStats() {
    cout << page_hits << endl;
    cout << page_faults << endl;
}
