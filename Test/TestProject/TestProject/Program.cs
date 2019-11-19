// FileName: Program.cs
// Author: Lewis Brockman-Horsley
// Email: 101533222@students.swinburne.edu.au
// Date: 5/11/2019
using System;

namespace TestProject
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // Instantiate a Weapon object of type Bow and Dungeon object
            Weapon weapon = new Weapon(WeaponType.Bow);
            Dungeon dungeon = new Dungeon("Room", 5);

            // Instantiate a Player object and load the weapon
            Player player = new Player("Lewis", 10);
            player.Load(weapon);

            // Instantiate a Scene object and add player and dungeon
            Scene scene = new Scene();
            scene.AddObject(player);
            scene.AddObject(dungeon);

            // Locate the Dungeon object through the scene object
            // and assign it to an animated object
            AnimatedObject obj = scene.Locate("Room");

            // Execute the scene object created
            scene.Execute();
        }
    }
}
