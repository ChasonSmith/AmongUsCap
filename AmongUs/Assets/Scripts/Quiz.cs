using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quiz : MonoBehaviour
{
    [SerializeField] GameObject quiz;
    public void CloseQuiz()
    {
        quiz.SetActive(false);
    }
}