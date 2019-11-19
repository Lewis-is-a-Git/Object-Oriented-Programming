// FileName: Dungeon.cs
// Author: Lewis Brockman-Horsley
// Email: 101533222@students.swinburne.edu.au
// Date: 5/11/2019
using System;
namespace TestProject
{
    public class Dungeon : AnimatedObject
    {
        private int _speed;

        public Dungeon(string name, int strength) : base(name, strength)
        {
            _speed = 10;
        }

        public override string Attack()
        {
            _speed--;
            return "Attrack with speed level: " + _speed;
        }
    }
}
