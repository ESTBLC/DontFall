using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Weapon : MonoBehaviour
{

    // Use this for initialization
    public int damage; //Store damage of the weapon
    public float coolDown;
    public float timer;
    public Vector3 origin;
 
    private Rigidbody rigid;

    public virtual void Start()
    {
        //GameObject.Find("Game Manager").GetComponent<PhotonView>().ObservedComponents.Add(gameObject.transform);
        rigid = GetComponent<Rigidbody>();
    }

    public virtual void Update()
    {
        timer -= Time.deltaTime;
    }

    public virtual void Fire()
    {
        timer = coolDown;
    }

    public virtual void DesactivatePhysic()
    {
        Destroy(rigid);
    }

    public virtual void ActivatePhysic()
    {
        rigid = gameObject.AddComponent<Rigidbody>();
    }

    public virtual void ApplyDamage(GameObject gameObject, Vector3 point)
    {
        gameObject.GetComponent<PhotonView>().RPC("TakeDamage", PhotonTargets.All, damage, point);   //Apply damage
    }
}
