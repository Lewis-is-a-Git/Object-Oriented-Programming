// FileName: Weapon.cs
// Author: Lewis Brockman-Horsley
// Email: 101533222@students.swinburne.edu.au
// Date: 5/11/2019
using System;
namespace TestProject
{
    public class Weapon
    {
        private WeaponType _type;

        public Weapon(WeaponType type)
        {
            _type = type;
        }

        public string Trigger()
        {
            switch (_type)
            {
                case (WeaponType.Sword):
                    return "Swords Drawn";
                case (WeaponType.Spear):
                    return "Beware of its sharpness";
                case (WeaponType.Bow):
                    return "Ready to release";
            }
            return "";
        }
    }
}
