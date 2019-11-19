/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/* 
 * File:   Question.cpp
 * Author: lewis
 * 
 * Created on 6 November 2019, 2:41 PM
 */


#include "Question.h"
#include <iostream>

/**
 * Constructor
 * @param id unique int for question ID
 * @param question string of the actual question
 * @param choices possible answers for the multiple choices
 * @param answer int index of the answer from choices
 */
Question::Question(int id, std::string question, std::vector<std::string> choices, int answer) {
    _questionID = id;
    _question = question;
    _choices = choices;
    _answer = answer;
}

Question::Question(const Question& orig) {
}

Question::~Question() {
}

/**
 * Create a new choice for this question
 * @param choice
 */
void Question::CreateChoice(std::string choice){
    _choices.push_back(choice);
}

/**
 * Replaces the choice at a given index with the new string
 * @param i
 * @param choice
 */
void Question::EditChoice(int i, std::string choice){
    _choices[i] = choice;
}

/**
 * Deletes a choice given an index
 * @param i index of choice to delete
 */
void Question::DeleteChoice(int i){
    _choices.erase(_choices.begin() + i);
}

/**
 * Updates the answer index
 * @param a index of new answer
 */
void Question::setAnswer(int a){
    _answer = a;
}

/**
 * gets the answer index
 * @return int of answer index
 */
int Question::getAnswer() {
    return _answer;
}

/**
 * get the question ID
 * @return question ID
 */
int Question::getId() {
    return _questionID;
}

/**
 * get the list of choices, used for testing
 * @return the list of choices
 */
std::vector<std::string> Question::getChoices() {
    return _choices;
}

/**
 * gets the number of choices of this question, used for testing
 * @return number of choices
 */
int Question::getNumberOfChoices() {
    return _choices.size();
}

/**
 * Displays the Question on the console
 */
void Question::Display(){
    std::cout << _question << std::endl;
    for (int i = 0; i < _choices.size(); i++){
        std::cout << i << ": " << _choices[i] << std::endl;
    }
    std::cout << "Enter Answer(number): " << std::endl;
}