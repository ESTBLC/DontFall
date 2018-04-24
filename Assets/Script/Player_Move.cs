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

    private CharacterController charController; //CharacterController component reference
    private GameObject camera;                  //Child GameObject Camera reference
    private Player player;
    private float Tx;                           //Actual movement variables
    private float Tz;                           //
    private float CamX;                         //
    private float CamY;                         //

    private void Start()
    {
        charController = GetComponent<CharacterController>();   //
        player = GetComponent<Player>();                        //Setup references
        camera = this.transform.Find("Camera").gameObject;      //

        //charController.angularDrag = float.MaxValue; //ugly fix rotation
    }
    void Update()
    {
        Tx = Input.GetAxis("Horizontal") * Time.deltaTime * leftrightAdjust;    //Get actual movement
        Tz = Input.GetAxis("Vertical") * Time.deltaTime * forwbacwAdjust;       //

        Vector3 moveDirection = new Vector3(Tx + Physics.gravity.x, Physics.gravity.y * Time.deltaTime, Tz + Physics.gravity.z); //Create a new direction vector and apply gravity to it

        if (charController.isGrounded)  //If grounded reset jump counter
            nbJump = 2;

        if (Input.GetButtonDown("Jump") && nbJump > 0)  //Jump and -1 to jump counter
        {
            nbJump--;
            moveDirection.y += jumpForce;
        }

        CamX += Input.GetAxis("Mouse X") * Time.deltaTime * mouseXAdjust;   //Get actual mouse movement
        CamX = CamX % 360;  //Modulo 360
        CamY += Input.GetAxis("Mouse Y") * Time.deltaTime * mouseYAdjust;   //Get actual mouve movement
        CamY = Mathf.Clamp(CamY, -90, 50);  //Clamp to not look too low

        moveDirection = transform.TransformDirection(moveDirection);    //Make the movement
        charController.Move(moveDirection);                             //
		transform.Rotate(0, CamX, 0);                                   //Make the rotation
        transform.localEulerAngles = new Vector3(0, CamX, 0);          
        camera.transform.localEulerAngles = new Vector3(CamY, camera.transform.localEulerAngles.y, camera.transform.localEulerAngles.z);

        if (Input.GetButton("Fire1"))
        {
            player.Fire();
        }
    }
}


