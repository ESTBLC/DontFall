using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Player : NetworkBehaviour
{
    [SyncVar]
    public int life = 0;
    [SyncVar]
    public int shield = 0;
    private string netId;
    [SerializeField]
    private List<GameObject> inventory = new List<GameObject>();
    private GameObject currentWeapon;

    public override void OnStartClient()
    {
        base.OnStartClient();
        netId = GetComponent<NetworkIdentity>().netId.ToString();
        GameManager.RegisterPlayer(netId, this);
    }
    void Start ()
    {
        transform.name = "Player " + GetComponent<NetworkIdentity>().netId;
        if (!isLocalPlayer)
            GetComponent<DesactivateComponents>().Desactivate();
        inventory.Add(GameObject.FindGameObjectsWithTag("Weapon")[0]);
        currentWeapon = inventory[0];
    }
	
	// Update is called once per frame
	void Update ()
    {

	}

    public void OnDestroy()
    {
        GameManager.UnRegisterPlayer(GetComponent<NetworkIdentity>().netId.ToString());
    }

    public void TakeDammage(int damage)
    {
        life -= damage;
    }

    [Client]
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

    [Command]
    public void CmdTakeDammage(string netId, int damage)
    {
        Debug.Log("Player " + netId + " has been hit");
        GameManager.GetPlayer(netId).TakeDammage(damage);
    }
}
