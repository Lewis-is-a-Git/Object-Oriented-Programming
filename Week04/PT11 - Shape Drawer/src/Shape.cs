using System;
using SwinGameSDK;

namespace MyGame
{
    /// <summary>
    /// Abstract class shape: this needs to be abstract as it allows 
    /// us to create new shapes when we need.
    /// </summary>
    public abstract class Shape
    {
        private Color _color;
        private bool _selected;
        private float _x, _y;

        public Shape () : this (Color.White) { }

        public Shape (Color c)
        {
            _color = c;
        }

        public bool Selected {
            get {
                return _selected;
            }
            set {
                _selected = value;
            }
        }

        public Color Color {
            get { return _color; }
            set { _color = value; }
        }

        public float X {
            get { return _x; }
            set { _x = value; }
        }

        public float Y {
            get { return _y; }
            set { _y = value; }
        }

        /// <summary>
        /// This is abstract because each type of shape is drawn differently
        /// </summary>
        public abstract void Draw ();

        /// <summary>
        /// This must be abstract because the shape of the area 
        /// changes for each shape.
        /// </summary>
        /// <returns>True if the point is in the shape.</returns>
        /// <param name="pt">Point.</param>
        public abstract bool IsAt (Point2D pt);

        /// <summary>
        /// Draws an outline around the shape, the shape 
        /// of the outline is based on the shape.
        /// </summary>
        public abstract void DrawOutline ();

    }
}

