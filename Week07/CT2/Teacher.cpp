/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/* 
 * File:   Teacher.cpp
 * Author: lewis
 * 
 * Created on 6 November 2019, 2:40 PM
 */

#include"QuestionSet.h"
#include "Teacher.h"

#include <iostream>
#include <unordered_set>

using namespace std;

Teacher::Teacher(std::string name) : User(name){
}

Teacher::~Teacher() {
}

/**
 * Create a question during run time using this UI
 */
void Teacher::CreateQuestion() {
    // Enter unique question ID
    cout << "Enter question ID (integer): " << endl;
    int questionId = 0;
    (cin >> questionId).get();
    
    // Enter Question
    cout << "Enter Question: " << endl;
    string questionSentence;
    std::getline(std::cin, questionSentence);
    
    //  Enter number of choices
    cout << "How many choices would you like to create (integer)(min=2): " << endl;
    int choices = 0;
    (cin >> choices).get();
    if (choices < 2){
        choices = 2;
    }
    // Enter possible answers
    vector<string> possibleAnswers;
    for (int i = 0; i < choices; i++){
        cout << "Enter answer choice (" << i << "): " << endl;
        string possibleAnswer;
        std::getline(std::cin, possibleAnswer);
        possibleAnswers.push_back(possibleAnswer);
    }
    
    // Set the correct choice
    cout << "Set the correct choice (number): " << endl;
    for (int i = 0; i < choices; i++){
        cout << "\tChoice: (" << i << ") -> " << possibleAnswers[i] << endl;
    }
    cout << "Set answer: ";
    int answer = 0;
    (cin >> choices).get();
    // Create question and add it to the pool
    Question *question = new Question(questionId, questionSentence,
            possibleAnswers, answer);
    _questionPool.push_back(question);
}

/**
 * Delete a question from the pool
 * @param questionId delete question given an ID
 */
void Teacher::DeleteQuestion(int questionId) {
    bool deleted = false;
    for (int i = 0; i < _questionPool.size(); i++){
        if (questionId == _questionPool[i]->getId()){
            _questionPool.erase(_questionPool.begin() + i);
            deleted = true;
            cout << "Question Deleted" << endl;
        }
    }
    if (!deleted){
        cout << "Question not found" << endl;
    }
}

/**
 * Delete an entire question set
 * @param setId ID of set to be deleted
 */
void Teacher::DeleteQuestionSet(int setId) {
    for (int i = 0; i < _questionSets.size(); i++){
        if (setId == _questionSets[i]->getId()){
            _questionSets.erase(_questionSets.begin() + i);
        }
    }
}

/**
 * Creates a new question set
 * @param ids IDs of questions to add to set
 * @param setId unique set ID
 */
void Teacher::CreateQuestionSet(std::vector<int> ids, int setId) {
    vector<Question*> set;
    
    for (int i = 0; i < ids.size(); i++){
        for (int j = 0; j < _questionPool.size(); j++){
            if (ids[i] == _questionPool[j]->getId()){
                set.push_back(_questionPool[j]);
            }
        }
    }

    QuestionSet *qSet = new QuestionSet(setId, set);
    _questionSets.push_back(qSet);
}

/**
 * Add question to pool
 * @param q question to add to pool
 */
void Teacher::AddQuestion(Question* q) {
    _questionPool.push_back(q);
}

/**
 * gets a question set given an ID
 * @param setId ID of set to get
 * @return found set, or null if not found
 */
QuestionSet* Teacher::getQuestionSet(int setId) {
    for(int i = 0; i < _questionSets.size(); i++){
        if (setId == _questionSets[i]->getId()){
            return _questionSets[i];
        }
    }
    cout << "Question set not found" << endl;
    return NULL;
}

/**
 * Update a question set after a student has attempted it
 * @param qSet replace a set with its own ID
 */
void Teacher::AddResult(QuestionSet* qSet) {
    for (int i = 0; i < _questionSets.size(); i++){
        if (_questionSets[i]->getId() == qSet->getId()){
            _questionSets[i] = qSet;
        }
    }
}

/**
 * Display the results of all the given set IDs
 * @param setIds to display
 */
void Teacher::DisplaySetResults(vector<int> setIds) {
    for (int i = 0; i < setIds.size(); i++){
        for (int j = 0; j < _questionSets.size(); j++){
            if (setIds[i] == _questionSets[j]->getId()){
                _questionSets[j]->DisplayResults();
            }
        }
    }
}

/**
 * get number of question sets
 * @return number of question sets
 */
int Teacher::getNumberOfSets() {
    return _questionSets.size();
}

/**
 * get size of question pool
 * @return size of question pool
 */
int Teacher::getQuestionPoolSize() {
    return _questionPool.size();
}



