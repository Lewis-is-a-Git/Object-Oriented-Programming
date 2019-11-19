/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/* 
 * File:   testteacherclass.h
 * Author: lewis
 *
 * Created on 7 November 2019, 6:04 PM
 */

#ifndef TESTTEACHERCLASS_H
#define TESTTEACHERCLASS_H

#include <cppunit/extensions/HelperMacros.h>

class testteacherclass : public CPPUNIT_NS::TestFixture {
    CPPUNIT_TEST_SUITE(testteacherclass);

    CPPUNIT_TEST(testDeleteQuestion);
    CPPUNIT_TEST(testCreateQuestionSet);
    CPPUNIT_TEST(testDeleteQuestionSet);
    CPPUNIT_TEST(testAddQuestion);
    CPPUNIT_TEST(testGetQuestionSet);
    CPPUNIT_TEST(testAddResult);
    CPPUNIT_TEST_SUITE_END();
public:
    testteacherclass();
    testteacherclass(const testteacherclass& orig);
    virtual ~testteacherclass();
    void setUp();
    void tearDown();
    
private:
    void testDeleteQuestion();
    void testCreateQuestionSet();
    void testDeleteQuestionSet();
    void testAddQuestion();
    void testGetQuestionSet();
    void testAddResult();
};

#endif /* TESTTEACHERCLASS_H */

