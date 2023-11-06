////////////////////////////////////////////////////////////////////////////////////////////////////////
//FileName: ReadFile.cs
//FileType: Visual C# Source file
//Author : Krivobarski Michael
//Created On : N/A
//Last Modified On : 10/23/2023 1:43 PM
//Description : A class for reading default quizlet files
////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;



namespace QuizletBackend
{
    public class ReadFile
    {
        

        // comment out or remove this when taking code for implementation
        // main function is only used to verify results as working
        static void Main()
        {
            List<QuestionsAndAnswers> quizlet = ReadQuizletFile("Sample.txt");

            Console.WriteLine("[Question]\t[Answer]");

            for (int i = 0; i < quizlet.Count; i++)
            {
                Console.WriteLine(quizlet[i].ID + ":" + quizlet[i].Question + " | " + quizlet[i].Answer);
            }
        }


        // <summary>
        // returns the result of the file as a QuestionsAndAnswers struct
        // within the same directory as the .cs file
        // the target directory will need to be corrected
        public static List<QuestionsAndAnswers> ReadQuizletFile(string filename)
        {
            List<QuestionsAndAnswers> temp = new();

            int counter = 0;

            try
            {
                // Pass the file path and file name to the StreamReader constructor
                // This needs to be corrected to an appropriate directory for the project
                //using StreamReader sr = new(filename);
                StringReader quiztxt = new(filename);
                // Read the first line of text
                //String line = sr.ReadLine();
                String line = quiztxt.ReadLine();
                // Continue to read until you reach end of file
                while (line != null)
                {
                    String[] tempLine = line.Split('\t');

                    // templine[0] holds the string of the question
                    // templine[1] holds the string of the answer
                    temp.Add(new QuestionsAndAnswers { Question = tempLine[0], Answer = tempLine[1], ID = counter });
                    // Read the next line
                    // line = sr.ReadLine();
                    line = quiztxt.ReadLine();
                    counter++;
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

        // A simple function to flip the questions and answers individually
        public static void Flip(ref QuestionsAndAnswers toFlip)
        {
            (toFlip.Question, toFlip.Answer) = (toFlip.Answer, toFlip.Question);
        }
    }
}