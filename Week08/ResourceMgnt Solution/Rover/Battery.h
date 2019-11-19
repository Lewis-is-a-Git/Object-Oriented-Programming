/* 
 * File:   Battery.h
 * Author: sfu
 *
 * Created on February 2, 2016, 9:11 AM
 */

#ifndef BATTERY_H
#define	BATTERY_H
#include "Object.h"

class Battery:public Object{
public:
    Battery();
    Battery(const Battery& orig);
    virtual ~Battery();
    int getPower();
    bool getConnectionStatus();
    
    
private:
    int _power;
    bool _connected;
 
};

#endif	/* BATTERY_H */

