using UnityEngine;
using UnityEngine.Networking;

public class Player_Move : NetworkBehaviour
{
    private void Start()
    {
        if (!isLocalPlayer)
        {
            this.GetComponent<Camera>().enabled = false;
        }
    }
    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);
    }
}
