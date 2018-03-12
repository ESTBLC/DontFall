using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Weapon : NetworkBehaviour {

    // Use this for initialization
    [SerializeField]
    public int damage;
    private Player father;
    
    public virtual void Fire(Player father)
    {
        this.father = father;
    }

    public virtual void OnTriggerEnter(Collider collision)
    {
        father.CmdTakeDammage(collision.GetComponent<NetworkIdentity>().netId.ToString(), damage);
    }

}
