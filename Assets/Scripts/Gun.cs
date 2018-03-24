
using UnityEngine;

public class Gun : MonoBehaviour {

    // Use this for initialization
    public float damage = 10f;
    public float range = 100f;

    public ParticleSystem Shoot_particule;
    public Camera cam;
    
	// Update is called once per frame
	void Update ()
    {
		if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
	}

    void Shoot()
    {
        Shoot_particule.Play();
        RaycastHit hit;        
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            // Ca fait rien pour l'instant

            Debug.Log(hit.transform.position);
        }
    }
}
