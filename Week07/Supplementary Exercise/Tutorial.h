#ifndef TUTORIAL_H
#define TUTORIAL_H
#include <vector>
#include "clsStudent.h"

using namespace std;

class Tutorial{
public:
    Tutorial();
    Tutorial(const Tutorial& orig);
    virtual ~Tutorial();
    void addStudent(clsStudent* std);
    int getStudentCount();
    void displayAll();
private:
    vector<clsStudent*> _students;
};

#endif