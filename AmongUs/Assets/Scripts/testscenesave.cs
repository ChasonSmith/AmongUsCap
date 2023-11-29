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

public class testscenesave : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("scene changed fast");
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.LoadLevel(2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
