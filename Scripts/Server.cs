using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Server : Photon.MonoBehaviour {
    public RoomInfo[] Room;

    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings("0.1");
        Room = PhotonNetwork.GetRoomList();
    }

    void OnJoinedLobby()
    {

    }

}
