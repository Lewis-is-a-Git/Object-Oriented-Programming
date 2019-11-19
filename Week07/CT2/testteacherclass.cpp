/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/* 
 * File:   testteacherclass.cpp
 * Author: lewis
 * 
 * Created on 7 November 2019, 6:04 PM
 */

#include "testteacherclass.h"
#include "./Teacher.h"
#include <iostream>

CPPUNIT_TEST_SUITE_REGISTRATION(testteacherclass);

testteacherclass::testteacherclass() {
}

testteacherclass::testteacherclass(const testteacherclass& orig) {
}

testteacherclass::~testteacherclass() {
}

void testteacherclass::setUp() {
}

void testteacherclass::tearDown() {
}

/**
 * Test Deleting a question from the teachers question pool
 */
void testteacherclass::testDeleteQuestion() {
    // Create a question
    int qId = 101;
    std::string question = "What?";
    std::vector<std::string> choices = {"correct", "incorrect"};
    int answer = 0;
    Question *q1 = new Question(qId, question, choices, answer);
    // Create another question
    int qId2 = 102;
    Question *q2 = new Question(qId2, question, choices, answer);
    
    // Create a teacher and add the questions to the pool
    Teacher *t = new Teacher("Lewis");
    t->AddQuestion(q1);
    t->AddQuestion(q2);
    CPPUNIT_ASSERT(t->getQuestionPoolSize() == 2);
    
    // Delete a question and check again
    t->DeleteQuestion(qId);
    CPPUNIT_ASSERT(t->getQuestionPoolSize() == 1);
    delete q1, q2, t;
}

/**
 * Test creating a new question set
 */
void testteacherclass::testCreateQuestionSet() {
    // Create the questions
    int qId = 101, qId2 = 102, setID = 100;
    std::string question = "What?";
    std::vector<std::string> choices = {"correct", "incorrect"};
    int answer = 0;
    Question *q1 = new Question(qId, question, choices, answer);
    Question *q2 = new Question(qId2, question, choices, answer);
    
    // Create the teacher and add the questions
    Teacher *t = new Teacher("Lewis");
    t->AddQuestion(q1);
    t->AddQuestion(q2);
    std::vector<int> qIDs = {qId, qId2};
    
    // Create the question set and check if it has been correctly added
    t->CreateQuestionSet(qIDs, setID);
    CPPUNIT_ASSERT(t->getNumberOfSets() == 1);
    CPPUNIT_ASSERT(t->getQuestionSet(setID)->getId() == setID);
    delete q1, q2, t;
}

/**
 * Test deleting a question set
 */
void testteacherclass::testDeleteQuestionSet() {
    // Create some questions
    int qId = 101, qId2 = 102, setID = 100;
    std::string question = "What?";
    std::vector<std::string> choices = {"correct", "incorrect"};
    int answer = 0;
    Question *q1 = new Question(qId, question, choices, answer);
    Question *q2 = new Question(qId2, question, choices, answer);
    
    // Create a teacher and add the questions
    Teacher *t = new Teacher("Lewis");
    t->AddQuestion(q1);
    t->AddQuestion(q2);
    std::vector<int> qIDs = {qId, qId2};

    t->CreateQuestionSet(qIDs, setID);
    
    CPPUNIT_ASSERT(t->getNumberOfSets() == 1);
    CPPUNIT_ASSERT(t->getQuestionSet(setID)->getId() == setID);
    
    // Delete a set and test again
    t->DeleteQuestionSet(setID);
    
    CPPUNIT_ASSERT(t->getNumberOfSets() == 0);
    delete q1, q2, t;
}

/**
 * Test adding a question to the teachers pool
 */
void testteacherclass::testAddQuestion() {
    int qId = 1, qId2 = 2;
    std::string question = "What?";
    std::vector<std::string> choices = {"correct", "incorrect"};
    int answer = 0;
    Question *q1 = new Question(qId, question, choices, answer);
    Question *q2 = new Question(qId2, question, choices, answer);
    Teacher *t = new Teacher("Lewis");
    t->AddQuestion(q1);
    CPPUNIT_ASSERT(t->getQuestionPoolSize() == 1);
    t->AddQuestion(q1);
    CPPUNIT_ASSERT(t->getQuestionPoolSize() == 2);
    delete q1, t;
}

/**
 * Test getting a question set
 */
void testteacherclass::testGetQuestionSet() {
    // Create some questions
    int qId = 101, qId2 = 102, setID = 100;
    std::string question = "What?";
    std::vector<std::string> choices = {"correct", "incorrect"};
    int answer = 0;
    Question *q1 = new Question(qId, question, choices, answer);
    Question *q2 = new Question(qId2, question, choices, answer);
    
    // Create a teacher and add the questions
    Teacher *t = new Teacher("Lewis");
    t->AddQuestion(q1);
    t->AddQuestion(q2);
    std::vector<int> qIDs = {qId, qId2};

    // Create a question set
    t->CreateQuestionSet(qIDs, setID);
    
    CPPUNIT_ASSERT(t->getQuestionSet(setID)->getNumberOfQuestions() == 2);
    delete q1, q2, t;
}

/**
 * Test adding results to a question set
 */
void testteacherclass::testAddResult() {
    // Create some questions
    int qId = 101, qId2 = 102, setID = 100, setID2 = 200;
    std::string question = "What?";
    std::vector<std::string> choices = {"correct", "incorrect"};
    int answer = 0;
    Question *q1 = new Question(qId, question, choices, answer);
    Question *q2 = new Question(qId2, question, choices, answer);
    
    // Create a teacher and add the questions
    Teacher *t = new Teacher("Lewis");
    t->AddQuestion(q1);
    t->AddQuestion(q2);
    std::vector<int> qIDs = {qId, qId2};

    // Create a question set
    t->CreateQuestionSet(qIDs, setID);
    
    CPPUNIT_ASSERT(t->getQuestionSet(setID)->getNumberOfResults() == 0);
    
    // Update the question set with a result
    QuestionSet *qUpdated = t->getQuestionSet(setID);
    qUpdated->AddResult("Lewis", 1);
    t->AddResult(qUpdated);
    CPPUNIT_ASSERT(t->getQuestionSet(setID)->getNumberOfResults() == 1);

    delete q1, q2, t, qUpdated;
}
