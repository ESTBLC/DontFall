using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {

    public GameObject destination;
    void OnTriggerEnter(Collider collision)
    {
        collision.gameObject.GetComponent<Player_Move>().Telep(destination.transform.position);
    }

}
