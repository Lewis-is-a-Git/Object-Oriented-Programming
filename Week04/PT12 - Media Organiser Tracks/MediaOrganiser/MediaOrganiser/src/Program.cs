// FileName: Program.cs
// Author: Lewis Brockman-Horsley
// Email: 101533222@students.swinburne.edu.au
// Date: 29/09/2019
using System;
using MediaOrganiser.src;

namespace MediaOrganiser
{
    class MainClass
    {
        // Print the details of each media item to the console
        private static void PlayAll(Media[] library)
        {
            foreach (Media l in library)
            {
                Console.WriteLine("Title: " + l.Title);
                Console.WriteLine("Size: " + l.Size);
                Console.WriteLine(l.Play());
            }
        }

        public static void Main(string[] args)
        {
            // Create media library
            Media[] library = new Media[3];
            library[0] = new Audio("One Day", "Lewis", 100);
            library[1] = new Image(1000, 2000);
            library[2] = new Video();

            // Play the media
            PlayAll(library);

            Console.ReadKey();
        }
    }
}
