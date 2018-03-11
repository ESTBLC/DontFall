using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int life = 0;
    [SerializeField]
    private int shield = 0;
    [SerializeField]
    private int dammage = 0;
    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButton("Fire1"))
            Fire(dammage);
	}

    void Fire(int dammage)
    {
        Debug.Log("TARATATA");
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hit);
        if (hit.collider != null && hit.collider.tag == "Player")
        {
            Debug.Log("PANPAN");
            hit.collider.GetComponent<Player>().TakeDammage(dammage);
        }
    }

    public void TakeDammage(int dammage)
    {
        life -= dammage;
        if (life <= 0)
            Destroy(gameObject);
    }
}
