using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NetworkManager : MonoBehaviour {

    [SerializeField] private GameObject[] spawnPoints;  //Array of spawn points
    [SerializeField] private int index = 0;             //Index for find the right spawn point
    [SerializeField] private string spawnTag = "";      //Tag for find every spawn point in the scene
    [SerializeField] private GameObject spawnPlayer;    //Prefab to spawn
    public PhotonView photonView;

	// Use this for initialization
	void Start () {
        spawnPoints = GameObject.FindGameObjectsWithTag(spawnTag);              //Find spawn points and put them on the array
        SpawnPlayer();
	}
	
	// Update is called once per frame
	void Update ()
    {
        
	}

   void SpawnPlayer()
    {
        index = Random.Range(0, spawnPoints.Length);
        PhotonNetwork.Instantiate(spawnPlayer.name, spawnPoints[index].transform.position, spawnPoints[index].transform.rotation, 0); //Instanciate the player
        Camera.main.gameObject.SetActive(false);                                                                                      //Desactivate the main camera
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //Debug.Log("Scene");
        //SpawnPlayer();
        //if (PhotonNetwork.isMasterClient)
            //photonView.RPC("SetTimer", PhotonTargets.All, GetComponent<Timer>().time);
    }

    [PunRPC]
    void SetTimer(float timer)
    {
        if (!PhotonNetwork.isMasterClient)
            GetComponent<Timer>().time = timer;
    }
}
