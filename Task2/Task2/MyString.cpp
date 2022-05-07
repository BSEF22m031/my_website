#include "MyString.h"
#include <cstring>

MyString::MyString() {
    s = nullptr;
}

MyString::MyString(const char* str) {
    size_t len = strlen(str);
    s = new char[len + 1];
    strcpy_s(s, len + 1, str);
}

MyString::~MyString() {
    delete[] s;
}

MyString::MyString(const MyString& other) {
    size_t len = strlen(other.s);
    s = new char[len + 1];
    strcpy_s(s, len + 1, other.s);
}

MyString MyString::concatenate(const MyString& other) const {
    size_t len1 = strlen(s);
    size_t len2 = strlen(other.s);
    MyString result;
    result.s = new char[len1 + len2 + 1];
    strcpy_s(result.s, len1 + len2 + 1, s);
    strcat_s(result.s, len1 + len2 + 1, other.s);
    return result;
}

bool MyString::findSubstring(const char* substr) const {
    return (strstr(s, substr) != nullptr);
}

size_t MyString::length() const {
    return strlen(s);
}

MyString MyString::operator+(const MyString& other) const {
    return concatenate(other);
}

bool MyString::operator==(const MyString& other) const {
    return (strcmp(s, other.s) == 0);
}

bool MyString::operator!=(const MyString& other) const {
    return !(*this == other);
}

char MyString::operator[](int index) const {
    return s[index];
}
