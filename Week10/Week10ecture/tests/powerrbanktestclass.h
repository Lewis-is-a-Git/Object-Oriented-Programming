/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/*
 * File:   powerrbanktestclass.h
 * Author: lewis
 *
 * Created on 12/11/2019, 9:19:25 AM
 */

#ifndef POWERRBANKTESTCLASS_H
#define POWERRBANKTESTCLASS_H

#include <cppunit/extensions/HelperMacros.h>

class powerrbanktestclass : public CPPUNIT_NS::TestFixture {
    CPPUNIT_TEST_SUITE(powerrbanktestclass);

    CPPUNIT_TEST(testCharge);

    CPPUNIT_TEST_SUITE_END();

public:
    powerrbanktestclass();
    virtual ~powerrbanktestclass();
    void setUp();
    void tearDown();

private:
    void testCharge();
};

#endif /* POWERRBANKTESTCLASS_H */

