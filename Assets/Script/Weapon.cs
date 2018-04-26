using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Weapon : MonoBehaviour
{

    // Use this for initialization
    [SerializeField] private int damage; //Store damage of the weapon

    public virtual void Start()
    {

    }

    public virtual void Fire()
    {

    }

    public virtual void OnTriggerStay(Collider collision)
    {
        collision.gameObject.GetComponent<PhotonView>().RPC("TakeDamage", PhotonTargets.All, damage);   //Apply damage
    }

}
