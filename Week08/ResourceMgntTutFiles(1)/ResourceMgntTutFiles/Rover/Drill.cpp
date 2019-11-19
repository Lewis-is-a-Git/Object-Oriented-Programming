/* 
 * File:   Drill.cpp
 * Author: sfu
 * 
 * Created on February 2, 2016, 10:21 AM
 */

#include "Drill.h"

Drill::Drill() {
    _safetyEnabled = false;
}

Drill::Drill(const Drill& orig) {
}

Drill::~Drill() {
}

string Drill::operate(){
    return "Operating Drill";
}
Drill* Drill::clone(){
    return new Drill(*this);
}
