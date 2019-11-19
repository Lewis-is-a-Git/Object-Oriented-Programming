#include "clsStudent.h"

clsStudent::clsStudent() {

}
clsStudent::clsStudent(const clsStudent& orig){

}

clsStudent::~clsStudent(){

}

clsStudent::clsStudent(string n, string sn, string prog){
    name = n;
    student_no = sn;
    program = prog;
}