using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AU_Interactable : MonoBehaviour
{
    [SerializeField] GameObject miniGame;
    GameObject highlight;
    private void OnEnable()
    {
        highlight = transform.GetChild(0).gameObject;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            //Debug.Log("this");
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
<<<<<<< Updated upstream
=======
        //Debug.Log("PMG");
        // We will disable the buttons and revert any previous colors of them back
        // A1.enabled = false; 
        // A2.enabled = false; 
        // A3.enabled = false; 
        // A4.enabled = false;
        // A1.GetComponent<Image>().color = Color.gray;
        // A2.GetComponent<Image>().color = Color.gray;
        // A3.GetComponent<Image>().color = Color.gray;
        // A4.GetComponent<Image>().color = Color.gray;
>>>>>>> Stashed changes
        miniGame.SetActive(true);
    }
}
