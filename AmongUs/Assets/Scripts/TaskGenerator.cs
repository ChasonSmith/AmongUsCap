////////////////////////////////////////////////////////////////////////////////////////////////////////
//FileName: TaskGenerator.cs
//FileType: Visual C# Source file
//Author : Krivobarski Michael
//Created On : 10/23/2023 10:23 AM
//Last Modified On : 10/23/2023 1:43 PM
//Description : Class for generating tasks 
////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;

using static QuizletBackend.ReadFile;

namespace QuizletBackend
{
    public class TaskGenerator
    {
        // Main is used for displaying the working version of said code
        // It should not be enable or used in the final implementation
        

        static void Main()
        {
            List<QuestionsAndAnswers> quizlet = ReadQuizletFile("Bias\tArises when the design of a study is very likely to underestimate or overestimate the value you want to know\r\nCluster Sample\tA sampling method in which you first divide the population into smaller groups that mirror the characteristics of the population and random groups are chosen\r\nConfounding\tThis occurs when two variables are associated in such a way that their effects on a response variable cannot be distinguished from each other\r\nControl Group\tA group that receives no treatment or a baseline treatment\r\nControl, Random Assignment, Replication\tName the three principles of experimental design\r\nConvenience Sample\tChoosing individuals who are easiest to reach to collect results\r\nExperimental Study\tA study that deliberately imposes some treatment on individuals to measure their responses\r\nExperimental Units\tThe collection of individuals to which treatments are applied\r\nLurking Variable\tA variable that is not being measured but could affect the response in an experiment\r\nNonresponse\tWhen an individual chosen for the sample can't be contacted or refuses to participate in the sample\r\nObservational Study\tA study that observes individuals and measures variables of interest\r\nPopulation\tThe entire group of individuals about which we want information\r\nRandom Assignment\tA study in which the treatments are assigned to all the experimental units completely by chance\r\nResponse Bias\tA systematic pattern of incorrect responses in a sample survey\r\nSample\tThe part of the population from which we actually collect information\r\nSimple Random Sample\tA sampling method in which individuals from the population are chosen in such a way that every set of individuals has an equal chance to be the sample actually selected\r\nStratified Sample\tA sampling method in which the population is first classified into groups of similar individuals and individuals from each group are chosen\r\nSystematic Sample\tA sampling method in which each nth person is chosen to participate in the survey\r\nTreatment\tA specific condition applied to the individuals in an experiment\r\nUndercoverage\tWhen some groups in the population are left out of the process of choosing the sample\r\nVoluntary Response Sample\tA sampling method that consists of people who choose to responding to a general appeal survey");

            /*Console.WriteLine("[Question]\t[Answer]");

            for (int i = 0; i < quizlet.Count; i++)
            {
                Console.WriteLine(quizlet[i].ID + ":" + quizlet[i].Question + " | " + quizlet[i].Answer);
            }*/

            List<TaskQnA> tasks = CreateTasks(quizlet);

            PrintTasks(ref tasks,ref quizlet);
        }

        // <summary>
        // returns quiz-style tasks based on the number of existing tasks
        // returns null if there were less than 4 question and answers given to it
        public static List<TaskQnA> CreateTasks(List<QuestionsAndAnswers> Data)
        {
            // Simple check to ensure the quizlet has more than 4 questions in it.
            // returns null if we don't have enough questions
            if(Data.Count <= 4)
            {
                return null;
            }

            List<TaskQnA> tasks = new();

            for (int i = 0; i < Data.Count; i++)
            {
                // prevent duplicate answers from appearing in the same question
                List<int> myList = new() { i };

                System.Random rand = new();

                // Selects and puts 3 other options
                for (int x = 0; x < 3; x++)
                {
                    int randQuestion = rand.Next(Data.Count - 1);

                    while (myList.Contains(randQuestion))
                    {
                        randQuestion = rand.Next(Data.Count - 1);
                    }

                    myList.Add(randQuestion);
                }
                //Console.WriteLine(myList[0] + " "+ myList[1] + " " + myList[2] + " " + myList[3]);

                tasks.Add(new TaskQnA{Question = myList[0], Answer1ID = myList[0], Answer2ID = myList[1], Answer3ID = myList[2], Answer4ID = myList[3], CorrectAns = myList[0] });


                myList.Clear();

            }
            // DEBUGGING STUFF
            /*for( int j = 0; j < tasks.Count; j++)
                Console.Write("Q: " + tasks[j].Question + " A1: " + tasks[j].Answer1ID + " A2: " + tasks[j].Answer2ID + " A3: " + tasks[j].Answer3ID + " A4: " + tasks[j].Answer4ID + "\n");
*/
            return tasks;
        }
        
        // <Summary>
        // A simple printing function for the questions to show it can generate random questions for each task
        public static void PrintTasks(ref List<TaskQnA> tasks, ref List<QuestionsAndAnswers> qna)
        {
            String debuglog = "";

            for(int i = 0;i<tasks.Count;i++)
            {
                /*Console.WriteLine("QUESTION " + (i+1) + ":\n");
                Console.WriteLine("Q: " + qna[tasks[i].Question].Question);
                Console.WriteLine("A1: " + qna[tasks[i].Answer1ID].Answer);
                Console.WriteLine("A2: " + qna[tasks[i].Answer2ID].Answer);
                Console.WriteLine("A3: " + qna[tasks[i].Answer3ID].Answer);
                Console.WriteLine("A4: " + qna[tasks[i].Answer4ID].Answer+"\n");
                Console.WriteLine("Correct Answer: " + qna[tasks[i].CorrectAns].Answer);
                Console.WriteLine("\n");*/
                debuglog += "\nQUESTION " + (i + 1) + ":\n\n";
                debuglog += "Q: " + qna[tasks[i].Question].Question + "\n";
                debuglog += "A1: " + qna[tasks[i].Answer1ID].Answer + "\n";
                debuglog += "A2: " + qna[tasks[i].Answer2ID].Answer + "\n";
                debuglog += "A3: " + qna[tasks[i].Answer3ID].Answer + "\n";
                debuglog += "A4: " + qna[tasks[i].Answer4ID].Answer + "\n";
                debuglog += "\nCorrect Answer: " + qna[tasks[i].CorrectAns].Answer + "\n";
                debuglog += "\n";
            }

            Debug.Log(debuglog);
        }

    }
}
