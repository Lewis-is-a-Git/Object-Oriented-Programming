/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/* 
 * File:   PowerBank.cpp
 * Author: lewis
 * 
 * Created on 12 November 2019, 9:16 AM
 */

#include "PowerBank.h"

#include <exception>

PowerBank::PowerBank() {
    _charge = 10;
}

PowerBank::PowerBank(const PowerBank& orig) {
}

PowerBank::~PowerBank() {
}

int PowerBank::getCharge() {
    return _charge;
}

void PowerBank::useCharge(int power){
    if ((_charge - power) <= 0){
        throw std::exception();
    } else {
        _charge -= power;
    }
}

