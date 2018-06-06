using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapm : MonoBehaviour {

    public GameObject menuobject;
    bool isactive = false;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.M))
            {
            inactivecam();
        
        }
        if (isactive)
        {
            menuobject.SetActive(true);
        }
        else
        {
            menuobject.SetActive(false);
        }
	}
    public void inactivecam()
    {
        isactive = !isactive;
    }
}
