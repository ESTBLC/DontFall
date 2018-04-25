using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DoorTrigger : MonoBehaviour
{

    // Use this for initialization
    public float speed;


    public float maxOpenValue;
    public Transform door;
    public bool opening = false;
    public bool closing = false;
    private float CurrentValue = 0;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (opening) { Opendoor(); }
        if (closing) { Closedoor(); }
    }

    void OnTriggerEnter(Collider obj)
    {
        if (obj.transform.name == "Player 1" || obj.transform.name == "Player 2")
        {
            opening = true;
            closing = false;

        }

    }

    private void OnTriggerExit(Collider obj)
    {
        if (obj.transform.name == "Player 1" || obj.transform.name == "Player 2")
        {
            opening = false;
            closing = true;
        }
    }

    void Opendoor()
    {
        float mouvement = speed * Time.deltaTime;
        CurrentValue += mouvement;
        if (CurrentValue <= maxOpenValue)
        {
            door.position = new Vector3(
                door.position.x + mouvement,
                door.position.y,
                door.position.z

            );
        }
        else
        {
            opening = false;
        }
    }
    void Closedoor()
    {
        float mouvement = speed * Time.deltaTime;
        CurrentValue -= mouvement;
        if (CurrentValue >= 0)
        {
            door.position = new Vector3(
                door.position.x - mouvement,
                door.position.y,
                door.position.z

            );
        }
        else
        {
            closing = false;
        }
    }
}
