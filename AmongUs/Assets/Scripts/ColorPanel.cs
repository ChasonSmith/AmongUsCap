using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPanel : MonoBehaviour
{
    [SerializeField] GameObject colorPanel;
    public void CloseColor()
    {
        colorPanel.SetActive(false);
    }
}
