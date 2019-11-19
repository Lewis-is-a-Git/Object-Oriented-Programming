/* 
 * File:   Battery.cpp
 * Author: sfu
 * 
 * Created on February 2, 2016, 9:11 AM
 */
#include "Battery.h"

Battery::Battery() {
    _power = 100;
    _connected = false;
}

Battery::Battery(const Battery& orig) {
}

Battery::~Battery() {
}

int Battery::getPower(){
    return _power;
}

bool Battery::getConnectionStatus(){
    return _connected;
}

