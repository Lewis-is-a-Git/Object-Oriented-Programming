// FileName: QuestionSet.cs
// Author: Lewis Brockman-Horsley
// Email: 101533222@students.swinburne.edu.au
// Date: 24/10/2019
using System;
using System.Collections.Generic;
using System.Collections;
namespace CT1
{
    public class QuestionSet
    {
        private int _setID;
        private List<Question> _questionList;
        private Hashtable _results;

        public QuestionSet()
        {
            _results = new Hashtable();
        }

        public QuestionSet(int setID, List<Question> questionList) : this()
        {
            _setID = setID;
            _questionList = questionList;
        }

        public int SetID { get => _setID; set => _setID = value; }
        public List<Question> QuestionList { get => _questionList; set => _questionList = value; }
        public Hashtable Results { get => _results; set => _results = value; }

        public void DisplayResults()
        {
            foreach (string key in _results.Keys)
            {
                Console.WriteLine(String.Format("{0}: {1}", key, _results[key]));
            }

        }

    }
}
