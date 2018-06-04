
using UnityEngine;

public class Gun : Weapon {

    // Use this for initialization
    public int range;
    public int speed;
    [SerializeField] GameObject bullet;
    [SerializeField] ParticleSystem muzzleflash;
    
	// Update is called once per frame
	public override void Fire()
    {
        if (timer > 0)
            return;
        GameObject bulletSpawn = PhotonNetwork.Instantiate(bullet.name, bullet.transform.position, bullet.transform.rotation, 0).gameObject;
        bulletSpawn.AddComponent<Rigidbody>().AddForce(transform.parent.transform.forward * speed, ForceMode.VelocityChange);
        bulletSpawn.GetComponent<Bullet>().FireBullet(damage, range, transform.position);
        bulletSpawn.GetComponent<Weapon>().owner = owner;
        muzzleflash.Play();
        base.Fire();
    }

    public override void DesactivatePhysic()
    {
        MeshCollider[] col = GetComponentsInChildren<MeshCollider>();
        int l = col.Length;
        for (int i = 0; i < l; i++)
            col[i].enabled = false;
        base.DesactivatePhysic();
    }

    public override void ActivatePhysic()
    {
        MeshCollider[] col = GetComponentsInChildren<MeshCollider>();
        int l = col.Length;
        for (int i = 0; i < l; i++)
            col[i].enabled = true;
        base.ActivatePhysic();
    }
}
