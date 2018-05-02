using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour {

    public float rotationSpeed;
    [SerializeField] GameObject refPos;
    private Vector3 lastPos;
    public PhotonView photonView;
    public GameObject target;
    private Rigidbody rigid;
    public int moveSpeed;
    public int stopDistance;
    public float jumpForce;

    public List<GameObject> inventory = new List<GameObject>();   //List of item the player posses
    private Weapon currentWeapon;
    // Use this for initialization
    void Start ()
    {
        photonView = GetComponent<PhotonView>();
        rigid = GetComponent<Rigidbody>();
        inventory.Add(GetComponentInChildren<Weapon>().gameObject);
        currentWeapon = inventory[0].GetComponent<Weapon>();
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        GameObject[] playerList = GameObject.FindGameObjectsWithTag("Player");
        float dist = float.MaxValue;
        int index = int.MaxValue;
        for (int i = playerList.Length - 1; i >= 0 && playerList[i] != gameObject; i--)
        {
            float distTry = Vector3.Distance(playerList[i].transform.position, transform.position);
            if (distTry < dist)
            {
                dist = distTry;
                index = i;
            }
        }

        target = playerList[index];

        var targetRotation = Quaternion.LookRotation(target.transform.position - transform.position);
        Quaternion tmp = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        tmp.x = 0;
        tmp.z = 0;
        // Smoothly rotate towards the target point.
        transform.rotation = tmp;
        if (Vector3.Distance(transform.position, target.transform.position) > stopDistance)
        {
            Vector3 tmp2 = transform.forward * moveSpeed;
            tmp2.y = rigid.velocity.y;
            if (transform.position.y + lastPos.y < 0)
                Jump();
            rigid.velocity = tmp2;
            lastPos = transform.position;
        }
        else
            currentWeapon.Fire();
        rigid.angularVelocity = Vector3.zero;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Ground")
        {
            Jump();
        }
    }

    private void Jump()
    {
        Vector3 vel = rigid.velocity;
        vel.y = 0;
        rigid.velocity = vel;
        rigid.AddForce(new Vector3(0, jumpForce, 0), ForceMode.VelocityChange);
    }

    [PunRPC]
    public void TakeDamage(int damage, Vector3 point)  //Apply damge to all reference of the player accros the network
    {
        Debug.Log(this.gameObject.name + " est touche");
        if (photonView.isMine)
        {
            Vector3 force = (transform.position - point) * damage;
            force.y = 0;
            rigid.AddForce(force, ForceMode.VelocityChange);
        }
    }
}
