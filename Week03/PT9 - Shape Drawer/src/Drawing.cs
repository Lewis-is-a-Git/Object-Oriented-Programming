using System;
using SwinGameSDK;
using System.Collections.Generic;

namespace MyGame
{
	public class Drawing
	{
		private readonly List<Shape> _shapes;
		private Color _background;


		public List<Shape> SelectedShapes
		{
			get { 
				List<Shape> result;
				result = new List<Shape> ();
				foreach (Shape s in _shapes)
				{
					if (s.Selected == true)
					{
						result.Add (s);
					}
				}
				return result;
			}
		}

		public int ShapeCount
		{
			get{ return _shapes.Count; }
		}

		public Color Background{
			get{ return _background; }
			set{ _background = value; }
		}

		public Drawing (Color background)
		{
			_shapes = new List<Shape> ();
			_background = background;
		}

		public Drawing():this(Color.White){

		}

		public void AddShape (Shape shape)
		{
			_shapes.Add (shape);
		}

		public void Draw(){
			SwinGame.ClearScreen (_background);
			foreach (Shape s in _shapes)
			{
				s.Draw ();
			}

		}

		public void SelectShapesAt (Point2D pt)
		{
			foreach (Shape s in _shapes)
			{
				if(s.IsAt(pt)){
					s.Selected = true;
				}else{
					s.Selected = false;
				}
			}
		}

		public void RemoveShape (Shape shape)
		{
			_shapes.Remove (shape);
		}
	}
}

