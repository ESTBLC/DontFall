using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load_Scene : MonoBehaviour {

	public void LoadScene(int lvl)
	{
        if(lvl == 2 || lvl == 3)
            Cursor.visible = false;

		SceneManager.LoadScene(lvl);
	}

}
