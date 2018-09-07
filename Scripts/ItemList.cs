// NULLcode Studio © 2016
// null-code.ru

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Linq;

public class ItemList : Photon.MonoBehaviour {

    public GameObject content;
    public GameObject Tamplate;
    public InputField input;

    public List<GameObject> button = new List<GameObject>();

    private int Players = 0;
    private static bool isLoad = false;
    private static bool isInst = false;
    private RoomInfo[] Room;

     void Start()
    {
       SceneManager.sceneLoaded += OnSceneFinishedLoading;
       PhotonNetwork.isMessageQueueRunning = true;
        PhotonNetwork.automaticallySyncScene = true;
        PhotonNetwork.ConnectUsingSettings(Informations.GameVersions);
    }

    public void updata()
    {
          delete();
          Room = PhotonNetwork.GetRoomList();

          foreach (RoomInfo r in Room)
          {
              GameObject Copy = Instantiate(Tamplate);
              Copy.transform.Find("Text").GetComponent<Text>().text = r.Name;
              Copy.transform.parent = content.transform;
              button.Add(Copy);
            Button b = Copy.GetComponent<Button>();
            b.onClick.AddListener(delegate() { PhotonNetwork.JoinRoom(Copy.transform.Find("Text").GetComponent<Text>().text); });
          }

    }

    public void delete()
    {
        foreach (GameObject b in button)
        {
            Destroy(b);
        }

        button.Clear();
    }

    public void Add()
    {
        GameObject Copy = Instantiate(Tamplate);
        Copy.transform.Find("Text").GetComponent<Text>().text = input.text;
        Copy.transform.parent = content.transform;
        button.Add(Copy);
      
        PhotonNetwork.JoinOrCreateRoom(input.text,new RoomOptions(),TypedLobby.Default);

    }

    public void OnJoinedRoom()
    {
        if (!isLoad) {
            PhotonNetwork.LoadLevel(6);
            isLoad = true;
        }
    }

    void OnSceneFinishedLoading(Scene scene , LoadSceneMode mode)
    {
        if (!isInst)
        {
            Informations.isNet = true;
            GameObject game = PhotonNetwork.Instantiate("MyCar", new Vector3(-50, -5, -4.85f), Quaternion.identity, 0);
            //  if (photonView.isMine)
            //        game.GetComponent<MoveKeyboardPlayer>().CarType = Informations.CarId;
            isInst = true;

        }   
    }

}
