using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int life = 0;    //Life var
    public int shield = 0;  //Shield var
    public Text lifeText;   //Text to display life
    
    [SerializeField] private List<GameObject> inventory = new List<GameObject>();   //List of item the player posses
    [SerializeField] private List<Object> deactivationList = new List<Object>();    //List of component to desactivate if the player is not the local player
    private PhotonView photonView;      //Reference to the phontonview component
    private Weapon currentWeapon;       //Reference to the current weapon

    
    void Start ()
    {
        photonView = GetComponent<PhotonView>();                        //Setup the reference to the photonview
        lifeText = GameObject.Find("LifeText").GetComponent<Text>();    //Find the GUI Text to write life to it
        this.name = "Player " + photonView.viewID;      //Rename the player
        if (!photonView.isMine) //If the player is not the local player launch the desactivation of different component
        {
            int length = deactivationList.Count;
            for (int i = 0; i < length; i++)
            {
                Destroy(deactivationList[i]);
            }
        }
        //inventory.Add(GameObject.FindGameObjectsWithTag("Weapon")[0]);
        currentWeapon = inventory[0].GetComponent<Weapon>();   //Set the weapon to the first one (the bat)
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (photonView.isMine)                  //Update the GUI life is the player is the local player
            lifeText.text = life.ToString();    //Write life to it
	}

    public void Fire()
    {
        currentWeapon.Fire();   //Launch fire of the weapon
    }

    [PunRPC]
    public void TakeDamage(int damage)  //Apply damge to all reference of the player accros the network
    {
        Debug.Log(this.gameObject.name + " est touche");
        life -= damage; //Substract life
        if (life <= 0 && photonView.isMine) //Destroy if the player is the local player
            PhotonNetwork.Destroy(gameObject);  //Destroy the player across the network
    }
}
