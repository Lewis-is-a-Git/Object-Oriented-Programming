// FileName: Counter.cs
// Author: Lewis Brockman-Horsley
// Email: 101533222@students.swinburne.edu.au
// Date: 2/09/2019
using System;
namespace Counter
{
    public class Counter
    {
        // Count of Counter
        private int _count;
        // Name of Counter
        private string _name;

        public Counter(string name)
        {
            _name = name;
            _count = 0;
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public int Value
        {
            get
            {
                return _count;
            }
        }

        public void Increment()
        {
            _count++;
        }

        public void Reset()
        {
            _count = 0;
        }
    }
}
