#ifndef CLSSTUDENT_H
#define CLSSTUDENT_H

#include <string>
using namespace std;

class clsStudent{
public:
    clsStudent();
    clsStudent(const clsStudent& orig);
    virtual ~clsStudent();
    clsStudent(string n, string sn, string prog);
    virtual void displayStudentDetails() = 0;
private:


protected:
    string name, student_no, program;
};
#endif // CLSSTUDENT_H