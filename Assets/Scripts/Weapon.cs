using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Weapon : MonoBehaviour {

    // Use this for initialization
    [SerializeField]
    public int damage;
    private Player father;
    
    public virtual void Fire(Player father)
    {
        this.father = father;
    }

    public virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
            father.CmdTakeDammage(collision.collider.GetComponent<NetworkIdentity>().netId.ToString(), damage);
    }

}
