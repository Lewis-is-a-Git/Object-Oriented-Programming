using System;
using SwinGameSDK;
namespace MyGame
{
	public class Rectangle : Shape
	{
		private int _width, _height;
	

		public Rectangle ()
		{
			Color = Color.Green;
			X = 0;
			Y = 0;
			_width = 100;
			_height = 100;
		}

		public Rectangle (Color clr, float x, float y, int width, int height) : base(clr)
		{
			Color = clr;
			X = x;
			Y = y;
			Width = width;
			Height = height;
		}

		public int Width {
			get { return _width; }
			set { _width = value; }
		}

		public int Height {
			get { return _height; }
			set { _height = value; }
		}

		public override void Draw ()
		{
			if (Selected == true) {
				DrawOutline ();
			}
			SwinGame.FillRectangle (Color, X, Y, _width, _height);
		}

		public override void DrawOutline ()
		{
			SwinGame.FillRectangle (Color.Black, X - 2, Y - 2, _width + 4, _height + 4);
		}

		public override bool IsAt (Point2D pt)
		{
			return SwinGame.PointInRect(pt, X, Y, _width, _height);
		}
	}
}
