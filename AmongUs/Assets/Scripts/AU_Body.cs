using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.InputSystem;
public class AU_Body : MonoBehaviour
{
    [SerializeField] public SpriteRenderer bodySprite;
    [SerializeField] public SpriteRenderer partSprite;
    public SphereCollider sphereCollider;
    public void SetColor(Color newColor)
    {
        bodySprite.color = newColor;
    }
    private void OnEnable()
    {
        if(AU_PlayerController.allBodies != null)
        {
            AU_PlayerController.allBodies.Add(transform);
        }
        if(AU_PlayerController.allBod != null)
        {
            AU_PlayerController.allBod.Add(this);
        }
    }

    public void Report()
    {
        Debug.Log("Reported");
        
    }
}