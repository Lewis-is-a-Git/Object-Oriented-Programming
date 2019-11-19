/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/*
 * File:   testroverclass.cpp
 * Author: sfu
 *
 * Created on Apr 11, 2018, 9:37:29 AM
 */

#include "testroverclass.h"
#include "Rover.h"
#include "Radar.h"


CPPUNIT_TEST_SUITE_REGISTRATION(testroverclass);

testroverclass::testroverclass() {
}

testroverclass::~testroverclass() {
}

void testroverclass::setUp() {
}

void testroverclass::tearDown() {
}

void testroverclass::testMemoryLeaks() {
    Rover *rover  = new Rover();
    rover->attachDevice(new Radar());
    delete rover;
    
    CPPUNIT_ASSERT(Object::getCount()==0);
}

void testroverclass::testCopyConstructor(){
    Rover *rover = new Rover();
    rover->attachDevice(new Radar());
    Rover *copy = new Rover(*rover);
    
    CPPUNIT_ASSERT(rover->deviceCount()==copy->deviceCount());
}

void testroverclass::testObjectAliasing(){
    Rover *rover = new Rover();
    rover->attachDevice(new Radar());
    Rover *copy = new Rover(*rover);
    
    delete rover;
    
    delete copy;
    
    CPPUNIT_ASSERT(true);
}

