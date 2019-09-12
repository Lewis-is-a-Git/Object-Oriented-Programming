// FileName: Program.cs
// Author: Lewis Brockman-Horsley
// Email: 101533222@students.swinburne.edu.au
// Date: 4/09/2019
using System;
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
            library[0] = new Media("One Day", 20, MediaType.Audio);
            library[1] = new Media("Terminator", 2000, MediaType.Video);
            library[2] = new Media("Animal", 10, MediaType.Image);

            // Play the media
            PlayAll(library);
        }
    }
}
