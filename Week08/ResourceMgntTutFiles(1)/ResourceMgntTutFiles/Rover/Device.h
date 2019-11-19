/* 
 * File:   Device.h
 * Author: sfu
 *
 * Created on February 1, 2016, 4:18 PM
 */

#ifndef DEVICE_H
#define	DEVICE_H
#include "Battery.h"
#include "Object.h"
#include <string>
using namespace std;

class Device : public Object {
public:
    Device();
    Device(const Device& orig);
    virtual ~Device();
    bool hasBattery();
    virtual string operate()=0;
    virtual Device* clone() =0;
    
private:
    
protected:
    Battery* _battery;

};

#endif	/* DEVICE_H */

