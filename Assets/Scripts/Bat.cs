using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Bat : Weapon {

    // Use this for initialization
    private bool alreadyHit = false;
    public override void Fire(Player father)
    {
        GetComponent<Animation>().Play();
        base.Fire(father);
    }

    public override void OnTriggerStay(Collider collision)
    {
        if (!alreadyHit && GetComponent<Animation>().isPlaying && collision.tag == "Player")
        {
            base.OnTriggerStay(collision);
            alreadyHit = true;
        }        
    }

    public void OnTriggerExit(Collider other)
    {
        alreadyHit = false;
    }
}
