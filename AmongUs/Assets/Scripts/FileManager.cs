using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Unity.VisualScripting;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.IO;
using System;
using System.Diagnostics;
using Debug = UnityEngine.Debug;
using System.Numerics;
using TMPro;
using System.Text;

public class FileManager : MonoBehaviour
{
    public Button JoinButton;
    public Button ServerButton;

    public TMP_Text UrlText;



    public void RunScraper()
    {
        //File.Delete("Assets/Scripts/quizlet.txt");
        // this saves the url that was provided in the text box
        SaveURL(UrlText.text.TrimEnd("")); // a weird character is left behind if this trim isn't called...
        Process proc = new Process();
        string app = Application.dataPath + "/Scripts/scraper.exe";

        // we need this later to reset the directory back cause unity crashes otherwise
        string originalDir = Directory.GetCurrentDirectory();

        Directory.SetCurrentDirectory(Application.dataPath + "/Scripts");
        proc.StartInfo.UseShellExecute = true;
        proc.StartInfo.FileName = app;
        //proc.StartInfo.RedirectStandardOutput = true;
        proc.Start();
        proc.WaitForExit();
        Directory.SetCurrentDirectory(originalDir);
        //Debug.Log(Directory.GetCurrentDirectory());
        //proc.WorkingDirectory

        // this is to ensure the quizlet we pulled is actually valid and went through properly
        VerifyQuizlet();
    }

    void SaveURL(string url)
    {
        // we need a simple check if ?new isn't at the end of the url, because quizlet throws a fit otherwise for some reason
        // also its part of the new quizlet format
        //Debug.Log(url.Substring(url.Length - 4));
        if (url.Substring(url.Length - 4) != "?new")
            url += "?new";

        Debug.Log(url);

        File.WriteAllText("Assets/Scripts/url.txt", url);
    }

    void VerifyQuizlet()
    {
        try
        {
            using StreamReader sr = new StreamReader("Assets/Scripts/quizlet.txt");

            string line = sr.ReadLine();

            if (line == null)
                throw new Exception();

            while (line != null)
            {
                String[] tempLine = line.Split('\t');

                //Debug.Log("Q: " + tempLine[0] + "| A: " + tempLine[1]);

                if (tempLine[0].Length == 0 | tempLine[1].Length == 0)
                {
                    throw new Exception("Invalid Quizlet File");
                }

                line = sr.ReadLine();

            }

            JoinButton.interactable = true;
            ServerButton.interactable = true;
        }
        catch (Exception)
        {
            JoinButton.interactable = false;
            ServerButton.interactable = false;
        }

    }

}
