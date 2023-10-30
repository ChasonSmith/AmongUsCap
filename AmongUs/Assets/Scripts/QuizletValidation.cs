using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

using static QuizletBackend.ReadFile;
using static QuizletBackend.TaskGenerator;

namespace QuizletBackend
{
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

        // this function is more of a proof of concept for a modified QnA.cs file
        // once we get a valid storage system, we will no longer use this.
        public static (List<TaskQnA>,List<QuestionsAndAnswers>) TempDataProvide()
        {
            List<QuestionsAndAnswers> quizlet = ReadQuizletFile("Bias\tArises when the design of a study is very likely to underestimate or overestimate the value you want to know\r\nCluster Sample\tA sampling method in which you first divide the population into smaller groups that mirror the characteristics of the population and random groups are chosen\r\nConfounding\tThis occurs when two variables are associated in such a way that their effects on a response variable cannot be distinguished from each other\r\nControl Group\tA group that receives no treatment or a baseline treatment\r\nControl, Random Assignment, Replication\tName the three principles of experimental design\r\nConvenience Sample\tChoosing individuals who are easiest to reach to collect results\r\nExperimental Study\tA study that deliberately imposes some treatment on individuals to measure their responses\r\nExperimental Units\tThe collection of individuals to which treatments are applied\r\nLurking Variable\tA variable that is not being measured but could affect the response in an experiment\r\nNonresponse\tWhen an individual chosen for the sample can't be contacted or refuses to participate in the sample\r\nObservational Study\tA study that observes individuals and measures variables of interest\r\nPopulation\tThe entire group of individuals about which we want information\r\nRandom Assignment\tA study in which the treatments are assigned to all the experimental units completely by chance\r\nResponse Bias\tA systematic pattern of incorrect responses in a sample survey\r\nSample\tThe part of the population from which we actually collect information\r\nSimple Random Sample\tA sampling method in which individuals from the population are chosen in such a way that every set of individuals has an equal chance to be the sample actually selected\r\nStratified Sample\tA sampling method in which the population is first classified into groups of similar individuals and individuals from each group are chosen\r\nSystematic Sample\tA sampling method in which each nth person is chosen to participate in the survey\r\nTreatment\tA specific condition applied to the individuals in an experiment\r\nUndercoverage\tWhen some groups in the population are left out of the process of choosing the sample\r\nVoluntary Response Sample\tA sampling method that consists of people who choose to responding to a general appeal survey");
            List<TaskQnA> tasks = CreateTasks(quizlet);

            return (tasks,quizlet);
        }

    }
}