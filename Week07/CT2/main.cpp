/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/* 
 * File:   main.cpp
 * Author: lewis
 *
 * Created on 6 November 2019, 2:39 PM
 */

#include <cstdlib>
#include <iostream>
#include "Teacher.h"
#include "Student.h"

using namespace std;

/*
 * Main entry point, demonstrates features
 */
int main(int argc, char** argv) {
    // Create new teacher and student
    Teacher *teacher = new Teacher("Wendy");
    Student *s1 = new Student("Lewis");
    
    // Demonstrate UI for creating a question during runtime
    teacher->CreateQuestion();
    
    // Demonstrate a teacher can delete a question
    cout << "Enter question ID to delete: ";
    int deleteID = 0;
    (cin >> deleteID).get();
    teacher->DeleteQuestion(deleteID);
    
    // Create some dummy questions and put them in a question set
    vector<string> answerChoices = {"Jupiter", "Mars", "Venus", "Mercury"};
    int q1ID = 101, q2ID = 102, q3ID = 103;
    Question *q1 = new Question(q1ID, "What is the closest planet to the sun?",
            answerChoices, 3);
    Question *q2 = new Question(q2ID, "What is the closest planet to earth?", 
            answerChoices, 2);
    Question *q3 = new Question(q3ID, "What is the biggest planet?", 
            answerChoices, 0);
    
    teacher->AddQuestion(q1);
    teacher->AddQuestion(q2);
    teacher->AddQuestion(q3);
    
    vector<int> qIds = {q1ID, q2ID, q3ID};
    int setId = 100;
    teacher->CreateQuestionSet(qIds, setId); // Add the set to the teacher
    
    // Get a question set for the student to attempt
    QuestionSet *qSet = teacher->getQuestionSet(setId);
    // The student attempts the set and puts their results into the set
    // After a student attempts the set their score is displayed
    qSet = s1->AttemptSet(qSet);
    // The updated set is passed back to the teacher
    teacher->AddResult(qSet);
    
    // To display set results a vector of set IDs need to be passed.
    vector<int> setIDS = {setId};
    teacher->DisplaySetResults(setIDS);
    
    // Release pointers
    delete teacher, s1, q1, q2, q3;
    return 0;
}

