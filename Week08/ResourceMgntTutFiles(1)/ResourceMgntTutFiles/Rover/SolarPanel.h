/* 
 * File:   SolarPanel.h
 * Author: sfu
 *
 * Created on February 2, 2016, 10:15 AM
 */

#ifndef SOLARPANEL_H
#define	SOLARPANEL_H
#include "Device.h"

class SolarPanel:public Device {
public:
    SolarPanel();
    SolarPanel(const SolarPanel& orig);
    virtual ~SolarPanel();
    string operate();
    SolarPanel* clone();
private:

};

#endif	/* SOLARPANEL_H */

