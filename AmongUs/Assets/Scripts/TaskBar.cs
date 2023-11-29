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
using Photon.Pun;
public class TaskBar : MonoBehaviour
{

    public Image image0;
    public Image image1;
    public Image image2;
    public Image image3;
    public Image image4;
    public Image image5;
    public Image image6;
    public Image image7;
    public Image image8;
    public Image image9;
    public Image image10;
    public Image image11;
    public Image image12;
    public Image image13;
    public Image image14;
    public Image image15;
    public Image image16;
    public Image image17;
    public Image image18;
    public Image image19;
    public List<Image> imageList = new List<Image>();
    public int numCorrect;
    public AU_PlayerController[] pObjects;
    public AU_PlayerController[] sortedP;
    public bool gameDone;
    // public int numDead;
    // Start is called before the first frame update
    void Start()
    {
        //PhotonNetwork.AutomaticallySyncScene = true;
        imageList.Add(image0);
        imageList.Add(image1);
        imageList.Add(image2);
        imageList.Add(image3);
        imageList.Add(image4);
        imageList.Add(image5);
        imageList.Add(image6);
        imageList.Add(image7);
        imageList.Add(image8);
        imageList.Add(image9);
        imageList.Add(image10);
        imageList.Add(image11);
        imageList.Add(image12);
        imageList.Add(image13);
        imageList.Add(image14);
        imageList.Add(image15);
        imageList.Add(image16);
        imageList.Add(image17);
        imageList.Add(image18);
        imageList.Add(image19);
        foreach (Image img in imageList)
        {
            img.color = Color.white;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        pObjects = FindObjectsOfType<AU_PlayerController>();
        if(pObjects != null)
        {
            sortedP = pObjects.OrderBy(AU_PlayerController => AU_PlayerController.myPV.ViewID).ToArray();
            if(gameDone == false)
            {
                for (int i = 0; i < pObjects.Length; i++)
                {
                    numCorrect += sortedP[i].questCorr;
                }
            }
            for (int i = 0; i < 20; i++)
            {
                if(i < numCorrect)
                {
                    imageList[i].color = Color.green;
                }
                else
                {
                    imageList[i].color = Color.white;
                }
            }
            if(numCorrect == 7)
            {
                numCorrect = 0;
                gameDone = true;
                PhotonNetwork.AutomaticallySyncScene = true;
                PhotonNetwork.LoadLevel(3);
            }

            numCorrect = 0;
        }
        // Debug.Log(PhotonNetwork.PlayerList.Length);
        // if(PhotonNetwork.PlayerList.Length - numDead == 1)
        // {
        //     if(PhotonNetwork.PlayerList.Length != 1)
        //     {
        //         numDead = 0;
        //         PhotonNetwork.AutomaticallySyncScene = true;
        //         PhotonNetwork.LoadLevel(4);
        //     }
        // }
        
    }

    // public void increaseDead()
    // {
    //     numDead++;
    // }
    public void increaseCorrect()
    {
        //host tracks correct
        sortedP[0].increaseCorrectAns();
    }

    public void decreaseCorrect()
    {
        if(sortedP[0].questCorr > 0)
        {
            sortedP[0].decreaseCorrectAns();
        }
    }
}
