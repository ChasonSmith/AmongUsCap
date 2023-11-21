using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;
using TMPro;
using System.IO;
using Random = UnityEngine.Random;
//using QuizletBackend;

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
        /*Question Q1;
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
        Q4.answer = "1";*/
        List<Question> temp = new List<Question> ();
        //List<Question> QAlist = ReadQuizletFile("Bias\tArises when the design of a study is very likely to underestimate or overestimate the value you want to know\r\nCluster Sample\tA sampling method in which you first divide the population into smaller groups that mirror the characteristics of the population and random groups are chosen\r\nConfounding\tThis occurs when two variables are associated in such a way that their effects on a response variable cannot be distinguished from each other\r\nControl Group\tA group that receives no treatment or a baseline treatment\r\nControl, Random Assignment, Replication\tName the three principles of experimental design\r\nConvenience Sample\tChoosing individuals who are easiest to reach to collect results\r\nExperimental Study\tA study that deliberately imposes some treatment on individuals to measure their responses\r\nExperimental Units\tThe collection of individuals to which treatments are applied\r\nLurking Variable\tA variable that is not being measured but could affect the response in an experiment\r\nNonresponse\tWhen an individual chosen for the sample can't be contacted or refuses to participate in the sample\r\nObservational Study\tA study that observes individuals and measures variables of interest\r\nPopulation\tThe entire group of individuals about which we want information\r\nRandom Assignment\tA study in which the treatments are assigned to all the experimental units completely by chance\r\nResponse Bias\tA systematic pattern of incorrect responses in a sample survey\r\nSample\tThe part of the population from which we actually collect information\r\nSimple Random Sample\tA sampling method in which individuals from the population are chosen in such a way that every set of individuals has an equal chance to be the sample actually selected\r\nStratified Sample\tA sampling method in which the population is first classified into groups of similar individuals and individuals from each group are chosen\r\nSystematic Sample\tA sampling method in which each nth person is chosen to participate in the survey\r\nTreatment\tA specific condition applied to the individuals in an experiment\r\nUndercoverage\tWhen some groups in the population are left out of the process of choosing the sample\r\nVoluntary Response Sample\tA sampling method that consists of people who choose to responding to a general appeal survey");
        List<Question> QAlist = ReadQuizletFile("quizlet.txt");
        /*QAlist.Add(Q1);
        QAlist.Add(Q2);
        QAlist.Add(Q3);
        QAlist.Add(Q4);*/
        /*for(int i = 0; i < QAlist.Count;i++)
        {
            //Debug.Log(QAlist[i].question);
        }*/
        Question selectedQ = selectQuestion(QAlist, ref temp);
        questionText.text = selectedQ.question;
        //Debug.Log(selcetedQ.question);
        //Debug.Log(questionText.text);
        int correctAnswer = Random.Range(1,5);
        int randomIndex;
        LogAnswer.text = selectedQ.answer;
        if(correctAnswer == 1)
        {
            answer1.text = selectedQ.answer;
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
            answer2.text = selectedQ.answer;
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
            answer3.text = selectedQ.answer;
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
            answer4.text = selectedQ.answer;
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
        int QAindex = Random.Range(0,questionList.Count);
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

    public List<Question> ReadQuizletFile(string filename)
    {
        List<Question> temp = new();

        try
        {
            // Pass the file path and file name to the StreamReader constructor
            // This needs to be corrected to an appropriate directory for the project
            using StreamReader sr = new("Assets/Scripts/" + filename);
            //  StringReader quiztxt = new(filename);
            // Read the first line of text
            String line = sr.ReadLine();
            //  String line = quiztxt.ReadLine();
            // Continue to read until you reach end of file
            while (line != null)
            {
                String[] tempLine = line.Split('\t');

                // templine[0] holds the string of the question
                // templine[1] holds the string of the answer
                temp.Add(new Question { question = tempLine[0], answer = tempLine[1]});
                // Read the next line
                line = sr.ReadLine();
                // line = quiztxt.ReadLine();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }
        finally
        {
            Console.WriteLine("Executing finally block.");
        }

        return temp;
    }
}
