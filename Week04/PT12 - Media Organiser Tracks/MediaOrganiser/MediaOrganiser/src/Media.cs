// FileName: Media.cs
// Author: Lewis Brockman-Horsley
// Email: 101533222@students.swinburne.edu.au
// Date: 29/09/2019
using System;
namespace MediaOrganiser
{
    public abstract class Media
    {
        private string _title;
        private int _size;

        protected Media()
        {
            _title = "";
            _size = 0;
        }

        protected Media(string title, int size)
        {
            _title = title;
            _size = size;
        }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
            }
        }

        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        /// <value>The size.</value>
        public int Size
        {
            get
            {
                return _size;
            }
            set
            {
                _size = value;
            }
        }

        /// <summary>
        /// Play this instance.
        /// </summary>
        /// <returns>The play.</returns>
        public virtual string Play()
        {
            return "Invalid File Type\n";
        }
    }
}
