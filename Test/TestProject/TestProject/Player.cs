// FileName: Player.cs
// Author: Lewis Brockman-Horsley
// Email: 101533222@students.swinburne.edu.au
// Date: 5/11/2019
using System;
namespace TestProject
{
    public class Player : AnimatedObject
    {
        private Weapon _weapon;

        public Player(string name, int strength) : base(name, strength)
        {
            _weapon = null;
        }

        public void Load(Weapon weapon)
        {
            _weapon = weapon;
        }

        public override string Attack()
        {
            return _weapon.Trigger();
        }
    }
}
