/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/*
 * File:   powerrbanktestclass.cpp
 * Author: lewis
 *
 * Created on 12/11/2019, 9:19:25 AM
 */

#include "powerrbanktestclass.h"
#include "../PowerBank.h"


CPPUNIT_TEST_SUITE_REGISTRATION(powerrbanktestclass);

powerrbanktestclass::powerrbanktestclass() {
}

powerrbanktestclass::~powerrbanktestclass() {
}

void powerrbanktestclass::setUp() {
}

void powerrbanktestclass::tearDown() {
}

void powerrbanktestclass::testCharge() {
    PowerBank *p = new PowerBank();
    CPPUNIT_ASSERT(p->getCharge() == 10);
    CPPUNIT_ASSERT_NO_THROW(p->useCharge(2));
    CPPUNIT_ASSERT(p->getCharge() == 8);
    
    CPPUNIT_ASSERT_THROW(p->useCharge(20), std::exception);
    CPPUNIT_ASSERT(p->getCharge() == 8);
}


