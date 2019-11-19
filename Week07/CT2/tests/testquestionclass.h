/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/*
 * File:   testquestionclass.h
 * Author: lewis
 *
 * Created on 07/11/2019, 6:02:48 PM
 */

#ifndef TESTQUESTIONCLASS_H
#define TESTQUESTIONCLASS_H

#include <cppunit/extensions/HelperMacros.h>

class testquestionclass : public CPPUNIT_NS::TestFixture {
    CPPUNIT_TEST_SUITE(testquestionclass);

    CPPUNIT_TEST(testCreateChoice);
    CPPUNIT_TEST(testEditChoice);
    CPPUNIT_TEST(testDeleteChoice);
    CPPUNIT_TEST(testSetAnswer);
    CPPUNIT_TEST(testGetAnswer);
    CPPUNIT_TEST(testGetId);

    CPPUNIT_TEST_SUITE_END();

public:
    testquestionclass();
    virtual ~testquestionclass();
    void setUp();
    void tearDown();

private:
    void testCreateChoice();
    void testEditChoice();
    void testDeleteChoice();
    void testSetAnswer();
    void testGetAnswer();
    void testGetId();
};

#endif /* TESTQUESTIONCLASS_H */

