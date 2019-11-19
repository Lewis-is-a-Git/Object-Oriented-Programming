/* 
 * File:   Radar.h
 * Author: sfu
 *
 * Created on February 1, 2016, 3:37 PM
 */

#ifndef RADAR_H
#define	RADAR_H
#include "Device.h"

using namespace std;

class Radar:public Device {
public:
    Radar();
    Radar(const Radar& orig);
    virtual ~Radar();
    string operate();
    Radar* clone();
private:

};

#endif	/* RADAR_H */

