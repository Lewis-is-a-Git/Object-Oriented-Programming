/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/* 
 * File:   Object.cpp
 * Author: lewis
 * 
 * Created on 30 October 2019, 2:52 PM
 */

#include "Object.h"

/* * static (class-wide) members are effectively global variables 
 * and are initialised accordingly 
 */
int Object::_count = 0;

// provides read-only access to the instance count
int Object::getCount (){
    return _count;
}
Object::Object() {   
    _count ++;
}
Object::Object(const Object&){
    _count ++;
}
Object::~Object(){
    _count --;
}

