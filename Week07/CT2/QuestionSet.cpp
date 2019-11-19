/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/* 
 * File:   QuestionSet.cpp
 * Author: lewis
 * 
 * Created on 6 November 2019, 2:41 PM
 */

#include "QuestionSet.h"
#include <map>
#include <iostream>

/**
 * Constructor
 * @param setID unique integer for ID
 * @param questionList list of questions in this set
 */
QuestionSet::QuestionSet(int setID, std::vector<Question*> questionList) {
    _setID = setID;
    _questionList = questionList;
}

QuestionSet::QuestionSet(const QuestionSet& orig) {
}

QuestionSet::~QuestionSet() {
}

/**
 * Display each students results that have attempted this questions set
 */
void QuestionSet::DisplayResults(){
    std::cout << "The results for question set ID: " << _setID << " are: " << std::endl;
    std::cout << "Name:\tScore" << std::endl;
    std::map<std::string, int>::iterator it;

    for ( it = _results.begin(); it != _results.end(); it++ )
    {
        std::cout << it->first  // string (key)
                  << ":\t"
                  << it->second   // string's value 
                  << std::endl ;
    }
}

/**
 * gets the results, used for testing
 * @return the hashtable of results
 */
std::map<std::string, int> QuestionSet::getResults() {
    return _results;
}

/**
 * gets the questions in this set
 * @return list of questions from this set
 */
std::vector<Question*> QuestionSet::getQuestionList() {
    return _questionList;
}

/**
 * gets the question sets unique ID
 * @return set ID
 */
int QuestionSet::getId() {
    return _setID;
}

/**
 * gets the number of questions in this set, used for testing
 * @return number of questions
 */
int QuestionSet::getNumberOfQuestions(){
    return _questionList.size();
}

/**
 * gets the number of students that have attempted this set
 * @return number of results
 */
int QuestionSet::getNumberOfResults(){
    return _results.size();
}

/**
 * Adds the result to the set after a student has attempted this set
 * @param name students name
 * @param score students score
 */
void QuestionSet::AddResult(std::string name, int score) {
    _results.insert(std::pair<std::string, int>(name, score));
}


