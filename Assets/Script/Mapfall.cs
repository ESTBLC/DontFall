using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mapfall : MonoBehaviour {
    
    public GameObject coucou;
    public int dead;
    compteurgame compteur;
    void Start()
    {
        compteur = FindObjectOfType<compteurgame>();


    }

    // Update is called once per frame
    void Update()
    {
       
        Debug.Log(compteur.compteur);
        if (compteur.compteur >= dead)
        {
            coucou.AddComponent<Rigidbody>();

        }
        if(compteur.compteur >= dead+20)
        {
			GameObject.Destroy (coucou);
        }
    }

}

