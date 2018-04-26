using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Weapon {

    private Vector3 origin;
    private int maxDist;
    // Use this for initialization
    public void FireBullet(int damage, int maxDist, Vector3 origin)
    {
        this.damage = damage;
        this.maxDist = maxDist;
        this.origin = origin;
    }

    private void Update()
    {
        if (Vector3.Distance(origin, transform.position) > maxDist)
            PhotonNetwork.Destroy(gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
            ApplyDamage(collision.gameObject);
    }
}
