/* 
 * File:   Radar.cpp
 * Author: sfu
 * 
 * Created on February 1, 2016, 3:37 PM
 */

#include "Radar.h"

Radar::Radar() {
}

Radar::Radar(const Radar& orig) {
}

Radar::~Radar() {
}

string Radar::operate(){
    return "Operating Radar";  
}

Radar* Radar::clone(){
    return new Radar(*this);
}