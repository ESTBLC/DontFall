using UnityEngine;
using UnityEngine.Networking;

public class Player_Move : NetworkBehaviour
{
    public float forwbacwAdjust = 0.0f;
    public float leftrightAdjust = 0.0f;
    public float mouseXAdjust = 0.0f;
    public float mouseYAdjust = 0.0f;

    private GameObject camera = null;
    private void Start()
    {
        camera = this.transform.Find("camera").gameObject;
        if (!isLocalPlayer)
        {
            camera.SetActive(false);
        }

    }
    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        var Tx = Input.GetAxis("Horizontal") * Time.deltaTime * leftrightAdjust;
        var Tz = Input.GetAxis("Vertical") * Time.deltaTime * forwbacwAdjust;

        var CamX = Input.GetAxis("Mouse X") * Time.deltaTime * mouseXAdjust;
        var CamY = Input.GetAxis("Mouse Y") * Time.deltaTime * mouseYAdjust;

        transform.Translate(Tx, 0, Tz);
        transform.Rotate(CamX, 0, 0);
        camera.transform.Rotate(0, CamY, 0);
    }
}
