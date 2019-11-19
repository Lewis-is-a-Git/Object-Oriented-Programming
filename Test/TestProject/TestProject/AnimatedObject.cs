// FileName: Player.cs
// Author: Lewis Brockman-Horsley
// Email: 101533222@students.swinburne.edu.au
// Date: 5/11/2019
namespace TestProject
{
    public abstract class AnimatedObject
    {
        private int _strength;
        private string _name;

        public AnimatedObject(string name, int strength)
        {
            _strength = strength;
            Name = name;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public abstract string Attack();
    }
}