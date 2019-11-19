// FileName: Question.cs
// Author: Lewis Brockman-Horsley
// Email: 101533222@students.swinburne.edu.au
// Date: 24/10/2019
using System;
using System.Collections.Generic;
namespace CT1
{
    public class Question
    {

        private int _questionID;
        private string _question;
        private List<string> _choices;
        private int _answer;

        public int QuestionID { get => _questionID; set => _questionID = value; }
        public int Answer { get => _answer; set => _answer = value; }

        public Question(int id, string question, List<string> choices, int answer)
        {
            _questionID = id;
            _question = question;
            _choices = choices;
            _answer = answer;
        }

        public void CreateChoice(String choice)
        {
            _choices.Add(choice);
        }

        public void EditChoice(int i, string choice)
        {
            _choices[i] = choice;
        }

        public void DeleteChoice(int i)
        {
            _choices.RemoveAt(i);
        }

        public void SetAnswer(int a)
        {
            _answer = a;
        }

        public void Display()
        {
            Console.WriteLine(_question + "\n");
            int i = 0;
            foreach (string choice in _choices)
            {
                Console.WriteLine(i++ + ": " + choice);
            }
            Console.WriteLine("Enter Answer(number): ");
        }
    }
}
