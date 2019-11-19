/* 
 * File:   SolarPanel.cpp
 * Author: sfu
 * 
 * Created on February 2, 2016, 10:15 AM
 */

#include "SolarPanel.h"


SolarPanel::SolarPanel() {
}

SolarPanel::SolarPanel(const SolarPanel& orig) {
}

SolarPanel::~SolarPanel() {
}

string SolarPanel::operate(){
    return "Operating Solar Panel";
}

SolarPanel * SolarPanel::clone(){
    return new SolarPanel(*this);
}

