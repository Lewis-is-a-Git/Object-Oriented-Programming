/* 
 * File:   Drill.h
 * Author: sfu
 *
 * Created on February 2, 2016, 10:21 AM
 */

#ifndef DRILL_H
#define	DRILL_H
#include "Device.h"

using namespace std;

class Drill:public Device {
public:
    Drill();
    Drill(const Drill& orig);
    virtual ~Drill();
    string operate();
    Drill* clone();
private:
    bool _safetyEnabled;
};

#endif	/* DRILL_H */

