using System;
using SwinGameSDK;
namespace MyGame
{
	public class Line : Shape
	{
		private float _endX, _endY;

		public Line () : this(Color.Green, 0, 0, 50, 50){}

		public Line (Color clr, float startX, float startY, float endX, float endY)
		{
			Color = clr;
			X = startX;
			Y = startY;
			_endX = endX;
			_endY = endY;
		}

		public float EndX {
			get { return _endX;}
			set {_endX = value;}
		}

		public float EndY {
			get {return _endY;}
			set {_endY = value;}
		}

		public override void Draw ()
		{
			if (Selected) {
				DrawOutline ();
			}
			SwinGame.DrawLine (Color, X, Y, _endX, _endY);
		}

		public override void DrawOutline ()
		{
			int radius = 5;
			SwinGame.FillCircle (Color.Black, X, Y, radius);
			SwinGame.FillCircle (Color.Black, _endX, _endY, radius);
		}

		public override bool IsAt (Point2D pt)
		{
			return SwinGame.PointOnLine (pt, X, Y, _endX, _endY);
		}
	}
}
