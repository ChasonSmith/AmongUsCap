using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System.Linq;

public class Voting : MonoBehaviour
{
    public Button P1;
    public Button P2;
    public Button P3;
    public Button P4;
    public Button P5;
    public Button P6;
    public Button P7;
    public Button P8;
    public Button P9;
    public Button P10;
    public Button skipVote;
    public TMP_Text p1Name;
    public TMP_Text p2Name;
    public TMP_Text p3Name;
    public TMP_Text p4Name;
    public TMP_Text p5Name;
    public TMP_Text p6Name;
    public TMP_Text p7Name;
    public TMP_Text p8Name;
    public TMP_Text p9Name;
    public TMP_Text p10Name;
    public TMP_Text skipText;
    public AU_PlayerController[] objectsOfType;
    public AU_PlayerController[] sortedPlayers;
    public int votes1;
    public int votes2;
    public int votes3;
    public int votes4;
    public int votes5;
    public int votes6;
    public int votes7;
    public int votes8;
    public int votes9;
    public int votes10;
    public int votesSkip;
    public int totalVotes;
    public List<int> votesList = new List<int>();
    public int maxVotes;
    public int indexVoted;
    public bool tie;
    [SerializeField] GameObject votePanel;
    public int playersDead;
    //public PhotonView myPVo;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void EnablePanelForAll()
    {
        objectsOfType = FindObjectsOfType<AU_PlayerController>();
        objectsOfType[0].myPV.RPC("EnablePanelRPC", RpcTarget.AllBuffered);
    }

    // RPC method to enable the panel for all players
    [PunRPC]
    void EnablePanelRPC()
    {
        votePanel.SetActive(true); // Enable the panel
    }

    private void OnEnable()
    {
        votesList.Clear();
        votes1 = 0;
        votes2 = 0;
        votes3 = 0;
        votes4 = 0;
        votes5 = 0;
        votes6 = 0;
        votes7 = 0;
        votes8 = 0;
        votes9 = 0;
        votes10 = 0;
        votesSkip = 0;
        totalVotes = 0;
        objectsOfType = FindObjectsOfType<AU_PlayerController>();
        objectsOfType[objectsOfType.Length - 1].resetCasting();
        maxVotes = 0;
        indexVoted = 0;
        tie = false;
        sortedPlayers = objectsOfType.OrderBy(AU_PlayerController => AU_PlayerController.myPV.ViewID).ToArray();
        for (int i = 0; i < objectsOfType.Length; i++)
        {
            
            
            //Debug.Log(objectsOfType[i].myPV.ViewID);
            //Debug.Log(sortedPlayers[i].myPV.ViewID);
            switch (i)
            {
            case 0:
                P1.gameObject.SetActive(true);
                p1Name.text = sortedPlayers[i].pUsername.text;
                if(sortedPlayers[i].isDead == true)
                {
                    P1.interactable = false;
                    P1.image.color = Color.red;
                }
                break;

            case 1:
                P2.gameObject.SetActive(true);
                p2Name.text = sortedPlayers[i].pUsername.text;
                if(sortedPlayers[i].isDead == true)
                {
                    P2.interactable = false;
                    P2.image.color = Color.red;
                }
                break;

            case 2:
                P3.gameObject.SetActive(true);
                p3Name.text = sortedPlayers[i].pUsername.text;
                if(sortedPlayers[i].isDead == true)
                {
                    P3.interactable = false;
                    P3.image.color = Color.red;
                }
                break;

            case 3:
                P4.gameObject.SetActive(true);
                p4Name.text = sortedPlayers[i].pUsername.text;
                if(sortedPlayers[i].isDead == true)
                {
                    P4.interactable = false;
                    P4.image.color = Color.red;
                }
                break;
            
            case 4:
                P5.gameObject.SetActive(true);
                p5Name.text = sortedPlayers[i].pUsername.text;
                if(sortedPlayers[i].isDead == true)
                {
                    P5.interactable = false;
                    P5.image.color = Color.red;
                }
                break;
            
            case 5:
                P6.gameObject.SetActive(true);
                p6Name.text = sortedPlayers[i].pUsername.text;
                if(sortedPlayers[i].isDead == true)
                {
                    P6.interactable = false;
                    P6.image.color = Color.red;
                }
                break;
            
            case 6:
                P7.gameObject.SetActive(true);
                p7Name.text = sortedPlayers[i].pUsername.text;
                if(sortedPlayers[i].isDead == true)
                {
                    P7.interactable = false;
                    P7.image.color = Color.red;
                }
                break;
            
            case 7:
                P8.gameObject.SetActive(true);
                p8Name.text = sortedPlayers[i].pUsername.text;
                if(sortedPlayers[i].isDead == true)
                {
                    P8.interactable = false;
                    P8.image.color = Color.red;
                }
                break;
            
            case 8:
                P9.gameObject.SetActive(true);
                p9Name.text = sortedPlayers[i].pUsername.text;
                if(sortedPlayers[i].isDead == true)
                {
                    P9.interactable = false;
                    P9.image.color = Color.red;
                }
                break;
            
            case 9:
                P10.gameObject.SetActive(true);
                p10Name.text = sortedPlayers[i].pUsername.text;
                if(sortedPlayers[i].isDead == true)
                {
                    P10.interactable = false;
                    P10.image.color = Color.red;
                }
                break;
            
            default:
                Debug.Log("i out of scope");
                break;
            }
        }
        skipVote.gameObject.SetActive(true);
        skipText.text = "SKIP";
    }


