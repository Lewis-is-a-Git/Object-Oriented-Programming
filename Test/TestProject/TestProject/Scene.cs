// FileName: Scene.cs
// Author: Lewis Brockman-Horsley
// Email: 101533222@students.swinburne.edu.au
// Date: 5/11/2019
using System;
using System.Collections.Generic;

namespace TestProject
{
    public class Scene
    {
        private string _background;
        private List<AnimatedObject> _animatedObjects;

        public Scene()
        {
            _background = "Battlefield";
            _animatedObjects = new List<AnimatedObject>();
        }

        public void AddObject(AnimatedObject obj)
        {
            _animatedObjects.Add(obj);
        }

        public AnimatedObject Locate(string name)
        {
            return _animatedObjects.Find(o => o.Name == name);
        }

        public void Execute()
        {
            Console.WriteLine(_background);
            foreach (AnimatedObject a in _animatedObjects)
            {
                Console.WriteLine(a.Attack());
            }
        }
    }
}
