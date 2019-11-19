#ifndef CLSPOSTGRADUATE_H
#define CLSPOSTGRADUATE_H
#include <string>
#include "clsStudent.h"
using namespace std;
class clsPostgraduate:public clsStudent{
    public:
    clsPostgraduate();
    clsPostgraduate(const clsPostgraduate& orig);
    virtual ~clsPostgraduate();
    clsPostgraduate(string n, string sn, string prog, string rt, int g);
    int getGrant();
    void displayStudentDetails();
    private:
    string researchTitle;
    int grant;
};

#endif