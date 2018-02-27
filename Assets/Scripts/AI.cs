using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour {

    GameObject target;
    NavMeshAgent agent = null;
    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
        //target = GameObject.FindWithTag("Player");
        agent.SetDestination(target.transform.position);

    }
	
	// Update is called once per frame
	void Update () {
        if (target == null)
            target = GameObject.FindWithTag("Player");
        agent.SetDestination(target.transform.position);
    }
}
