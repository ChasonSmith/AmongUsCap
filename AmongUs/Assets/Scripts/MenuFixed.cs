using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuFixed : MonoBehaviourPunCallbacks
{
    
    public TMP_Text CreateRoomName;
    public TMP_Text JoinRoomName;


    public void JoinOrCreate_Create() //Paired to the Quick Start button
    {
        RoomOptions options = new RoomOptions();
        options.MaxPlayers = 10;
        if(CreateRoomName.text != ""){
            PhotonNetwork.JoinOrCreateRoom(CreateRoomName.text, options, TypedLobby.Default);
        }
    }

    public void JoinOrCreate_Join() //Paired to the Quick Start button
    {
        RoomOptions options = new RoomOptions();
        options.MaxPlayers = 10;
        if(JoinRoomName.text != ""){
            PhotonNetwork.JoinOrCreateRoom(JoinRoomName.text, options, TypedLobby.Default);
        }
    }

    public override void OnJoinRandomFailed(short returnCode, string message) //Callback function for if we fail to join a rooom
    {
        Debug.Log("Failed to join a room");
    }


    public override void OnCreateRoomFailed(short returnCode, string message) //callback function for if we fail to create a room. Most likely fail because room name was taken.
    {
        Debug.Log("Failed to create room... trying again");
    }

}
