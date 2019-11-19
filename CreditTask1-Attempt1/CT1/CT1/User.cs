// FileName: User.cs
// Author: Lewis Brockman-Horsley
// Email: 101533222@students.swinburne.edu.au
// Date: 24/10/2019
using System;
namespace CT1
{
    public class User
    {
        private string _name;

        public User(String name)
        {
            _name = name;
        }

        public string Name { get => _name; set => _name = value; }
    }
}
