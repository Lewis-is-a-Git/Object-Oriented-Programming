/**
 * Student Number 101533222
 * Student Name: Lewis Brockman-Horsley
 * */
using System;
using SwinGameSDK;

namespace MyGame
{
	public class Shape
	{
		private Color _colour;
		private float _x, _y;
		private int _width, _height;

		public Shape ()
		{
			_colour = Color.Green;
			_x = 0;
			_y = 0;
			_width = 100;
			_height = 100;
		}

		public Color Colour {
			get { return _colour; }
			set { _colour = value; }
		}

		public float X {
			get { return _x; }
			set { _x = value; }
		}

		public float Y {
			get { return _y; }
			set { _y = value; }
		}

		public int Width {
			get { return _width; }
			set { _width = value; }
		}

		public int Height {
			get { return _height; }
			set { _height = value; }
		}

		public void Draw ()
		{
			SwinGame.FillRectangle (_colour, _x, _y,
								   _width, _height);
		}

		public bool IsAt (Point2D pt)
		{
			return SwinGame.PointInRect (pt, _x, _y,
								 _width, _height);
		}
	}
}
