using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lettrepressed : MonoBehaviour {

    public Button button2;
    public int bouton;
    private bool ok = false;
    public Text text;
    
    // Use this for initialization
    void Start()
    {
        button2.onClick.AddListener(TaskOnClick);
    }
    // Use this for initialization
  
	// Update is called once per frame
	void Update () {
        if (ok && bouton == 1)
        {
            text.text = " W : Walk forward";
        }
        if (ok && bouton == 2)
        {
            text.text = " A : Move to left";
        }
        if (ok && bouton == 3)
        {
            text.text = " S : Walk backward";
        }
        if (ok && bouton == 4)
        {
            text.text = " D : Move to right";
        }





        if (!ok)
        {
            text.text = "";
        }
    }

    void TaskOnClick()
    {
        Debug.Log("clicked");
        ok = !ok;
    }
}
