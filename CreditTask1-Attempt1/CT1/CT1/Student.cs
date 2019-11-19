// FileName: Student.cs
// Author: Lewis Brockman-Horsley
// Email: 101533222@students.swinburne.edu.au
// Date: 24/10/2019
using System;
namespace CT1
{
    public class Student : User
    {
        public Student(String name) : base(name)
        {
        }

        public QuestionSet AttemptSet(QuestionSet questionSet)
        {
            int score = 0;
            foreach (Question q in questionSet.QuestionList)
            {
                if (AttemptQuestion(q) == true)
                {
                    score++;
                }
            }

            questionSet.Results.Add(Name, score);
            return questionSet;
        }

        private bool AttemptQuestion(Question q)
        {
            bool correct = false;
            q.Display();
            correct |= int.Parse(Console.ReadLine()) == q.Answer;

            return correct;
        }
    }
}
