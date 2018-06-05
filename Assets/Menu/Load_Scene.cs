using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load_Scene : MonoBehaviour {

	public void LoadScene(int lvl)
	{
<<<<<<< HEAD
        if(lvl == 2 || lvl == 3)
=======
        if (lvl == 0 || lvl == 1)
            Cursor.visible = true;
        else
>>>>>>> Pierre
            Cursor.visible = false;

		SceneManager.LoadScene(lvl);
	}

}