    public void voted1()
    {
        objectsOfType[objectsOfType.Length - 1].voteCasting1();
        objectsOfType[objectsOfType.Length - 1].voteCasting();
    }
    public void voted2()
    {
        objectsOfType[objectsOfType.Length - 1].voteCasting2();
        objectsOfType[objectsOfType.Length - 1].voteCasting();
    }
    public void voted3()
    {
        objectsOfType[objectsOfType.Length - 1].voteCasting3();
        objectsOfType[objectsOfType.Length - 1].voteCasting();
    }
    public void voted4()
    {
        objectsOfType[objectsOfType.Length - 1].voteCasting4();
        objectsOfType[objectsOfType.Length - 1].voteCasting();
    }
    public void voted5()
    {
        objectsOfType[objectsOfType.Length - 1].voteCasting5();
        objectsOfType[objectsOfType.Length - 1].voteCasting();
    }
    public void voted6()
    {
        objectsOfType[objectsOfType.Length - 1].voteCasting6();
        objectsOfType[objectsOfType.Length - 1].voteCasting();
    }
    public void voted7()
    {
        objectsOfType[objectsOfType.Length - 1].voteCasting7();
        objectsOfType[objectsOfType.Length - 1].voteCasting();
    }
    public void voted8()
    {
        objectsOfType[objectsOfType.Length - 1].voteCasting8();
        objectsOfType[objectsOfType.Length - 1].voteCasting();
    }
    public void voted9()
    {
        objectsOfType[objectsOfType.Length - 1].voteCasting9();
        objectsOfType[objectsOfType.Length - 1].voteCasting();
    }
    public void voted10()
    {
        objectsOfType[objectsOfType.Length - 1].voteCasting10();
        objectsOfType[objectsOfType.Length - 1].voteCasting();
    }
    public void votedSkip()
    {
        objectsOfType[objectsOfType.Length - 1].voteCastingSkip();
        objectsOfType[objectsOfType.Length - 1].voteCasting();
    }
    

    // Update is called once per frame
    void Update()
    {

        for (int i = 0; i < objectsOfType.Length; i++)
        {
            totalVotes += objectsOfType[i].voteCast;
            votes1 += objectsOfType[i].voteCast1;
            votes2 += objectsOfType[i].voteCast2;
            votes3 += objectsOfType[i].voteCast3;
            votes4 += objectsOfType[i].voteCast4;
            votes5 += objectsOfType[i].voteCast5;
            votes6 += objectsOfType[i].voteCast6;
            votes7 += objectsOfType[i].voteCast7;
            votes8 += objectsOfType[i].voteCast8;
            votes9 += objectsOfType[i].voteCast9;
            votes10 += objectsOfType[i].voteCast10;
            votesSkip += objectsOfType[i].voteCastSkip;
            if(objectsOfType[i].isDead == true)
            {
                playersDead++;
            }
        }
        if(totalVotes == objectsOfType.Length-playersDead)
        {
            votesList.Add(votes1);
            votesList.Add(votes2);
            votesList.Add(votes3);
            votesList.Add(votes4);
            votesList.Add(votes5);
            votesList.Add(votes6);
            votesList.Add(votes7);
            votesList.Add(votes8);
            votesList.Add(votes9);
            votesList.Add(votes10);
            votesList.Add(votesSkip);
            voteOut();
        }
        votes1 = 0;
        votes2 = 0;
        votes3 = 0;
        votes4 = 0;
        votes5 = 0;
        votes6 = 0;
        votes7 = 0;
        votes8 = 0;
        votes9 = 0;
        votes10 = 0;
        votesSkip = 0;
        totalVotes = 0;
        playersDead = 0;
    }

    public void voteOut()
    {
        for (int i = 0; i < votesList.Count; i++)
        {
            //Debug.Log("ran");
            if (votesList[i] > maxVotes)
            {
                maxVotes = votesList[i]; // Update max if a greater value is found
                tie = false;
            }
            else if (votesList[i] == maxVotes)
            {
                indexVoted = 10;
                tie = true;
            }
        }
        if(tie == false)
        {
            indexVoted = votesList.IndexOf(maxVotes);
        }
        if(indexVoted != 10)
        {
            Debug.Log(sortedPlayers[indexVoted].isImposter);
            if(sortedPlayers[indexVoted].isImposter == true)
            {
                //Debug.Log("scholars win");
                PhotonNetwork.AutomaticallySyncScene = true;
                PhotonNetwork.LoadLevel(3);
            }
            else
            {
                sortedPlayers[indexVoted].myPV.RPC("RPC_Kill", RpcTarget.All);
            }
        }
        P1.gameObject.SetActive(false);
        P2.gameObject.SetActive(false);
        P3.gameObject.SetActive(false);
        P4.gameObject.SetActive(false);
        P5.gameObject.SetActive(false);
        P6.gameObject.SetActive(false);
        P7.gameObject.SetActive(false);
        P8.gameObject.SetActive(false);
        P9.gameObject.SetActive(false);
        P10.gameObject.SetActive(false);
        skipVote.gameObject.SetActive(false);
        votePanel.SetActive(false);
    }
}
