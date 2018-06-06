using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YouWin : MonoBehaviour {

    public GameObject win;
    public Pausemenu pause;
    private bool ok = false;
    // Use this for initialization

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (PhotonNetwork.room.PlayerCount == 1)
        {
            pause.enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            ok = true;
            win.SetActive(true);
        }
	}

    void NeedToDisplay()
    {
        
    }
}
