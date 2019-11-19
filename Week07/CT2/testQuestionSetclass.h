/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/* 
 * File:   testQuestionSet.h
 * Author: lewis
 *
 * Created on 7 November 2019, 7:08 PM
 */

#ifndef TESTQUESTIONSETCLASS_H
#define TESTQUESTIONSETCLASS_H

#include <cppunit/extensions/HelperMacros.h>

class testQuestionSetclass : public CPPUNIT_NS::TestFixture {
    CPPUNIT_TEST_SUITE(testQuestionSetclass);

    CPPUNIT_TEST(testGetQuestionList);
    CPPUNIT_TEST(testGetId);
    CPPUNIT_TEST(testAddResult);
    CPPUNIT_TEST(testGetNumberOfQuestions);
    CPPUNIT_TEST(testGetNumberOfResults);
  
    CPPUNIT_TEST_SUITE_END();
public:
    testQuestionSetclass();
    testQuestionSetclass(const testQuestionSetclass& orig);
    virtual ~testQuestionSetclass();
    
private:
    void testGetQuestionList();
    void testGetId();
    void testAddResult();
    void testGetNumberOfQuestions();
    void testGetNumberOfResults();
};

#endif /* TESTQUESTIONSET_H */

