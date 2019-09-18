// FileName: Media.cs
// Author: Lewis Brockman-Horsley
// Email: 101533222@students.swinburne.edu.au
// Date: 4/09/2019
using System;
namespace MediaOrganiser
{
    public class Media
    {
        private string _title;
        private int _size;
        private MediaType _type;

        public Media(string title, int size, MediaType type)
        {
            _title = title;
            _size = size;
            _type = type;
        }

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
        public MediaType Type
        {
            get
            {
                return _type;
            }
        }

        // Pretend to play the media, returns a strings
        public string Play()
        {
            if (_type == MediaType.Audio)
            {
                return "Ready for some light music!\n";
            }
            else if (_type == MediaType.Video)
            {
                return "Be entertained by the visual effect!\n";
            }
            else if (_type == MediaType.Image)
            {
                return "High resolution image provided!\n";
            }
            else { return "Invalid File Type\n"; }
        }
    }
}
