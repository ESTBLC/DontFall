using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausemenu_Solo : MonoBehaviour {

    public GameObject menuobject;
    bool isactive = false;
    

    private void Update()
    {
        if (isactive)
        {
            menuobject.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            Time.timeScale = 0;
        }
        else
        {
            menuobject.SetActive(false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
            inactivecam();


    }

    public void inactivecam()
    {
        isactive = !isactive;
    }
}
