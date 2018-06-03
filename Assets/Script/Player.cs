using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float shield = 0;      //Shield var

    public int dropForce;   //DropForce var
    public Text shieldText;   //Text to display life
    public PhotonView photonView;      //Reference to the phontonview component
    public int id;
    public List<GameObject> inventory = new List<GameObject>();   //List of item the player posses
    public List<Object> deactivationList = new List<Object>();    //List of component to desactivate if the player is not the local player
    public Vector3 impactForce;

    [SerializeField] private float decreaseForce;
    private GameObject camFPS;
    private GameObject camTPS;
    public GameObject cam;
    private Weapon currentWeapon;       //Reference to the current weapon
    private Animator anim;
    private int indexInventory = 0;
    private bool canShoot = true;

    void Start ()
    {
        camFPS = transform.Find("CameraFPS").gameObject;
        camTPS = transform.Find("CameraTPS").gameObject;
        cam = camFPS;
        photonView = GetComponent<PhotonView>();                        //Setup the reference to the photonview
        id = photonView.viewID;
        anim = GetComponent<Animator>();
        shieldText = GameObject.Find("ShieldText").GetComponent<Text>();    //Find the GUI Text to write life to it
        this.name = "Player " + photonView.viewID;      //Rename the player
        if (!photonView.isMine) //If the player is not the local player launch the desactivation of different component
        {
            int length = deactivationList.Count;
            for (int i = 0; i < length; i++)
            {
                Destroy(deactivationList[i]);
            }
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }
        inventory.Add(GetComponentInChildren<Weapon>().gameObject);
        currentWeapon = inventory[indexInventory].GetComponent<Weapon>();   //Set the weapon to the first one (the bat)

        shield = 0;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!photonView.isMine)                  //Update the GUI life is the player is the local player
            return;
        if (shield < 0)
            shield = 0;
        shieldText.text = "Shield: " + shield.ToString() + "%";    //Write life to it
        impactForce *= decreaseForce;
        if (Mathf.Abs(impactForce.x + impactForce.y + impactForce.z) < 1)
            impactForce = Vector3.zero;
	}

    public void Fire()
    {
        currentWeapon.Fire();           //Launch fire of the weapon
    }

    public void SwitchCam()
    {
        camFPS.SetActive(false);
        camTPS.SetActive(true);
    }

    [PunRPC]
    public void ChangeAnimation(string name)
    {
        switch (name)
        {
            case "Forward":
                anim.SetBool("Forward", true);
                anim.SetBool("Idle", false);
                break;
            case "Backward":
                anim.SetBool("Backward", true);
                anim.SetBool("Idle", false);
                break;
            case "Idle":
                anim.SetBool("Idle", true);
                anim.SetBool("Forward", false);
                anim.SetBool("Backward", false);
                break;
        }
    }
    
    [PunRPC]
    public void ChangeWeapon(int index) //CHange active weapon of the inventory
    {
        indexInventory = (indexInventory + index + inventory.Count) % inventory.Count;  //Change the index for the futur activation
        currentWeapon.gameObject.SetActive(false);                                      //Desactivate old weapon
        currentWeapon = inventory[indexInventory].GetComponent<Weapon>();               //Change current weapon
        currentWeapon.gameObject.SetActive(true);                                       //Activate new weapon
    }

    [PunRPC]
    private void PickUPWeapon(int id)   //Collect and equip a weapon
    {
        GameObject weapon = PhotonView.Find(id).gameObject;                     //Find the weapon to collect
        weapon.transform.SetParent(cam.transform);                              //Set it as a child of the cam
        weapon.GetComponent<Weapon>().DesactivatePhysic();                      //Desactivate physic effect on it
        weapon.GetComponent<Weapon>().owner = photonView.ownerId;
        weapon.transform.localPosition = weapon.GetComponent<Weapon>().origin;  //Place the weapon on the right localpoint 
        weapon.transform.localRotation = Quaternion.Euler(weapon.GetComponent<Weapon>().rotation);  //Set rotation
        inventory.Add(weapon);                                                  //Add the weapon to the inventory
        indexInventory = inventory.Count - 1;                                   //Set the index to the end of the inventory list
        currentWeapon.gameObject.SetActive(false);                              //Desactivate old weapon
        currentWeapon = weapon.GetComponent<Weapon>();                          //Change the currentWeapon to the new one
    }

    [PunRPC]
    public void DropWeapon()    //Drop the weapon on the scene
    {
        if (indexInventory != 0)    //Block bat drop
        {
            inventory.RemoveAt(indexInventory);                                                                 //Remove it of the inventory
            currentWeapon.transform.SetParent(null);                                                            //Set it with no parent
            currentWeapon.ActivatePhysic();                                                                     //Activate physic effect on it
            currentWeapon.gameObject.GetComponent<Rigidbody>().velocity = cam.transform.forward * dropForce;    //Apply a drop force
            currentWeapon.gameObject.GetComponent<PhotonView>().TransferOwnership(0);                           //Loose the ownership
            currentWeapon = inventory[inventory.Count - 1].GetComponent<Weapon>();                              //Take an other weapon
        }
    }

    [PunRPC]
    public void TakeDamage(int damage, Vector3 point)  //Apply damge to all reference of the player accros the network
    {
        Debug.Log(this.gameObject.name + " est touche");
        if (photonView.isMine)
        {
            impactForce = (transform.position - point) * damage;
            impactForce.y = 0;
        }
    }

    [PunRPC]
    public void HasHit(int owner)  //Apply damge to all reference of the player accros the network
    {
        Debug.Log("Hit");
        if (photonView.ownerId == owner)
        {
            shield += 5;
        }
    }
}
