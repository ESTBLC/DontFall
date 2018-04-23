using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NetworkManager : MonoBehaviour {

    public Text debugNetwork;
    [SerializeField] private GameObject[] spawnPoints;
    [SerializeField] private string spawnTag = "";
    [SerializeField] private GameObject spawnPlayer;
    private GameObject player;
    private int index = 0;
	// Use this for initialization
	void Start () {
        PhotonNetwork.logLevel = PhotonLogLevel.Full;
        PhotonNetwork.ConnectUsingSettings("0.1");
        Debug.Log("Network Start");
        spawnPoints = GameObject.FindGameObjectsWithTag(spawnTag);
	}
	
	// Update is called once per frame
	void Update () {
        debugNetwork.text = PhotonNetwork.connectionStateDetailed.ToString();
	}

    #region Photon.PunBehaviour CallBacks
    void OnJoinedLobby()
    {
        RoomOptions room = new RoomOptions() { IsVisible = true, MaxPlayers = 10 };
        PhotonNetwork.JoinOrCreateRoom("Dev", room, TypedLobby.Default);
        Debug.Log("Lobby");
    }

    void OnJoinedRoom()
    {
        Debug.Log("Room");
        SpawnPlayer();
    }
    #endregion

    void SpawnPlayer()
    {
        Debug.Log("Spawn");
        player = PhotonNetwork.Instantiate(spawnPlayer.name, spawnPoints[index].transform.position, spawnPoints[index].transform.rotation, 0);
        player = PhotonNetwork.Instantiate(spawnPlayer.name, spawnPoints[index].transform.position, spawnPoints[index].transform.rotation, 0);
        Debug.Log("Spawned");
        index = (index + 1)%spawnPoints.Length;
    }
}
