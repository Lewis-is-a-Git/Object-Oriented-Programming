/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/* 
 * File:   Student.cpp
 * Author: lewis
 * 
 * Created on 6 November 2019, 2:40 PM
 */

#include "Student.h"
#include <iostream>

Student::Student(std::string name) : User(name){}

Student::~Student() {
}

/**
 * Students can attempt a question set
 * @param questionSet question set to attempt
 * @return updated question set with new result
 */
QuestionSet* Student::AttemptSet(QuestionSet* questionSet){
    int score = 0;
    for (int i = 0; i < questionSet->getQuestionList().size(); i++){
        if (AttemptQuestion(questionSet->getQuestionList()[i])){
            score++;
        }
    }
    // Result is added to the set
    questionSet->AddResult(_name, score);
    // Result is displayed to the student
    std::cout << "You scored: " 
              << score << "/" << questionSet->getQuestionList().size() 
              << std::endl;
    return questionSet;
}

/**
 * private utility function, each question in the set is attempted by the student.
 * @param q question to attempt
 * @return correctly answered
 */
bool Student::AttemptQuestion(Question* q){
    bool correct = false;
    
    q->Display();
    int choice = 0;
    (std::cin >> choice).get();
    if (choice == q->getAnswer()){
        correct = true;
    }
    
    return correct;
}