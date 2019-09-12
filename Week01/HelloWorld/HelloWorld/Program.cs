// FileName: Message.cs
// Author: Lewis Brockman-Horsley
// Email: 101533222@students.swinburne.edu.au
// Date: 2/09/2019
using System; // Console
using Application; // Message

namespace HelloWorld
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //Create an instance of the Message class
            Message myMessage = new Message("Hello World! - From Message Object");
            myMessage.Print();

            //Set responses for the provided names
            Message[] messages = new Message[4];
            messages[0] = new Message("Welcome back great creator!");
            messages[1] = new Message("What a lovely name.");
            messages[2] = new Message("Great name!");
            messages[3] = new Message("Thats a silly name.");

            Console.WriteLine("What is your Name?: ");
            String name = Console.ReadLine();

            if (name.ToLower() == "lewis")
            {
                messages[0].Print();
            }
            else if (name.ToLower() == "andrew")
            {
                messages[1].Print();
            }
            else if (name.ToLower() == "wilma")
            {
                messages[2].Print();
            }
            else
            {
                messages[3].Print();
            }
        }
    }
}
