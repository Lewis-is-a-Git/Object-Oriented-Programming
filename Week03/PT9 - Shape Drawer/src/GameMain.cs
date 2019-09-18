using System;
using SwinGameSDK;
using System.Collections.Generic;

namespace MyGame
{
	public class GameMain
	{
		public static void Main ()
		{
			//Open the game window
			SwinGame.OpenGraphicsWindow ("GameMain", 800, 600);
			//SwinGame.ShowSwinGameSplashScreen();

			Drawing myDrawing = new Drawing ();

			//Run the game loop
			while (false == SwinGame.WindowCloseRequested ()) {
				//Fetch the next batch of UI interaction
				SwinGame.ProcessEvents ();

				//Clear the screen and draw the framerate
				SwinGame.ClearScreen (Color.White);



				// checking if the left button of the mouse is being clicked
				if (SwinGame.MouseClicked (MouseButton.LeftButton)) {
					Shape myShape = new Shape ();
					myShape.X = SwinGame.MouseX (); //change the myShape's X value
					myShape.Y = SwinGame.MouseY (); //change the myShape's Y value
					myDrawing.AddShape (myShape);
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