using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationitems : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(Time.deltaTime*15,0,0));
	}
}
