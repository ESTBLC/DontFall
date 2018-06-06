using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YouWin : MonoBehaviour {

    public GameObject win;
    private bool ok = false;
    // Use this for initialization

    private void Awake()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (PhotonNetwork.room.PlayerCount == 1 && !ok)
        {
            ok = true;
            NeedToDisplay();
        }
	}

    void NeedToDisplay()
    {
        //Cursor.visible = true;
        win.SetActive(true);
    }
}
