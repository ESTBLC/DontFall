using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shrink : MonoBehaviour {

    /*[SerializeField]
    private Vector3 futurOrigin; // le centre du prochain shrink*/
    [SerializeField]
    private float targetScale;
    [SerializeField]
    private float shrinkSpeed; // the speed of the shrink

    bool shrinking = true;
    //private List<bool> shrinking = new List<bool> {false, false, false};

	void Shrink() // the method to shrink
    {
        /*for (int i = 0; i < shrinking.Count; i++)
            shrinking[i] = true;*/
        shrinking = true;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (shrinking)
        {
            /*transform.root.localScale -= Vector3.one * Time.deltaTime * shrinkSpeed;*/
            Vector3 Scale = new Vector3(Time.deltaTime * shrinkSpeed, 0, Time.deltaTime * shrinkSpeed);
            transform.root.localScale -= Scale;
            if (transform.root.localScale.x < targetScale || transform.root.localScale.z < targetScale)
            {
                shrinking = false;
            }
        }
	}
    /*
    void shrinkaxes() // fonc to shrink each axes
    {
        float scaleaxe = transform.root.localScale[i];
        scaleaxe -= Time.deltaTime * shrinkSpeed;
        
        }
    }*/
}
