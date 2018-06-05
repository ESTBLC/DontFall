using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class compteurgame : MonoBehaviour {

    public float compteur = 0;
    
    public Text text;
	
	// Update is called once per frame
	void Update ()
    {
        compteur += Time.deltaTime;
        text.text =  (int) compteur / 60+ " : " + (int) compteur % 60;
        
	}


}
