/* 
 * File:   Device.cpp
 * Author: sfu
 * 
 * Created on February 1, 2016, 4:18 PM
 */

#include "Device.h"
#include "Object.h"

Device::Device() {
    _battery = NULL;
}

Device::Device(const Device& orig) {
}

Device::~Device() {
}

bool Device::hasBattery(){
    if(_battery!= NULL){
        return true;        
    }else{
        return false;
    }
}




