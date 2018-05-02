using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper_pad : MonoBehaviour {

    private GameObject Object;
    private Rigidbody rb;
    [SerializeField]
    private float jumpForce = 20;
    [SerializeField]
    private BoxCollider colliderPad;
    private Vector3 normal;

    private void Start()
    {
        if (colliderPad == null)
            Debug.Log("Jumper_pad : Haven't a box collider for jump");
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.contacts[0].thisCollider == colliderPad)
        {
            
            Object = collision.gameObject;
            rb = Object.GetComponent<Rigidbody>();
            normal = collision.contacts[0].normal;
            Jump();
        }
    }

    private void Jump()
    {
        //Vector3 vect = Object.transform.up; //vect to jump horizontaly
        //Vector3 vect = Object.transform.localRotation;
        normal *= jumpForce*-1;
        rb.AddForce(normal, ForceMode.Impulse);
    }
}
