#ifndef CLSUNDERGRADUATE_H
#define CLSUNDERGRADUATE_H
#include "clsStudent.h"
#include <string>
#include <iostream>
using namespace std;
class clsUndergraduate:public clsStudent{
    public:
    clsUndergraduate();
    clsUndergraduate(const clsUndergraduate& orig);
    virtual ~clsUndergraduate();
    clsUndergraduate(string n, string sn, string prog, string m);
    string getMajor();
    void displayStudentDetails();
    private:
    string major;
};

#endif