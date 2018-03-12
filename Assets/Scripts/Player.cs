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
    [SerializeField]
    private int dammage = 0;
    private string netId;

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
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!isLocalPlayer)
            return;
        if (Input.GetButton("Fire1"))
            Fire(dammage);
	}

    public void OnDestroy()
    {
        GameManager.UnRegisterPlayer(GetComponent<NetworkIdentity>().netId.ToString());
    }

    public void TakeDammage(int dammage)
    {
        life -= dammage;
    }

    [Client]
    void Fire(int dammage)
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hit);
        if (hit.collider != null && hit.collider.tag == "Player")
        {
            CmdTakeDammage(hit.collider.GetComponent<NetworkIdentity>().netId.ToString(), dammage);
        }
    }

    [Command]
    public void CmdTakeDammage(string netId, int dammage)
    {
        Debug.Log("Player " + netId + " has been hit");
        GameManager.GetPlayer(netId).TakeDammage(dammage);
        return;
    }
}
