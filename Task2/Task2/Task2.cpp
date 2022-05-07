#include <iostream>
#include "MyString.h"

int main() {
    MyString s1("Hello");
    MyString s2("World");
    MyString s3 = s1 + s2;
    std::cout << "Concatenated string: " << s3 << std::endl;
    std::cout << "Substring 'ell' found in s1: " << std::boolalpha << s1.findSubstring("ell") << std::endl;
    std::cout << "Length of s2: " << s2.length() << std::endl;
    std::cout << "s1 == s2: " << std::boolalpha << (s1 == s2) << std::endl;
    std::cout << "s1 != s2: " << std::boolalpha << (s1 != s2) << std::endl;
    std::cout << "Character at index 2 in s1: " << s1[2] << std::endl;
    MyString input;
    std::cout << "Enter a string: ";
    std::cin >> input;
    std::cout << "You entered: " << input << std::endl;
    return 0;
}
