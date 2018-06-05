using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cdgrapinafichage : MonoBehaviour {

    public Text text;
    Grappin compteur;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        compteur = FindObjectOfType<Grappin>();
        if(compteur.compteur != 0)
        {
            text.text = (int)compteur.compteur + "";
        }
        else
        {
            text.text = "UP";
        }
	}
}
