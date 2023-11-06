using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuizletBackend
{
    // This is an example structure for how we will store questions and answers, replace later with our actual structures.
    public struct QuestionsAndAnswers
    {
        public string Question { get; set; }
        public int ID { get; set; }
        public string Answer { get; set; }
    }

    public struct TaskQnA
    {
        public int Question { get; set; }
        public int Answer1ID { get; set; }
        public int Answer2ID { get; set; }
        public int Answer3ID { get; set; }
        public int Answer4ID { get; set; }
        public int CorrectAns { get; set; }
    }
}