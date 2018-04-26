using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject[] weaponInScene;
	// Use this for initialization
	void Start ()
    {
        weaponInScene = GameObject.FindGameObjectsWithTag("Weapon");
        List<Component> observedByPhoton = GetComponent<PhotonView>().ObservedComponents;
        for (int i = weaponInScene.Length-1; i >= 0; i--)
        {
            if (weaponInScene[i].GetComponent<Weapon>() != null)
                observedByPhoton.Add(weaponInScene[i].transform);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
