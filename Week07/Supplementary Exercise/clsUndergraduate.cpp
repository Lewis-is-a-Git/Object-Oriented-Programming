#include "clsUndergraduate.h"

clsUndergraduate::clsUndergraduate(){

}
clsUndergraduate::clsUndergraduate(const clsUndergraduate& orig){

}

clsUndergraduate::~clsUndergraduate(){

}

clsUndergraduate::clsUndergraduate(string n, string sn, string prog, string m)
: clsStudent(n, sn, prog)
{
    major = m;
}

string clsUndergraduate::getMajor(){
    return major;
}

void clsUndergraduate::displayStudentDetails(){
    
}