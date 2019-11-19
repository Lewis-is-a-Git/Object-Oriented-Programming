/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/* 
 * File:   main.cpp
 * Author: lewis
 *
 * Created on 12 November 2019, 9:15 AM
 */

#include <cstdlib>
#include <iostream>

#include "PowerBank.h"

using namespace std;

/*
 * 
 */
int main(int argc, char** argv) {
    PowerBank *p = new PowerBank();
    int power;
    cout << "Enter the power you want: ";
    cin >> power;
    
    try {
        p->useCharge(power);
        cout << "The amount of charge remaining: " << p->getCharge() << endl;;
    } catch (exception e){
        cout << "Insufficient power to supply" << endl;
    }
    
    return 0;
}

