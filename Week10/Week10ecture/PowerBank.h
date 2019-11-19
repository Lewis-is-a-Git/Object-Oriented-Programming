/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/* 
 * File:   PowerBank.h
 * Author: lewis
 *
 * Created on 12 November 2019, 9:16 AM
 */

#ifndef POWERBANK_H
#define POWERBANK_H

class PowerBank {
public:
    PowerBank();
    PowerBank(const PowerBank& orig);
    virtual ~PowerBank();
    
    int getCharge();
    void useCharge(int power);
private:
    int _charge;
};

#endif /* POWERBANK_H */

