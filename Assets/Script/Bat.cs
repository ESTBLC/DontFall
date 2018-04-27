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
        base.Start();
    }

    public override void Fire()
    {
        anim.Play();    //Play the animation
    }

    void OnCollisionStay(Collision collisionInfo)
    {
        GameObject obj = collisionInfo.collider.gameObject;
        if (!alreadyHit && anim.isPlaying && obj.tag == "Player") //Check if we realy need to aplly dammage
        {
            spark.Play();                   //Launch the particulesystem
            ApplyDamage(obj);               //Apply damage
            alreadyHit = true;              //
        }        
    }

    void OnCollisionExit(Collision collisionInfo)
    {
        alreadyHit = false; //
    }
}
