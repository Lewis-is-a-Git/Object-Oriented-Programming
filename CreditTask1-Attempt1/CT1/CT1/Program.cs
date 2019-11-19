// FileName: Program.cs
// Author: Lewis Brockman-Horsley
// Email: 101533222@students.swinburne.edu.au
// Date: 24/10/2019
using System;
using System.Collections.Generic;

namespace CT1
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Teacher teacher = new Teacher("lewis");

            //teacher.CreateQuestion();

            Student student = new Student("rocky");

            List<string> choices = new List<string>();
            choices.Add("4");
            choices.Add("3");
            choices.Add("7");
            choices.Add("12");
            Question q1 = new Question(12, "what is 1 + 2?", choices, 1);
            Question q2 = new Question(13, "what is 3 + 4?", choices, 2);

            teacher.QuestionPool.Add(q1);
            teacher.QuestionPool.Add(q2);

            List<int> setIDs = new List<int>();
            setIDs.Add(12);
            setIDs.Add(13);

            teacher.CreateQuestionSet(setIDs);

            QuestionSet set = teacher.QuestionSets.Find(qs => qs.SetID == 1);

            teacher.QuestionSets.Remove(set);
            teacher.QuestionSets.Add(student.AttemptSet(set));
            teacher.QuestionSets.Find(qs => qs.SetID == 1).DisplayResults();
        }
    }
}
