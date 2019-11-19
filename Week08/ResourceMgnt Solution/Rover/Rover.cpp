/* 
 * File:   Rover.cpp
 * Author: sfu
 * 
 * Created on February 1, 2016, 3:36 PM
 */

#include "Rover.h"

Rover::Rover() {
}

Rover::Rover(const Rover& orig) {
    _devices = vector<Device*>(orig._devices.size());
    for(int i=0;i<orig._devices.size();i++){
        _devices[i] = orig._devices[i]->clone();
    }
}

int Rover ::deviceCount() const{
    return _devices.size();
}

int Rover::batteryCount() const{
    return _batteries.size();
}

void Rover::attachDevice(Device* dev){
    _devices.push_back(dev);
}

void Rover::attachBattery(Battery *b){
    _batteries.push_back(b);
}

Rover::~Rover() {
    for(int i=0; i<_devices.size();i++){
        delete _devices[i];
    }
}

