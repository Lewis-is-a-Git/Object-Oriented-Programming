using System;
using NUnit.Framework;
using SwinGameSDK;
using System.Collections.Generic;

namespace MyGame
{
	/// <summary>
	/// Test Drawing object
	/// </summary>
	[TestFixture]
	public class DrawingTest
	{
		/// <summary>
		/// Tests the default initialisation.
		/// </summary>
		[Test]
		public void TestDefaultInitialisation ()
		{
			Drawing myDrawing = new Drawing ();
			Assert.AreEqual (Color.White, myDrawing.Background);
		}

		/// <summary>
		/// Tests the constructor when passed a Color.
		/// </summary>
		[Test]
		public void TestInitialiseWithColor ()
		{
			Drawing myDrawing = new Drawing (Color.Red);
			Assert.AreEqual (Color.Red, myDrawing.Background);
		}

		/// <summary>
		/// Tests the add shape method.
		/// </summary>
		[Test]
		public void TestAddShape ()
		{
			Drawing myDrawing = new Drawing ();
			int count = myDrawing.ShapeCount;

			Assert.AreEqual (0, count, "Drawing should start with no shapes");
			myDrawing.AddShape (new Circle ());
			myDrawing.AddShape (new Rectangle ());
			count = myDrawing.ShapeCount;
			Assert.AreEqual (2, count, "Adding two shapes should increase the count to 2");
		}

		/// <summary>
		/// Tests setting the Selected property.
		/// </summary>
		[Test]
		public void TestSelected ()
		{
			Shape myShape = new Circle ();
			myShape.Selected = true;
			Assert.AreEqual (true, myShape.Selected);
			myShape.Selected = false;
			Assert.AreEqual (false, myShape.Selected);
		}

		/// <summary>
		/// Tests the selecting a shape at a point.
		/// </summary>
		[Test]
		public void TestSelectShape ()
		{
			Drawing myDrawing = new Drawing ();
			Shape [] testShapes = { new Rectangle (Color.Red, 25, 25, 50, 50),
								    new Rectangle (Color.Green,25,10,50,50),
								    new Rectangle (Color.Blue,10,25,50,50)};
			foreach (Shape s in testShapes)
				myDrawing.AddShape (s);

			List<Shape> selected;
			Point2D point;

			point = SwinGame.PointAt (70, 70);
			myDrawing.SelectShapesAt (point);
			selected = myDrawing.SelectedShapes;
			CollectionAssert.Contains (selected, testShapes [0]);
			Assert.AreEqual (1, selected.Count);

			point = SwinGame.PointAt (70, 50);
			myDrawing.SelectShapesAt (point);
			selected = myDrawing.SelectedShapes;
			CollectionAssert.Contains (selected, testShapes [0]);
			CollectionAssert.Contains (selected, testShapes [1]);
			Assert.AreEqual (2, selected.Count);

			point = SwinGame.PointAt (30, 30);
			myDrawing.SelectShapesAt (point);
			selected = myDrawing.SelectedShapes;
			CollectionAssert.Contains (selected, testShapes [0]);
			CollectionAssert.Contains (selected, testShapes [1]);
			CollectionAssert.Contains (selected, testShapes [2]);
			Assert.AreEqual (3, selected.Count);
		}

		/// <summary>
		/// Test removing a selected shape from a Drawing.
		/// </summary>
		[Test]
		public void RemoveShapeTest ()
		{
			Drawing myDrawing = new Drawing ();
			Shape [] testShapes = { 
				new Rectangle (Color.Red, 25, 25, 50, 50),
				new Rectangle (Color.Green,25,10,50,50),
				new Rectangle (Color.Blue,10,25,50,50)};
			foreach (Shape s in testShapes)
				myDrawing.AddShape (s);

			Assert.AreEqual (3, myDrawing.ShapeCount);

			myDrawing.RemoveShape (testShapes [0]);
			Assert.AreEqual (2, myDrawing.ShapeCount);

			CollectionAssert.DoesNotContain (myDrawing.SelectedShapes, testShapes [0], "Does not contain the first item");
			//CollectionAssert.Contains (myDrawing.SelectedShapes, testShapes [1], "contains the second shape");
		}
	}
}

