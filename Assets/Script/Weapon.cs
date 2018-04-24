using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Weapon : MonoBehaviour {

    // Use this for initialization
    [SerializeField] private int damage;
    
    public virtual void Fire()
    {

    }

    public virtual void OnTriggerStay(Collider collision)
    {
        collision.gameObject.GetComponent<Player>().TakeDammage(damage);
    }

}
