using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Bat : Weapon {

    // Use this for initialization
    public override void Fire(Player father)
    {
        GetComponent<Animation>().Play();
        base.Fire(father);
    }

    public override void OnTriggerEnter(Collider collision)
    {
        if (GetComponent<Animation>().isPlaying && collision.tag == "Player")
        {
            base.OnTriggerEnter(collision);
        }        
    }
}
