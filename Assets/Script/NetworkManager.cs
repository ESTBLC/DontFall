using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NetworkManager : MonoBehaviour {

    public Text debugNetwork;                           //GUI to debug server state
    [SerializeField] private GameObject[] spawnPoints;  //Array of spawn points
    [SerializeField] private int index = 0;             //Index for find the right spawn point
    [SerializeField] private string spawnTag = "";      //Tag for find every spawn point in the scene
    [SerializeField] private GameObject spawnPlayer;    //Prefab to spawn

	// Use this for initialization
	void Start () {
        PhotonNetwork.logLevel = PhotonLogLevel.Full;                           //Set debug level of Photon
        PhotonNetwork.ConnectUsingSettings("0.1");                              //Connect to server
        spawnPoints = GameObject.FindGameObjectsWithTag(spawnTag);              //Find spawn points and put them on the array
        debugNetwork = GameObject.Find("NetworkText").GetComponent<Text>();     //Find the GUI text for debug network
	}
	
	// Update is called once per frame
	void Update ()
    {
        debugNetwork.text = PhotonNetwork.connectionStateDetailed.ToString();   //Update GUI network state
	}

    void OnJoinedLobby()
    {
        RoomOptions room = new RoomOptions() { IsVisible = true, MaxPlayers = 10 }; //Create new room if the there is not an open room
        PhotonNetwork.JoinOrCreateRoom("Dev", room, TypedLobby.Default);            //Connect to the room
    }

    void OnJoinedRoom()
    {
        index = (PhotonNetwork.room.PlayerCount - 1)  % spawnPoints.Length; //Find the right postiton to spawn at
        SpawnPlayer();                                                      //Call spawning function
    }

    void SpawnPlayer()
    {
        PhotonNetwork.Instantiate(spawnPlayer.name, spawnPoints[index].transform.position, spawnPoints[index].transform.rotation, 0); //Instanciate the player
        Camera.main.gameObject.SetActive(false);                                                                                      //Desactivate the main camera
    }
}
