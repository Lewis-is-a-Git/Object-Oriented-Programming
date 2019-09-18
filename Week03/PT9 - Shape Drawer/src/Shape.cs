using System;
using SwinGameSDK;

namespace MyGame
{
	public class Shape
	{
		private Color _color;
		private float _x, _y;
		private int _width, _height;
		private bool _selected;

		public bool Selected
		{
			get
			{
				return _selected;
			}
			set
			{
				_selected = value;
			}
		}


		public Shape ()
		{
			_color = Color.Green;
			_x = 0;
			_y = 0;
			_width = 100;
			_height = 100;
		}

		public Shape (Color c, float x, float y, int w, int h)
		{
			_color = c;
			_x = x;
			_y = y;
			_width = w;
			_height = h;
		}

		public Color Color{
			get{ return _color; }
			set{ _color = value; }
		}

		public float X{
			get{ return _x; }
			set{ _x = value; }
		}

		public float Y{
			get{ return _y; }
			set{ _y = value; }
		}

		public int Width{
			get{ return _width; }
			set{ _width = value; }
		}

		public int Height{
			get{ return _height; }
			set{ _height = value; }
		}

		public void Draw(){
			if (_selected == true)
			{
				DrawOutline ();
			}
			SwinGame.FillRectangle (_color, _x, _y, _width, _height);
		}

		public bool IsAt(Point2D pt){
			if (SwinGame.PointInRect (pt, _x, _y, _width, _height))
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public void DrawOutline(){
			SwinGame.FillRectangle (Color.Black, _x-2, _y-2, _width+4, _height+4);
		}

	}
}

