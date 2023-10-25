using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;
using TMPro;


public class QnA : MonoBehaviour
{
    public TMP_Text questionText;
    public TMP_Text answer1;
    public TMP_Text answer2;
    public TMP_Text answer3;
    public TMP_Text answer4;
    public TMP_Text LogAnswer;
    
    public struct Question {
        public string question;
        public string answer;
    }
    // Start is called before the first frame update
    void Start()
    {
        AskQ();
    }
    void AskQ()
    {
        Question Q1;
        Question Q2;
        Question Q3;
        Question Q4;
        Q1.question = "2+2=?";
        Q1.answer = "4";
        Q2.question = "1+2=?";
        Q2.answer = "3";
        Q3.question = "1+1=?";
        Q3.answer = "2";
        Q4.question = "1+0=?";
        Q4.answer = "1";
        //Question QArray = {Q1, Q2, Q3, Q4};
        List<Question> temp = new List<Question> ();
        List<Question> QAlist = new List<Question> {Q1, Q2, Q3, Q4};
        Question selcetedQ = selectQuestion(QAlist, ref temp);
        questionText.text = selcetedQ.question;
        //Debug.Log(selcetedQ.question);
        //Debug.Log(questionText.text);
        int correctAnswer = Random.Range(1,5);
        int randomIndex;
        LogAnswer.text = selcetedQ.answer;
        if(correctAnswer == 1)
        {
            answer1.text = selcetedQ.answer;
            randomIndex = Random.Range(0,temp.Count);
            answer2.text = temp[randomIndex].answer;
            temp.RemoveAt(randomIndex);
            randomIndex = Random.Range(0,temp.Count);
            answer3.text = temp[randomIndex].answer;
            temp.RemoveAt(randomIndex);
            randomIndex = Random.Range(0,temp.Count);
            answer4.text = temp[randomIndex].answer;
            temp.RemoveAt(randomIndex);
        }
        else if(correctAnswer == 2)
        {
            answer2.text = selcetedQ.answer;
            randomIndex = Random.Range(0,temp.Count);
            answer1.text = temp[randomIndex].answer;
            temp.RemoveAt(randomIndex);
            randomIndex = Random.Range(0,temp.Count);
            answer3.text = temp[randomIndex].answer;
            temp.RemoveAt(randomIndex);
            randomIndex = Random.Range(0,temp.Count);
            answer4.text = temp[randomIndex].answer;
            temp.RemoveAt(randomIndex);
        }
        else if(correctAnswer == 3)
        {
            answer3.text = selcetedQ.answer;
            randomIndex = Random.Range(0,temp.Count);
            answer1.text = temp[randomIndex].answer;
            temp.RemoveAt(randomIndex);
            randomIndex = Random.Range(0,temp.Count);
            answer2.text = temp[randomIndex].answer;
            temp.RemoveAt(randomIndex);
            randomIndex = Random.Range(0,temp.Count);
            answer4.text = temp[randomIndex].answer;
            temp.RemoveAt(randomIndex);
        }
        else if(correctAnswer == 4)
        {
            answer4.text = selcetedQ.answer;
            randomIndex = Random.Range(0,temp.Count);
            answer1.text = temp[randomIndex].answer;
            temp.RemoveAt(randomIndex);
            randomIndex = Random.Range(0,temp.Count);
            answer2.text = temp[randomIndex].answer;
            temp.RemoveAt(randomIndex);
            randomIndex = Random.Range(0,temp.Count);
            answer3.text = temp[randomIndex].answer;
            temp.RemoveAt(randomIndex);
        }

    }

    [SerializeField] GameObject quiz;
    public void CloseQuiz()
    {
        quiz.SetActive(false);
        AskQ();
    }

    public void CheckAnswer(TMP_Text buttonText)
    {
        if (LogAnswer.text == buttonText.text)
        {
            Debug.Log("Correct!");
            CloseQuiz();
        }
        else
        {
            Debug.Log("Wrong!");
            CloseQuiz();
        }
    }

    public Question selectQuestion(List<Question> questionList, ref List<Question> temp) {
        int QAindex = Random.Range(0,4);
        Question TQ = questionList[QAindex];
        questionList.RemoveAt(QAindex);
        int loops = 0;
        for(int i = 0; questionList.Count > 0; i++)
        {
            temp.Add(questionList[i-loops]);
            questionList.RemoveAt(i-loops);
            loops++;
        }
        return TQ;
    }


}
