using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cdrollback : MonoBehaviour {

    public Text text;
    private float compteur = 0;
    KeyCode Key = KeyCode.T;

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(Key) && compteur <= 0)
        {
            compteur = 40;   
        }
        if(compteur > 0)
        {
            compteur -= Time.deltaTime;
            text.text = (int)compteur + "";
        }
        else
        {
            text.text = "UP";
        }

    }
}
