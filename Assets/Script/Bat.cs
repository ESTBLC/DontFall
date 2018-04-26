using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Bat : Weapon {

    //Use this for initialization
    private bool alreadyHit = false;    //Use to not apply damage at every frame
    private Animation anim;             //Use stock the reference to the animation once for all
    private ParticleSystem spark;       //Use stock the reference to the particulesystem once for all

    public override void Start()
    {
        anim = GetComponent<Animation>();                   //Find the animation
        spark = GetComponentInChildren<ParticleSystem>();   //Find the particulesystem
    }

    public override void Fire()
    {
        anim.Play();    //Play the animation
    }

    public override void OnTriggerStay(Collider collision)
    {
        if (!alreadyHit && anim.isPlaying && collision.tag == "Player") //Check if we realy need to aplly dammage
        {
            spark.Play();                   //Launch the particulesystem
            ApplyDamage(collision.gameObject);         //Apply damage
            alreadyHit = true;              //
        }        
    }

    void OnTriggerExit(Collider other)
    {
        alreadyHit = false; //
    }
}
