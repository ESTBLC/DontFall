using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausemenu : MonoBehaviour {

    public GameObject menuobject;
    bool isactive = false;
    

    private void Update()
    {
        if (isactive)
        {
            menuobject.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            
        }
        else
        {
            menuobject.SetActive(false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
            inactivecam();


    }

    public void inactivecam()
    {
        isactive = !isactive;
    }
}
