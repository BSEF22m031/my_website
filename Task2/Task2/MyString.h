#ifndef MYSTRING_H
#define MYSTRING_H

#include <iostream>

class MyString {
private:
    char* s;

public:
    MyString();
    MyString(const char* str);
    ~MyString();
    MyString(const MyString& other);
    MyString concatenate(const MyString& other) const;
    bool findSubstring(const char* substr) const;
    size_t length() const;
    MyString operator+(const MyString& other) const;
    bool operator==(const MyString& other) const;
    bool operator!=(const MyString& other) const;
    char operator[](int index) const;
    friend std::ostream& operator<<(std::ostream& os, const MyString& str);
    friend std::istream& operator>>(std::istream& is, MyString& str);
};

#endif 

