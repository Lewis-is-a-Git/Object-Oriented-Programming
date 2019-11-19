#include <cstdlib>
#include "clsPostGraduate.h"
#include "clsUndergraduate.h"
#include "Tutorial.h"
#include <iostream>
#include <string>
using namespace std;

int main(int argc, char const *argv[])
{
    clsPostgraduate* s = new clsPostgraduate("a", "b", "c", "d", 1);
    clsUndergraduate* s2 = new clsUndergraduate("a", "b", "c", "d");

    Tutorial *t = new Tutorial();
    t->addStudent(s);
    t->displayAll();

    return 0;
}

