
using UnityEngine;

public class Gun : Weapon {

    // Use this for initialization
    public int range;
    public int speed;
    [SerializeField] GameObject bullet;
    
	// Update is called once per frame
	public override void Fire()
    {
        GameObject bulletSpawn = Object.Instantiate(bullet, bullet.transform.position, bullet.transform.rotation, transform);
        bulletSpawn.SetActive(true);
        bulletSpawn.GetComponent<Rigidbody>().velocity = new Vector3(0, speed, 0);
        bulletSpawn.GetComponent<Bullet>().FireBullet(damage, range, transform.position);
    }
}
