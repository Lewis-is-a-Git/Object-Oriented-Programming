using System;
using SwinGameSDK;
using System.Collections.Generic;

namespace MyGame
{
	public class GameMain
	{
		private enum ShapeKind
		{
			Rectangle,
			Circle,
			Line
		}

		public static void Main ()
		{
			//Open the game window
			SwinGame.OpenGraphicsWindow ("GameMain", 800, 600);
			//SwinGame.ShowSwinGameSplashScreen();

			Drawing myDrawing = new Drawing ();

			ShapeKind kindToAdd = ShapeKind.Circle;



			//Run the game loop
			while (false == SwinGame.WindowCloseRequested ()) {
				//Fetch the next batch of UI interaction
				SwinGame.ProcessEvents ();

				//Clear the screen and draw the framerate
				SwinGame.ClearScreen (Color.White);

				// check if R or C is pressed, update kindToAdd
				if (SwinGame.KeyTyped (KeyCode.vk_r)) {
					kindToAdd = ShapeKind.Rectangle;
				}
				if (SwinGame.KeyTyped (KeyCode.vk_c)) {
					kindToAdd = ShapeKind.Circle;
				}

				// Draw a line
				if (SwinGame.KeyTyped (KeyCode.vk_l)) {
					kindToAdd = ShapeKind.Line;
				}

				// checking if the left button of the mouse is being clicked
				if (SwinGame.MouseClicked (MouseButton.LeftButton)) {
					Shape newShape;
					if (kindToAdd == ShapeKind.Circle) {
						Circle newCircle = new Circle ();
						newShape = newCircle;
					} else if (kindToAdd == ShapeKind.Rectangle) {
						Rectangle newRect = new Rectangle ();
						newShape = newRect;
					} else {
						Line newLine = new Line ();
						newLine.EndX = SwinGame.MouseX () + 50;
						newLine.EndY = SwinGame.MouseY () + 50;
						newShape = newLine;
					}

					newShape.X = SwinGame.MouseX ();
					newShape.Y = SwinGame.MouseY ();

					myDrawing.AddShape (newShape);

				}

				if (SwinGame.KeyTyped (KeyCode.vk_SPACE)) {
					myDrawing.Background = SwinGame.RandomRGBColor (255);
				}

				if (SwinGame.MouseClicked (MouseButton.RightButton)) {
					myDrawing.SelectShapesAt (SwinGame.MousePosition ());
				}

				if (SwinGame.KeyTyped (KeyCode.vk_DELETE) || SwinGame.KeyTyped (KeyCode.vk_BACKSPACE)) {
					List<Shape> selected_shapes = new List<Shape> ();
					selected_shapes = myDrawing.SelectedShapes;
					foreach (Shape s in selected_shapes) {
						myDrawing.RemoveShape (s);
					}
				}

				myDrawing.Draw ();

				SwinGame.DrawFramerate (0, 0);

				//Draw onto the screen
				SwinGame.RefreshScreen (60);



			}


		}
	}
}