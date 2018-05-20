using UnityEngine;
using UnityEngine.Networking;

public class Player_Move : MonoBehaviour
{
    public float forwbacwAdjust;    //
    public float leftrightAdjust;   //
    public float mouseXAdjust;      //Speed movement variables
    public float mouseYAdjust;      //
    public float jumpForce;         //
    public int nbJump;              //Number of jump
    public float sprintSpeed;

    private float mult = 1;
    private Rigidbody rigid;                    //CharacterController component reference
    public GameObject camera;                  //Child GameObject Camera reference
    private Player player;
    private float Tx;                           //Actual movement variables
    private float Tz;                           //
    private float Ty;
    private float CamX;                         //
    private float CamY;                         //
    private int nbJumpLeft;
    private bool isRunning = false;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();   //
        player = GetComponent<Player>();                //Setup references
        camera = transform.Find("Camera").gameObject;   //
        nbJumpLeft = nbJump;
    }

    void FixedUpdate()
    {
        Tx = Input.GetAxis("Horizontal") * leftrightAdjust* mult;    //Get actual movement
        Tz = Input.GetAxis("Vertical") * forwbacwAdjust * mult;       //
        Ty = rigid.velocity.y;

        Vector3 moveDirection = new Vector3(Tx, Ty, Tz) + player.impactForce; //Create a new direction vector and apply gravity to it

        moveDirection = transform.TransformDirection(moveDirection);    //Make the movement
        rigid.velocity = moveDirection;                                 //
    }

    void Update()
    {
        /*float inputH = Input.GetAxis("Horizontal");
        float inputV = Input.GetAxis("Vertical");
        anim.SetFloat("inputH", inputH);
        anim.SetFloat("inputV", inputV);*/

        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
        {
            player.photonView.RPC("ChangeAnimation", PhotonTargets.All, "Idle");
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            player.photonView.RPC("ChangeAnimation", PhotonTargets.All, "Forward");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            player.photonView.RPC("ChangeAnimation", PhotonTargets.All, "Backward");
        }
        /*if (Input.GetKeyDown(KeyCode.Space))
            anim.SetBool("Jump", true);*/
        if (Input.GetKey(KeyCode.LeftShift))
        {
            mult = sprintSpeed;
        }
        else if (Input.GetKey(KeyCode.O))
        {
            mult = 0;
        }
        else if (Input.GetKey(KeyCode.C))
        {
            mult = 0.5F;
        }
        else
        {
            mult = 1;
        }
        
        
        




        CamX += Input.GetAxis("Mouse X") * mouseXAdjust;   //Get actual mouse movement
        CamX = CamX % 360;  //Modulo 360
        CamY += Input.GetAxis("Mouse Y") * mouseYAdjust;   //Get actual mouve movement
        CamY = Mathf.Clamp(CamY, -90, 50);  //Clamp to not look too low

        transform.Rotate(0, CamX, 0);                                   //Make the rotation
        transform.localEulerAngles = new Vector3(0, CamX, 0);                                                                               //
        camera.transform.localEulerAngles = new Vector3(CamY, camera.transform.localEulerAngles.y, camera.transform.localEulerAngles.z);    //Black magic

        if (Input.GetButtonDown("Jump") && nbJumpLeft > 0)  //Jump and -1 to jump counter
        {
            nbJumpLeft--;
            Vector3 vel = rigid.velocity;
            vel.y = 0;
            rigid.velocity = vel;
            rigid.AddForce(new Vector3(0, jumpForce, 0), ForceMode.VelocityChange);
        }

        if (Input.GetButton("Fire1")) //Launch fire action
        {
            player.Fire();
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0f) // forward
        {
            player.photonView.RPC("ChangeWeapon", PhotonTargets.All, 1);
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f) // backwards
        {
            player.photonView.RPC("ChangeWeapon", PhotonTargets.All, -1);
        }

        if (Input.GetButtonDown("Interact"))
        {
            Ray ray = new Ray(camera.transform.position, camera.transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 4))
            {
                Debug.DrawLine(ray.origin, hit.point);
                int ownerID = hit.collider.transform.parent.gameObject.GetComponent<PhotonView>().ownerId;
                if (hit.collider.tag == "Weapon" && (ownerID == 1 || ownerID == 0))
                {
                    GameObject weapon = hit.collider.transform.parent.gameObject;
                    weapon.GetComponent<PhotonView>().TransferOwnership(PhotonNetwork.player);
                    int id = weapon.GetComponent<PhotonView>().viewID;
                    player.photonView.RPC("PickUPWeapon", PhotonTargets.All, id);
                }
            }
        }

        if (Input.GetButtonDown("Drop Weapon"))
        {
            player.photonView.RPC("DropWeapon", PhotonTargets.All);
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag == "Ground")
        {
            nbJumpLeft = nbJump;
            /*anim.SetBool("Jump", false);*/
        }
    }

    public void Telep(Vector3 pos)
    {
        pos.x += 2;
        pos.z += 2;
        transform.position = pos;
    }
}