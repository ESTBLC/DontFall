using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour {

    GameObject target = null;
    NavMeshAgent agent = null;
    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
        //target = GameObject.FindWithTag("Player"); Marche pas ???
        agent.SetDestination(target.transform.position);

    }
	
	// Update is called once per frame
	void Update () {
        //Update Target
        if (target == null)
            target = GameObject.Find("Player 2");
        agent.SetDestination(target.transform.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.tag == "Ground")
    }
}
