using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    // Start is called before the first frame updat
    public GameObject PlayerCamPivot;



    public Vector3 CamHeight;
    public float moveSpeed = 8f;
    public float LerpSpeed = 5;
    public Transform InHousePivot;
    public bool InHouse;
    public Vector3 Inputs;

    private Rigidbody CamRigid;
    private Rigidbody PlayRigid;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        CamRigid = GetComponent<Rigidbody>();
        PlayRigid = PlayerCamPivot.GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {

        Inputs = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (InHouse == true)
        {
            transform.position = Vector3.Lerp(transform.position, InHousePivot.position, moveSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, InHousePivot.rotation, moveSpeed * Time.deltaTime);

        }
        else
        {
            
            CamRigid.MovePosition(Vector3.Lerp(CamRigid.position, PlayRigid.position + (Inputs) + (CamHeight), LerpSpeed * Time.deltaTime));
            //transform.position = Vector3.Lerp(transform.position, PlayerCamPivot.position + (Inputs) + (CamHeight), LerpSpeed * Time.deltaTime);

            CamRigid.MoveRotation(Quaternion.Lerp(Quaternion.Euler(45, 0, 0), Quaternion.Euler(45 - (Inputs.z * 10), 0, 0), LerpSpeed * Time.deltaTime));
            //transform.rotation = Quaternion.Lerp(Quaternion.Euler(45, 0, 0), Quaternion.Euler(45 - (Inputs.z * 10), 0, 0), LerpSpeed * Time.deltaTime);


        }
    }
   
}
