#include "Tutorial.h"
//#include "clsStudent.h"
//#include <vector>

Tutorial::Tutorial(){
}

Tutorial::Tutorial(const Tutorial& orig){

}
Tutorial::~Tutorial(){

}

void Tutorial::addStudent(clsStudent* std){
    _students.push_back(std);
}

int Tutorial::getStudentCount(){
    return _students.size();
}

void Tutorial::displayAll(){
    for (int i = 0; i < _students.size(); i++){
        _students.at(i)->displayStudentDetails();
    }
}