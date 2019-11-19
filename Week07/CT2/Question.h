/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/* 
 * File:   Question.h
 * Author: lewis
 *
 * Created on 6 November 2019, 2:41 PM
 */

#ifndef QUESTION_H
#define QUESTION_H
#include <vector>
#include <string>

class Question {
public:
    Question(int id, std::string question, std::vector<std::string> choices, int answer);
    Question(const Question& orig);
    virtual ~Question();
    void CreateChoice(std::string choice);
    void EditChoice(int i, std::string choice);
    void DeleteChoice(int i);
    void setAnswer(int a);
    int getAnswer();
    int getId();
    std::vector<std::string> getChoices();
    int getNumberOfChoices();
    void Display();
private:
    int _questionID;
    std::string _question;
    std::vector<std::string> _choices;
    int _answer;

};

#endif /* QUESTION_H */

