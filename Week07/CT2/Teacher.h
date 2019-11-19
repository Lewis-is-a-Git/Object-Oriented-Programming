/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/* 
 * File:   Teacher.h
 * Author: lewis
 *
 * Created on 6 November 2019, 2:40 PM
 */

#ifndef TEACHER_H
#define TEACHER_H
#include "User.h"
#include "Question.h"
#include "QuestionSet.h"
#include <vector>

class Teacher : public User {
public:
    Teacher(std::string name);
    Teacher(const Teacher& orig);
    virtual ~Teacher();
    void CreateQuestion();
    void DeleteQuestion(int questionId);
    void DeleteQuestionSet(int setId);
    void CreateQuestionSet(std::vector<int> ids, int setId);
    void AddQuestion(Question *q);
    QuestionSet* getQuestionSet(int setId);
    void AddResult(QuestionSet* qSet);
    void DisplaySetResults(std::vector<int> setIds);
    int getQuestionPoolSize();
    int getNumberOfSets();
private:
    std::vector<QuestionSet*> _questionSets;
    std::vector<Question*> _questionPool;
};

#endif /* TEACHER_H */

