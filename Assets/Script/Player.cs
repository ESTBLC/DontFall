using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int life = 0;
    public int shield = 0;
    public Text lifeText;
    
    [SerializeField] private List<GameObject> inventory = new List<GameObject>();
    [SerializeField] private List<Object> deactivationList = new List<Object>();
    private PhotonView photonView;
    private GameObject currentWeapon;

    
    void Start ()
    {
        photonView = GetComponent<PhotonView>();
        lifeText = GameObject.Find("LifeText").GetComponent<Text>();
        this.name = "Player " + photonView.viewID;
        if (!photonView.isMine)
        {
            int length = deactivationList.Count;
            for (int i = 0; i < length; i++)
            {
                Destroy(deactivationList[i]);
            }
        }
        //inventory.Add(GameObject.FindGameObjectsWithTag("Weapon")[0]);
        currentWeapon = inventory[0];
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (photonView.isMine)
            lifeText.text = life.ToString();
	}

    public void Fire()
    {
        currentWeapon.GetComponent<Weapon>().Fire();
    }

    [PunRPC]
    public void TakeDamage(int damage)
    {
        Debug.Log(this.gameObject.name + " est touche");
        life -= damage;
        if (life <= 0 && photonView.isMine)
            PhotonNetwork.Destroy(gameObject);
    }
}
