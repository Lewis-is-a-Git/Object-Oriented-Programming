/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/* 
 * File:   Object.h
 * Author: sfu
 *
 * Created on April 11, 2018, 9:38 AM
 */

#ifndef OBJECT_H
#define OBJECT_H

class Object {
public:
    Object();
    Object(const Object& orig);
    virtual ~Object();
    static int getCount();
private:
    static int _count;
};

#endif /* OBJECT_H */

