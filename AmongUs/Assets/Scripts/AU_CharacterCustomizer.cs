using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
public class AU_CharacterCustomizer : MonoBehaviour
{
    [SerializeField] Color[] allColors;
    [SerializeField] Sprite[] allHats;
    [SerializeField] GameObject colorPanel;
    [SerializeField] GameObject hatPanel;
    [SerializeField] Button colorTabButton;
    [SerializeField] Button hatTabButton;

    [SerializeField] GameObject customePanel;

    [SerializeField] InputAction customOpen;

    public TMP_Text pName;

    private void OnEnable()
    {
        customOpen.Enable();
    }
    private void OnDisable()
    {
        customOpen.Disable();
    }

    void Update()
    {
        if(customOpen.triggered)
        {
            customePanel.SetActive(true);
        }
    }

    public void SetColor(int colorIndex)
    {
        //Debug.Log(allColors[colorIndex]);
        AU_PlayerController.localPlayer.SetColor(allColors[colorIndex]);
    }
    public void SetHat(int hatIndex)
    {
        AU_PlayerController.localPlayer.SetHat(allHats[hatIndex]);
    }
    public void NextScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
    public void EnableColors()
    {
        colorPanel.SetActive(true);
        hatPanel.SetActive(false);
        colorTabButton.interactable = false;
        hatTabButton.interactable = true;
    }
    public void EnableHats()
    {
        colorPanel.SetActive(false);
        hatPanel.SetActive(true);
        colorTabButton.interactable = true;
        hatTabButton.interactable = false;
    }

    public void setUName()
    {
        AU_PlayerController.localPlayer.SetUsName(pName);
    }
}
