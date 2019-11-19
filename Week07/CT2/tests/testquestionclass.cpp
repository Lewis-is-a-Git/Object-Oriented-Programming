/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/*
 * File:   testquestionclass.cpp
 * Author: lewis
 *
 * Created on 07/11/2019, 6:02:48 PM
 */

#include "testquestionclass.h"
#include "../Question.h"


CPPUNIT_TEST_SUITE_REGISTRATION(testquestionclass);

testquestionclass::testquestionclass() {
}

testquestionclass::~testquestionclass() {
}

void testquestionclass::setUp() {
}

void testquestionclass::tearDown() {
}

/**
 * Test creating a new choice
 */
void testquestionclass::testCreateChoice() {
    // Create a question
    int qId = 1;
    std::string question = "What?";
    std::vector<std::string> choices = {"correct", "incorrect"};
    int answer = 0;
    Question *q1 = new Question(qId, question, choices, answer);
    
    // Create a new choice
    q1->CreateChoice("Also incorrect");
    
    CPPUNIT_ASSERT(q1->getNumberOfChoices() == 3);
    delete q1;
}

/**
 * Test editing a choice
 */
void testquestionclass::testEditChoice() {
    // Create Question
    int qId = 1;
    std::string question = "What?";
    std::vector<std::string> choices = {"correct", "incorrect"};
    int answer = 0;
    Question *q1 = new Question(qId, question, choices, answer);
    // Edit a choice
    q1->EditChoice(0, "new correct");
    // Check if the choice has been updated
    CPPUNIT_ASSERT(q1->getChoices()[0] != choices[0]);
    delete q1;
}

/**
 * Test deleting a choice
 */
void testquestionclass::testDeleteChoice() {
    // Create a question
    int qId = 1;
    std::string question = "What?";
    std::vector<std::string> choices = {"correct", "incorrect"};
    int answer = 0;
    Question *q1 = new Question(qId, question, choices, answer);
    // Delete the first choice
    q1->DeleteChoice(0);
    // Check if it has been deleted
    CPPUNIT_ASSERT(q1->getChoices()[0] == "incorrect");
    delete q1;
}

/**
 * Test setting the new answer
 */
void testquestionclass::testSetAnswer() {
    // Create a question
    int qId = 1;
    std::string question = "What?";
    std::vector<std::string> choices = {"correct", "incorrect"};
    int answer = 0;
    Question *q1 = new Question(qId, question, choices, answer);
    // Test the answer
    CPPUNIT_ASSERT(q1->getAnswer() == answer);
    
    // Update the answer and check the new answer
    answer = 1;
    q1->setAnswer(1);
    CPPUNIT_ASSERT(q1->getAnswer() == answer);
    delete q1;
}

/**
 * Test the get answer method
 */
void testquestionclass::testGetAnswer() {
    // Create a question
    int qId = 1;
    std::string question = "What?";
    std::vector<std::string> choices = {"correct", "incorrect"};
    int answer = 1;
    Question *q1 = new Question(qId, question, choices, answer);
    
    // Get the answer index
    CPPUNIT_ASSERT(q1->getAnswer() == answer);
    delete q1;
}

/**
 *  Test the getID method
 */
void testquestionclass::testGetId() {
    // Create a question
    int qId = 1;
    std::string question = "What?";
    std::vector<std::string> choices = {"correct", "incorrect"};
    int answer = 0;
    Question *q1 = new Question(qId, question, choices, answer);
    
    // Get the ID of the question to check if it matches
    CPPUNIT_ASSERT(q1->getId() == qId);
    delete q1;
}   
