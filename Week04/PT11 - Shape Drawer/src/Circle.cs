using System;
using SwinGameSDK;
namespace MyGame
{
	public class Circle : Shape
	{
		private int _radius;

		public Circle () : this (50) {}

		public Circle (int radius)
		{
			Color = Color.Green;
			_radius = radius;
		}

		public int Radius {
			get { return _radius; }
			set { _radius = value; }
		}

		public override void Draw ()
		{
			if (Selected) {
				DrawOutline ();
			}
			SwinGame.FillCircle (Color, X, Y, _radius);
		}

		public override void DrawOutline ()
		{
			SwinGame.FillCircle (Color.Black, X, Y, _radius + 2);
		}

		public override bool IsAt (Point2D pt)
		{
			return SwinGame.PointInCircle(pt, X, Y, _radius);
		}
	}
}
