using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class setactivetext : MonoBehaviour {

    
    public TMP_Text text;
    public Button button2;
    public int personne;
    private bool ok = false;
	// Use this for initialization
	void Start () {
        button2.onClick.AddListener(TaskOnClick);
    }
	
	// Update is called once per frame
	void Update () {
        

        if (ok && personne == 1)
        {
            text.text = "Esteban";
        }
        if (ok && personne == 2)
        {
            text.text = "Pierre";
        }
        if (ok && personne == 3)
        {
            text.text = "Xavier";
        }
        if (ok && personne == 4)
        {
            text.text = "Adrien";
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
