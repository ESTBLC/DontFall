using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Bat : Weapon {

    //Use this for initialization
    private bool alreadyHit = false;
    [SerializeField]
    private GameObject flare;

    public override void Fire(Player father)
    {
        GetComponent<Animation>().Play();
        base.Fire(father);
    }

    public void OnCollisionEnter(Collision collision)
    {
        /*RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit))
        {
            Debug.Log(hit.transform.name);
        }
        // flare.GetComponent<ParticleSystem>().Play();
        
        Instantiate(flare, hit.point, Quaternion.LookRotation(transform.forward, transform.up));*/
        Debug.Log("coucou");
        ContactPoint contact = collision.contacts[0];
        ContactPoint contact1 = collision.contacts[1];
        Instantiate(flare, contact.point, Quaternion.FromToRotation(Vector3.up, contact.normal));
        Instantiate(flare, contact1.point, Quaternion.FromToRotation(Vector3.up, contact.normal));


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
