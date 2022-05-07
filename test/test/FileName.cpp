#include "lru_cache.h"
#include <iostream>
using namespace std;
int main() {
    int n;
    cin >> n;

    LRUCache cache(n);

    int page;
    while (cin >> page) {
        cache.accessPage(page);
    }

    cache.printStats();

    return 0;
}
