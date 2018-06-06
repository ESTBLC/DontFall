﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load_Scene : MonoBehaviour {

	public void LoadScene(int lvl)
	{
        if (lvl == 1 || lvl == 2)
        {
            Cursor.visible = true;
            PhotonNetwork.Disconnect();
        }
        else
            Cursor.visible = false;

		SceneManager.LoadScene(lvl);
	}

}
