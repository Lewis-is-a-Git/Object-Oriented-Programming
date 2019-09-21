// /**
//  * Student Number: 101533222
//  * Student Name: Lewis Brockman-Horsley
//  * Date: 11/09/2019
//  * Learning Outcomes: I have learnt to use unit testing, Run MyGame - Unit Tests
// **/
using System;
using NUnit.Framework;
using SwinGameSDK;
namespace MyGame
{
	[TestFixture]
	public class ShapeTest
	{
		[Test]
		public void TestShapeAt ()
		{
			Shape s = new Shape ();
			s.X = 25;
			s.Y = 25;
			s.Width = 50;
			s.Height = 50;

			Assert.IsTrue (s.IsAt (SwinGame.PointAt (50, 50)));
			Assert.IsTrue (s.IsAt (SwinGame.PointAt (25, 25)));
			Assert.IsFalse (s.IsAt (SwinGame.PointAt (10, 50)));
			Assert.IsFalse (s.IsAt (SwinGame.PointAt (50, 10)));
		}

		/// <summary>
		/// Tests the shape at when moved.
		/// </summary>
		[Test]
		public void TestShapeAtWhenMoved ()
		{
			Shape s = new Shape ();
			s.X = 25;
			s.Y = 25;
			s.Width = 50;
			s.Height = 50;

			Assert.IsTrue (s.IsAt (SwinGame.PointAt (50, 50)));

			// Move Shape

			s.X = 100;
			s.Y = 100;

			Assert.IsFalse (s.IsAt (SwinGame.PointAt (50, 50)));

		}
		/// <summary>
		/// Tests the shape at when resized.
		/// </summary>
		[Test]
		public void TestShapeAtWhenResized ()
		{
			Shape s = new Shape ();
			s.X = 25;
			s.Y = 25;
			s.Width = 100;
			s.Height = 100;

			Assert.IsTrue (s.IsAt (SwinGame.PointAt (50, 50)));

			s.Width = 20;
			s.Height = 20;

			Assert.IsFalse (s.IsAt (SwinGame.PointAt (50, 50)));
		}

	}
}
