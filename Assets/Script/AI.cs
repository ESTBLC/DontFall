using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour {

    public float rotationSpeed;

    public GameObject target;
    private Rigidbody rigid;
    public int moveSpeed;
    public int stopDistance;

    public List<GameObject> inventory = new List<GameObject>();   //List of item the player posses
    private Weapon currentWeapon;
    // Use this for initialization
    void Start ()
    {
        rigid = GetComponent<Rigidbody>();
        inventory.Add(GetComponentInChildren<Weapon>().gameObject);
        currentWeapon = inventory[0].GetComponent<Weapon>();
    }
	
	// Update is called once per frame
	void Update ()
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
            rigid.velocity = transform.forward * moveSpeed;
        else
            currentWeapon.Fire();
        rigid.angularVelocity = Vector3.zero;

    }
}
