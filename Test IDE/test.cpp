// A hello world program in C++

#include <iostream>
// #include "person.cpp"
using namespace std;

int main()
{
    int a = 4;
    cout << "a: " << a << "\n";
    int& b = a;
    cout << "b: " << b << "\n"; // reference
    int* c = &a;
    cout << "c: " << c << "\n"; // pointer
    int d = *c;
    cout << "d: " << d << "\n"; // d equals value of c
    
    return 0;
}