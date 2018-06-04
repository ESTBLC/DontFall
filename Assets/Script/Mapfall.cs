using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mapfall : MonoBehaviour {

    public float compteur;
    public GameObject coucou;

    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        
        compteur -= Time.deltaTime;
        if (compteur <= 0)
        {
            coucou.AddComponent<Rigidbody>();

        }
        if(compteur <= -20)
        {
			GameObject.Destroy (coucou);
        }
    }

}

