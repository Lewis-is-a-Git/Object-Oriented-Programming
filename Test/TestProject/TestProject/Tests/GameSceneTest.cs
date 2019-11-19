// FileName: GameSceneTest.cs
// Author: Lewis Brockman-Horsley
// Email: 101533222@students.swinburne.edu.au
// Date: 5/11/2019
using System;
using NUnit.Framework;
namespace TestProject.Tests
{
    [TestFixture]
    public class GameSceneTest
    {
        [Test]
        public void TesPlayerAttack()
        {
            Weapon weapon = new Weapon(WeaponType.Sword);
            Player player = new Player("Lewis", 10);
            player.Load(weapon);

            Assert.AreEqual("Swords Drawn", player.Attack(),
                "Player has correct attack");
        }

        [Test]
        public void TestDungeonName()
        {
            Dungeon dungeon = new Dungeon("Room", 5);
            Assert.AreEqual("Room", dungeon.Name,
            "Dungeon name is correct");
        }
    }
}
