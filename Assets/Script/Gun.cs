
using UnityEngine;

public class Gun : Weapon {

    // Use this for initialization
    public int range;
    public int speed;
    [SerializeField] GameObject bullet;
    
	// Update is called once per frame
	public override void Fire()
    {

        GameObject bulletSpawn = PhotonNetwork.Instantiate(bullet.name, bullet.transform.position, bullet.transform.rotation, 0);
        //bulletSpawn.SetActive(true);
        bulletSpawn.GetComponent<Rigidbody>().velocity = Camera.current.transform.forward*speed;
        bulletSpawn.GetComponent<Bullet>().FireBullet(damage, range, transform.position);
    }
}
