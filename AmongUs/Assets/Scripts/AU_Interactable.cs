using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AU_Interactable : MonoBehaviour
{
    [SerializeField] GameObject miniGame;
    GameObject highlight;

    public Button A1;
    public Button A2;
    public Button A3;
    public Button A4;

    private void OnEnable()
    {
        highlight = transform.GetChild(0).gameObject;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            highlight.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            highlight.SetActive(false);
        }
    }
    public void PlayMiniGame()
    {
        // We will disable the buttons and revert any previous colors of them back
        A1.enabled = false; 
        A2.enabled = false; 
        A3.enabled = false; 
        A4.enabled = false;
        A1.GetComponent<Image>().color = Color.gray;
        A2.GetComponent<Image>().color = Color.gray;
        A3.GetComponent<Image>().color = Color.gray;
        A4.GetComponent<Image>().color = Color.gray;
        miniGame.SetActive(true);
        Invoke("EnableButtons", 3);
    }

    public void EnableButtons()
    {
        A1.GetComponent<Image>().color = Color.white;
        A2.GetComponent<Image>().color = Color.white;
        A3.GetComponent<Image>().color = Color.white;
        A4.GetComponent<Image>().color = Color.white;
        A1.enabled = true;
        A2.enabled = true;
        A3.enabled = true;
        A4.enabled = true;

    }
}
