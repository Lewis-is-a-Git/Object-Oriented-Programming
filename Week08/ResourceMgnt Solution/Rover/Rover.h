/* 
 * File:   Rover.h
 * Author: sfu
 *
 * Created on February 1, 2016, 3:36 PM
 */

#ifndef ROVER_H
#define	ROVER_H
#include "Device.h"
#include "Battery.h"
#include "Object.h"
#include <vector>
using namespace std;

class Rover:public Object {
public:
    Rover();
    Rover(const Rover& orig);
    virtual ~Rover();
    int deviceCount() const;
    int batteryCount() const;
    void attachDevice(Device *dev);
    void attachBattery(Battery *b);
       
private:
    vector<Device*> _devices;
    vector<Battery*> _batteries;

};

#endif	/* ROVER_H */

