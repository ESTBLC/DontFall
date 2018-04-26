using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Weapon : MonoBehaviour
{

    // Use this for initialization
    public int damage; //Store damage of the weapon
    public Vector3 origin;

    public virtual void Start()
    {

    }

    public virtual void Fire()
    {

    }

    public virtual void OnTriggerStay(Collider collision)
    {
        
    }

    public virtual void ApplyDamage(GameObject gameObject)
    {
        gameObject.GetComponent<PhotonView>().RPC("TakeDamage", PhotonTargets.All, damage);   //Apply damage
    }

}
