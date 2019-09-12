// FileName: Message.cs
// Author: Lewis Brockman-Horsley
// Email: 101533222@students.swinburne.edu.au
// Date: 2/09/2019
using System;
namespace Application
{
    public class Message
    {
        //readonly has a constructor exemption
        private readonly string _text;

        //Constructor
        public Message(string txt)
        {
            _text = txt;
        }

        //Print the message
        public void Print()
        {
            Console.WriteLine(_text);
        }
    }
}