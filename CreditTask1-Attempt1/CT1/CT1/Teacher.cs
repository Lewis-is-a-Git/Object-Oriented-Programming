// FileName: Teacher.cs
// Author: Lewis Brockman-Horsley
// Email: 101533222@students.swinburne.edu.au
// Date: 24/10/2019
using System;
using System.Collections.Generic;
namespace CT1
{
    public class Teacher : User
    {
        List<QuestionSet> _questionSets;
        List<Question> _questionPool;

        public List<QuestionSet> QuestionSets { get => _questionSets; set => _questionSets = value; }
        public List<Question> QuestionPool { get => _questionPool; set => _questionPool = value; }

        public Teacher(String name) : base(name)
        {
            _questionSets = new List<QuestionSet>();
            QuestionPool = new List<Question>();
        }

        public void CreateQuestion()
        {
            Console.WriteLine("enter question ID (number): ");
            int questioID = int.Parse(Console.ReadLine());

            Console.WriteLine("enter question: ");
            string questionSentence = Console.ReadLine();

            // Console.WriteLine("how many choices would you like?: ");
            int choices = 4;
            //choices = int.Parse( Console.ReadLine());

            List<string> possibleAnswers = new List<string>();
            for (int i = 0; i < choices; i++)
            {
                Console.WriteLine("enter question choice: ");
                string possibleAnswer = Console.ReadLine();
                possibleAnswers.Add(possibleAnswer);
            }

            Console.Write("Which question choice was correct?(number) ");
            for (int i = 0; i < choices; i++)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine(": ");
            int answer = int.Parse(Console.ReadLine());

            Question question = new Question(questioID, questionSentence, possibleAnswers, answer);
            QuestionPool.Add(question);
        }

        public void ManageQuestions()
        {

        }

        public void CreateQuestionSet(List<int> IDs)
        {
            List<Question> set = new List<Question>();
            foreach (int ID in IDs)
            {
                set.Add(QuestionPool.Find(q => q.QuestionID == ID));
            }

            QuestionSets.Add(new QuestionSet(1, set));
        }
    }
}
