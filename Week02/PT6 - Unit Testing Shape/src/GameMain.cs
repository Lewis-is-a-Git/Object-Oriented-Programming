/**
 * Student Number: 101533222
 * Student Name: Lewis Brockman-Horsley
 * Learning Outcomes: I have learnt how to use the Swingame Library, and how to make it work on my laptop.
 */
using System;
using SwinGameSDK;

namespace MyGame
{
	public class GameMain
	{
		public static void Main ()
		{
			//Open the game window
			SwinGame.OpenGraphicsWindow ("GameMain", 800, 600);
			SwinGame.ShowSwinGameSplashScreen ();

			//Create myShape
			Shape myShape = new Shape ();

			//Run the game loop
			while (false == SwinGame.WindowCloseRequested ()) {
				//Fetch the next batch of UI interaction
				SwinGame.ProcessEvents ();

				//Clear the screen and draw the framerate
				SwinGame.ClearScreen (Color.White);
				SwinGame.DrawFramerate (0, 0);

				//Draw the shape
				myShape.Draw ();
				//move the rectangle to the mouse clicked position
				if (SwinGame.MouseClicked (MouseButton.LeftButton)) {
					myShape.X = SwinGame.MouseX ();
					myShape.Y = SwinGame.MouseY ();
				}

				// When the mouse is over the shape and the space bar is pressed
				if (SwinGame.KeyTyped (KeyCode.vk_SPACE)) {
					if (myShape.IsAt (SwinGame.MousePosition ())) {
						myShape.Colour = SwinGame.RandomRGBColor (255); // Change the shape colour
					}
				}


				//Draw onto the screen
				SwinGame.RefreshScreen (60);
			}
		}
	}
}