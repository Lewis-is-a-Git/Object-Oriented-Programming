#include "clsPostGraduate.h"
#include <iostream>

clsPostgraduate::clsPostgraduate(){

}
clsPostgraduate::clsPostgraduate(const clsPostgraduate& orig){

} 

clsPostgraduate::~clsPostgraduate(){

}

clsPostgraduate::clsPostgraduate(string n, string sn, string prog, string rt, int g)
: clsStudent(n, sn, prog){
     researchTitle = rt;
     grant = g;
 }

 int clsPostgraduate::getGrant(){

     return grant;
 }

 void clsPostgraduate::displayStudentDetails(){
    cout << "name: " << name << endl;
    cout << "Student_no: " << student_no << endl;
    cout << "program: " << program << endl;
    cout << "researchTitle: " << researchTitle << endl;
    cout << "grant: " << grant << endl;
 }