/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/* 
 * File:   User.h
 * Author: lewis
 *
 * Created on 6 November 2019, 2:40 PM
 */

#ifndef USER_H
#define USER_H
#include <string>

class User {
public:
    User(std::string name);
    User(const User& orig);
    virtual ~User();
protected:
    std::string _name;
};

#endif /* USER_H */

