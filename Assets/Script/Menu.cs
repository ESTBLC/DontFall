using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Menu : Photon.PunBehaviour {

    [Header("Text and Input")]
    public TMP_InputField RoomName;
    public TMP_Text MaxPlayers;
    public TMP_Text LobbyRoomName;
    public TMP_Text LobbyNbPlayer;

    [Header("Panels")]
    public GameObject SettingsPannel;
    public GameObject RoomPannel;
    public GameObject JoinRoomPannel;
    public GameObject SeparationPannel;

    [Header("Prefabs and local objects")]
    public GameObject RoomObject;
    public GameObject RoomList;

    [Header("Settings")]
    public byte AbsoluteMaxPlayer;

    private byte nbPlayer = 2;

    #region Initial & Update
    private void Awake()
    {
        PhotonNetwork.offlineMode = false;
        PhotonNetwork.autoJoinLobby = true;
        PhotonNetwork.autoCleanUpPlayerObjects = true;
        PhotonNetwork.automaticallySyncScene = true;

        PhotonNetwork.ConnectUsingSettings("1.0");
    }

    void Start ()
    {
        if (PhotonNetwork.inRoom)
            LeaveRoom();
    }
	
	// Update is called once per frame
	void Update ()
    {
        LobbyRoomName.text = "Room Name: " + PhotonNetwork.room.Name;
        LobbyNbPlayer.text = PhotonNetwork.room.PlayerCount.ToString() + " of " + PhotonNetwork.room.MaxPlayers + " players";
    }
    #endregion

    #region UI
    public void ChangeMaxPlayer(int i)
    {
        i = nbPlayer + i;
        if (i >= 2 && i <= AbsoluteMaxPlayer)
        {
            MaxPlayers.text = i.ToString();
            nbPlayer = (byte)i;
        }
    }

    public void CreateRoom()
    {
        RoomOptions room = new RoomOptions() { IsOpen = true, IsVisible = true, MaxPlayers = nbPlayer};
        bool succes = PhotonNetwork.CreateRoom(RoomName.text, room, TypedLobby.Default);
        if (succes)
            Debug.Log("Room: " + RoomName.text + " created");
        else
            Debug.LogError("Failed to create " + RoomName.text);

        GameObject roomObj = Instantiate(RoomObject);
        roomObj.transform.SetParent(RoomList.transform, false);
        ButtonJoinRoom roomScript = roomObj.GetComponent<ButtonJoinRoom>();
        roomScript.RoomName.text = RoomName.text + "                " + "0" + " / " + MaxPlayers.text;
    }

    public void StartGame(int lvl)
    {
        if (PhotonNetwork.isMasterClient)
            PhotonNetwork.LoadLevel(lvl);
    }
    #endregion

    #region Photon
    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        JoinRoomPannel.SetActive(false);
        RoomPannel.SetActive(true);
        SettingsPannel.SetActive(true);
        SeparationPannel.SetActive(true);
    }

    public void JoinRoom(string room)
    {
        PhotonNetwork.JoinRoom(room);
        JoinRoomPannel.SetActive(true);
        RoomPannel.SetActive(false);
        SettingsPannel.SetActive(false);
        SeparationPannel.SetActive(false);
    }

    public override void OnConnectedToMaster()
    {
        //PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        Debug.Log(PhotonNetwork.GetRoomList().Length);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Join room: " + PhotonNetwork.room.Name);
    }

    public override void OnReceivedRoomListUpdate()
    {
        RoomInfo[] roomActives = PhotonNetwork.GetRoomList();
        Debug.Log("Rooms Update " + roomActives.Length);
        ButtonJoinRoom[] roomsToDel = GetComponentsInChildren<ButtonJoinRoom>();
        foreach (ButtonJoinRoom roomDel in roomsToDel)
        {
            GameObject.Destroy(roomDel.gameObject);
        }

                foreach (RoomInfo roomAd in roomActives)
        {
            GameObject room = Instantiate(RoomObject);
            room.transform.SetParent(RoomList.transform, false);
            ButtonJoinRoom roomScript = room.GetComponent<ButtonJoinRoom>();
            roomScript.RoomName.text = roomAd.Name + "          " + roomAd.PlayerCount.ToString() + " / " + roomAd.MaxPlayers.ToString();
        }
    }
    #endregion
}
