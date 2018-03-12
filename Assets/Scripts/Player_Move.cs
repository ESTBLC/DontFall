using UnityEngine;
using UnityEngine.Networking;

public class Player_Move : NetworkBehaviour
{
    public float forwbacwAdjust;
    public float leftrightAdjust;
    public float mouseXAdjust;
    public float mouseYAdjust;
    public float jumpForce;
    public int nbJump;

    private Rigidbody rigid;
    private GameObject camera;
    private Player player = null;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
        player = GetComponent<Player>();
        camera = this.transform.Find("Camera").gameObject;
        rigid.angularDrag = float.MaxValue; //ugly fix rotation
    }
    void Update()
    {
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

        if (Input.GetButton("Fire1"))
        {
            player.Fire();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
            nbJump = 2;
    }
}


