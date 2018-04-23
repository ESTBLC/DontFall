using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int life = 0;
    public int shield = 0;
    
    [SerializeField] private List<GameObject> inventory = new List<GameObject>();
    [SerializeField] private List<Behaviour> activationList = new List<Behaviour>();
    private PhotonView photonView;
    private GameObject currentWeapon;

    
    void Start ()
    {
        photonView = GetComponent<PhotonView>();
        transform.name = "Player " + photonView.viewID;
        if (photonView.isMine)
        {
            int length = activationList.Count;
            for (int i = 0; i < length; i++)
            {
                activationList[i].enabled = true;
            }
        }
        //inventory.Add(GameObject.FindGameObjectsWithTag("Weapon")[0]);
        currentWeapon = inventory[0];
    }
	
	// Update is called once per frame
	void Update ()
    {

	}

    public void OnDestroy()
    {
        //GameManager.UnRegisterPlayer(GetComponent<NetworkIdentity>().netId.ToString());
    }

    public void TakeDammage(int damage)
    {
        life -= damage;
    }

    //[Client]
    public void Fire()
    {
        //RaycastHit hit;
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Physics.Raycast(ray, out hit);
        //if (hit.collider != null && hit.collider.tag == "Player")
        //{
        currentWeapon.GetComponent<Weapon>().Fire(this);
        //}
    }

    //[Command]
    public void CmdTakeDammage(string netId, int damage)
    {
        Debug.Log("Player " + netId + " has been hit");
        //GameManager.GetPlayer(netId).TakeDammage(damage);
    }
}
