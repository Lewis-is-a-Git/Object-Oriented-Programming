/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/*
 * File:   testroverclass.h
 * Author: sfu
 *
 * Created on Apr 11, 2018, 9:37:29 AM
 */

#ifndef TESTROVERCLASS_H
#define TESTROVERCLASS_H

#include <cppunit/extensions/HelperMacros.h>

class testroverclass : public CPPUNIT_NS::TestFixture {
    CPPUNIT_TEST_SUITE(testroverclass);

    CPPUNIT_TEST(testMemoryLeaks);
    CPPUNIT_TEST(testCopyConstructor);
    CPPUNIT_TEST(testObjectAliasing);

    CPPUNIT_TEST_SUITE_END();

public:
    testroverclass();
    virtual ~testroverclass();
    void setUp();
    void tearDown();

private:
    void testMemoryLeaks();
    void testCopyConstructor();
    void testObjectAliasing();
};

#endif /* TESTROVERCLASS_H */

