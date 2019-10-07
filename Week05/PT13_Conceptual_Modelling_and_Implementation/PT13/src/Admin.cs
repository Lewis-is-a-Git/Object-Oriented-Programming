// FileName: Admin.cs
// Author: Lewis Brockman-Horsley
// Email: 101533222@students.swinburne.edu.au
// Date: 5/10/2019
using System.Collections.Generic;
namespace PT13.src
{
    public class Admin : User
    {
        public Admin() { }
        public Admin(string user, string pass) : base(user, pass) { }

        public Admin CreateAdmin()
        {
            Admin newUser;
            newUser = new Admin();
            return newUser;
        }

        public Sales CreateSales()
        {
            Sales newUser;

            newUser = new Sales();
            return newUser;
        }
    }
}
