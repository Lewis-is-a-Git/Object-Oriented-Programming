/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/* 
 * File:   QuestionSet.h
 * Author: lewis
 *
 * Created on 6 November 2019, 2:41 PM
 */

#ifndef QUESTIONSET_H
#define QUESTIONSET_H
# include <list>
#include <vector>
#include <map>
#include "Question.h"

class QuestionSet {
public:
    QuestionSet(int setID, std::vector<Question*> questionList);
    QuestionSet(const QuestionSet& orig);
    virtual ~QuestionSet();
    
    std::vector<Question*> getQuestionList();
    void AddResult(std::string name, int score);
    void DisplayResults();
    std::map<std::string, int> getResults();
    int getId();
    int getNumberOfQuestions();
    int getNumberOfResults();
private:
    int _setID;
    std::vector<Question*> _questionList;
    std::map<std::string, int> _results;

};

#endif /* QUESTIONSET_H */

