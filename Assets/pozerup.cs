using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pozerup : MonoBehaviour {


    // Use this for initialization

    private float compteur = 0;

     private void OnTriggerEnter(Collider other)
    {
        
        if(other.tag == "Player")
        {
            other.GetComponent<Player>().shield += 15;
            GetComponent<MeshCollider>().enabled = false;
            GetComponent<Renderer>().enabled = false;
            compteur = 40;

        }
    }

    private void Update()
    {
        if(compteur <= 0)
        {
            compteur = 0;
            GetComponent<MeshCollider>().enabled = true;
            GetComponent<Renderer>().enabled = true;
        }
        else
        {
            GetComponent<MeshCollider>().enabled = false;
            GetComponent<Renderer>().enabled = false;
        }
        compteur -= Time.deltaTime;
        
    }
    // Update is called once per frame

}
