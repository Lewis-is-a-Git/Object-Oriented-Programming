/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/* 
 * File:   Student.h
 * Author: lewis
 *
 * Created on 6 November 2019, 2:40 PM
 */

#ifndef STUDENT_H
#define STUDENT_H
#include "QuestionSet.h"
#include "Question.h"
#include "User.h"

class Student : public User {
public:
    Student(std::string name);
    Student(const Student& orig);
    virtual ~Student();
    QuestionSet* AttemptSet(QuestionSet* questionSet);
private:
    bool AttemptQuestion(Question* q);
};

#endif /* STUDENT_H */

