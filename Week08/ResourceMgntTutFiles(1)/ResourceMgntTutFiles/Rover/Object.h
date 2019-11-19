/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/* 
 * File:   Object.h
 * Author: lewis
 *
 * Created on 30 October 2019, 2:52 PM
 */

#ifndef OBJECT_H
#define OBJECT_H

class Object {
public:
    Object();    
    Object(const Object&);    
    virtual ~Object();  
    // return the count of current object instances    
    static int getCount ();
private:    
    // count of all object instances in existence    
    static int _count;

};

#endif /* OBJECT_H */

