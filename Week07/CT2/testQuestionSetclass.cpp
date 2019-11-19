/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/* 
 * File:   testQuestionSet.cpp
 * Author: lewis
 * 
 * Created on 7 November 2019, 7:08 PM
 */

#include "testQuestionSetclass.h"
#include "QuestionSet.h"
#include "Teacher.h"

CPPUNIT_TEST_SUITE_REGISTRATION(testQuestionSetclass);

testQuestionSetclass::testQuestionSetclass() {
}

testQuestionSetclass::testQuestionSetclass(const testQuestionSetclass& orig) {
}

testQuestionSetclass::~testQuestionSetclass() {
}

/**
 * Test getQuestionList()
 */
void testQuestionSetclass::testGetQuestionList() {
    // Create a question
    int qId = 1;
    std::string question = "What?";
    std::vector<std::string> choices = {"correct", "incorrect"};
    int answer = 0;
    Question *q1 = new Question(qId, question, choices, answer);
    
    // Create a question set
    int qSetId = 100;
    std::vector<Question*> questions = {q1};
    QuestionSet *qSet = new QuestionSet(qSetId, questions);
    
    // Get the questionlist from the set
    CPPUNIT_ASSERT(qSet->getQuestionList().size() == 1);
    delete q1, qSet;
}

/**
 * Test the get id method
 */
void testQuestionSetclass::testGetId() {
    // Create question
    int qId = 1;
    std::string question = "What?";
    std::vector<std::string> choices = {"correct", "incorrect"};
    int answer = 0;
    Question *q1 = new Question(qId, question, choices, answer);
    
    // Create question set
    int qSetId = 100;
    std::vector<Question*> questions = {q1};
    QuestionSet *qSet = new QuestionSet(qSetId, questions);
    
    CPPUNIT_ASSERT(qSet->getId() == qSetId);
    delete q1, qSet;
}

/**
 * Test adding a result to a set
 */
void testQuestionSetclass::testAddResult() {
    // Create question
    int qId = 1;
    std::string question = "What?";
    std::vector<std::string> choices = {"correct", "incorrect"};
    int answer = 0;
    Question *q1 = new Question(qId, question, choices, answer);
    
    // Create set
    int qSetId = 100;
    std::vector<Question*> questions = {q1};
    QuestionSet *qSet = new QuestionSet(qSetId, questions);
    
    // Check there is no results to start with
    CPPUNIT_ASSERT(qSet->getResults().size() == 0);
    
    // Add a result an check the results size
    qSet->AddResult("Lewis", 1);
    CPPUNIT_ASSERT(qSet->getResults().size() == 1);
    delete q1, qSet;
}

/**
 * Test adding a question to a set
 * increases the number of question in the set
 */
void testQuestionSetclass::testGetNumberOfQuestions() {
    // Create question
    int qId = 1;
    std::string question = "What?";
    std::vector<std::string> choices = {"correct", "incorrect"};
    int answer = 0;
    Question *q1 = new Question(qId, question, choices, answer);
    
    // Create set
    int qSetId = 100;
    std::vector<Question*> questions = {q1};
    QuestionSet *qSet = new QuestionSet(qSetId, questions);
    
    // Check the number of questions in the set
    CPPUNIT_ASSERT(qSet->getNumberOfQuestions() == 1);
    delete q1, qSet;
}

/**
 * test the get Number of results method
 */
void testQuestionSetclass::testGetNumberOfResults() {
    // Create Question
    int qId = 1;
    std::string question = "What?";
    std::vector<std::string> choices = {"correct", "incorrect"};
    int answer = 0;
    Question *q1 = new Question(qId, question, choices, answer);
    
    // Create set
    int qSetId = 100;
    std::vector<Question*> questions = {q1};
    QuestionSet *qSet = new QuestionSet(qSetId, questions);
    
    // Add result and check the number of results
    qSet->AddResult("Lewis", 1);
    CPPUNIT_ASSERT(qSet->getNumberOfResults() == 1);
    delete q1, qSet;
}
