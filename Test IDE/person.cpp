#include "person.h"
using namespace std;
class person
{
private:
    string name;
    int id;

public:
    void getDetails(){
        cout << name << " " << id;
    }
};
