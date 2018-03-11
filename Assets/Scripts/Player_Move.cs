using UnityEngine;
using UnityEngine.Networking;

public class Player_Move : NetworkBehaviour
{
    public float forwbacwAdjust = 0.0f;
    public float leftrightAdjust = 0.0f;
    public float mouseXAdjust = 0.0f;
    public float mouseYAdjust = 0.0f;
    public float jumpForce = 0.0f;
    public int nbJump = 0;

    private Rigidbody rigid = null;
    private GameObject camera = null;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
        camera = this.transform.Find("Camera").gameObject;
        if (!isLocalPlayer)
        {
            camera.SetActive(false);
        }
        rigid.angularDrag = float.MaxValue; //ugly fix rotation
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
		transform.Rotate(0, CamX, 0);
		camera.transform.Rotate(CamY, 0, 0);
        Quaternion rotation = transform.rotation;
        transform.rotation = new Quaternion(0, rotation.y, 0, rotation.w);

        if (Input.GetButtonDown("Jump") && nbJump > 0)
        {
            nbJump--;
            rigid.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
            nbJump = 2;
    }

    private void OnCollisionStay(Collision collision)
    {
        
    }
}


