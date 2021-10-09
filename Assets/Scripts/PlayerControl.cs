using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // Components & GameObjects
    private Rigidbody Rigid;
    private Animator PlayAnimator;
    private ParticleSystem PartSys;
    public GameObject Cam;
    // Physics 
    public int PlayerSpeed;
    public int PlayerRotSpeed;
    public int JumpForce;
    public bool IsGrounded;
    private bool InputPress;
    //Cd
    private float CurrentTime;
    private float JumpCD = 0.5f;
    //Audio
    public AudioClip JumpSound;
    private AudioSource SoundSource;
    void Start()
    {
        SoundSource = GetComponent<AudioSource>();
        PartSys = GetComponent<ParticleSystem>();
        Rigid = GetComponent<Rigidbody>();
        PlayAnimator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var Dusting = PartSys.emission;
        CurrentTime += Time.deltaTime;
        //Input
        Vector3 Player_Input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (Player_Input.x != 0 && Player_Input.z != 0) //Avoiding Cross Square Issues
            Player_Input /= 1.33f;       
        //Simple Movement 
        Rigid.MovePosition(transform.position + Player_Input * Time.deltaTime * PlayerSpeed);
      

        //Simple Rotation
        if (Player_Input.x == 0 && Player_Input.z == 0)
        {
            PlayAnimator.SetBool("Walking", false);
            InputPress = false;
        }
        else //Look To Arrows
        {
            InputPress = true;
            PlayAnimator.SetBool("Walking", true);
            Quaternion newRotation = Quaternion.LookRotation(Player_Input * 10);
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * PlayerRotSpeed);
        }
        //Jump
        if (Input.GetButton("Jump"))
        {
            if(CurrentTime >= JumpCD)
            {
                Jump();
               
                CurrentTime = 0;
            }
        }
        
        //Is Grounded
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 0.1f)) //0.1f margem de pulo
        {
            PlayAnimator.SetBool("IsGrounded", true);
            IsGrounded = true;
        }
        else
        {
            PlayAnimator.SetBool("IsGrounded", false);
            IsGrounded = false;
        }

        //DustSys
        if(IsGrounded == true && InputPress == true)
            Dusting.enabled = true;
        else
            Dusting.enabled = false;
        //What Ground?
        RaycastHit hitGround;
        if (Physics.Raycast(transform.position + Vector3.up/2, transform.TransformDirection(Vector3.down), out hitGround, 100f,3) && hitGround.collider.tag == "House") //InHouse True
        {

            Debug.DrawRay(transform.position + Vector3.up, transform.TransformDirection(Vector3.down) * hit.distance, Color.green);
            Cam.GetComponent<FollowCam>().InHouse = true;
        }
        else
        {

            Debug.DrawRay(transform.position + Vector3.up, transform.TransformDirection(Vector3.down) * 100f, Color.red);
            Cam.GetComponent<FollowCam>().InHouse = false;
        }
    }
    void Jump()
    {
        if (IsGrounded == true)
        {
            PlayAnimator.SetTrigger("Jumping");
            Rigid.AddForce(Vector3.up * JumpForce);
            SoundSource.PlayOneShot(JumpSound);
        }
    }

}
