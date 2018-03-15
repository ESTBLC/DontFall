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
    private float Tx;
    private float Tz;
    private float CamX;
    private float CamY;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
        player = GetComponent<Player>();
        camera = this.transform.Find("Camera").gameObject;
        rigid.angularDrag = float.MaxValue; //ugly fix rotation
    }
    void Update()
    {
        Tx = Input.GetAxis("Horizontal") * Time.deltaTime * leftrightAdjust;
        Tz = Input.GetAxis("Vertical") * Time.deltaTime * forwbacwAdjust;

        CamX += Input.GetAxis("Mouse X") * Time.deltaTime * mouseXAdjust;
        CamX = CamX % 360;
        CamY += Input.GetAxis("Mouse Y") * Time.deltaTime * mouseYAdjust;
        CamY = Mathf.Clamp(CamY, -90, 50);

        transform.Translate(Tx, 0, Tz);
		transform.Rotate(0, CamX, 0);
        transform.localEulerAngles = new Vector3(0, CamX, 0);
        camera.transform.localEulerAngles = new Vector3(CamY, camera.transform.localEulerAngles.y, camera.transform.localEulerAngles.z);

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
        if (collision.gameObject.tag == "Respawn")
        {
            Debug.Log("you are dead");
            Destroy(gameObject);
        }
    }
}


