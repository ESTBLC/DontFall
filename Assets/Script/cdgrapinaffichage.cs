using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cdgrapinaffichage : MonoBehaviour {

    public Text text;
    Grappin compteur;
    void Start()
    {
        


    }

    // Update is called once per frame
    void Update()
    {
        compteur = FindObjectOfType<Grappin>();
        if(compteur.compteurG != 0) { 
            text.text = (int ) compteur.compteurG + "";
        }
        else
        {
            text.text = "UP";
        }

    }
}
