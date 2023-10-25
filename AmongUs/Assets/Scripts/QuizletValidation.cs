using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

using static QuizletBackend.ReadFile;
using static QuizletBackend.TaskGenerator;

public class QuizletValidation : MonoBehaviour
{
    public TMP_InputField textObject;

    public void OnButtonClick()
    {
        List<QuestionsAndAnswers> quizlet = ReadQuizletFile(textObject.text);

        String extracttxt = "[Question]\t[Answer]\n";


        for (int i = 0; i < quizlet.Count; i++)
        {
            extracttxt += quizlet[i].ID + ":" + quizlet[i].Question + " | " + quizlet[i].Answer + "\n";
        }
        
        Debug.Log(extracttxt);

        List<TaskQnA> tasks = CreateTasks(quizlet);

        PrintTasks(ref tasks, ref quizlet);
    }
}
