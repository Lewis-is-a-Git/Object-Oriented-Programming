/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/* 
 * File:   Object.cpp
 * Author: sfu
 * 
 * Created on April 11, 2018, 9:38 AM
 */

#include "Object.h"
int Object::_count=0;

Object::Object() {
    _count++;
}

Object::Object(const Object& orig) {
    _count++;
}

Object::~Object() {
    _count--;
}

int Object::getCount(){
    return _count;
}

