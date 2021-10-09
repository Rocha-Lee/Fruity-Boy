using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitColletor : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform CestPivot;
    public Transform ThrowPivot;
    public GameObject Fruity;
    private Animator PAnimator;

    public AudioClip Pickup;
    public AudioClip ThrowSound;

    private AudioSource Audio;

    public bool IsFull;
    private bool InterFruity;
    private bool HalfFruity;
    private bool DontPick;
    public int ThrowForce;

    //Cd
    private float CurrentTime;
    private float PickCD = 0.5f;
    void Start()
    {
        Audio = GetComponent<AudioSource>();
        PAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        CurrentTime += Time.deltaTime;
        if (InterFruity == true && IsFull == true)
        {
             var SpheresOfFruity = Fruity.GetComponentsInChildren<SphereCollider>();
            foreach (SphereCollider Sphe in SpheresOfFruity)
                Sphe.isTrigger = true;
            Fruity.transform.rotation = CestPivot.transform.rotation;
            Fruity.transform.position = CestPivot.transform.position;
            var RigidF = Fruity.GetComponent<Rigidbody>();
            RigidF.isKinematic = true;            
            
            if (Input.GetButtonDown("Fire1"))
            {
                foreach (SphereCollider Sphe in SpheresOfFruity)
                    Sphe.isTrigger = false; 
                Fruity.transform.rotation = ThrowPivot.transform.rotation;
                Fruity.transform.position = ThrowPivot.transform.position;
                RigidF.isKinematic = false;
                RigidF.AddRelativeForce(Vector3.left * ThrowForce);
                PAnimator.SetTrigger("Throw");
                Nulling();
            }
        }
        if (HalfFruity == true && IsFull == true)
        {
            Fruity.GetComponent<SphereCollider>().isTrigger = true;
            Fruity.transform.rotation = CestPivot.transform.rotation;
            Fruity.transform.position = CestPivot.transform.position;
            var RigidHF = Fruity.GetComponent<Rigidbody>();
            RigidHF.isKinematic = true;

            if (Input.GetButtonDown("Fire1"))
            {
                Fruity.GetComponent<SphereCollider>().isTrigger = false;
                Fruity.transform.rotation = ThrowPivot.transform.rotation;
                Fruity.transform.position = ThrowPivot.transform.position;
                RigidHF.isKinematic = false;
                RigidHF.AddRelativeForce(Vector3.left * ThrowForce);
                PAnimator.SetTrigger("Throw");
                Nulling();
            }

        }
        if(CurrentTime <= PickCD)
            DontPick = true;
        else
            DontPick = false;




    }
    private void OnCollisionStay(Collision ObjColis)
    {
        if (IsFull == false && DontPick == false)
        {
            //Manga
            if (ObjColis.gameObject.tag == "Manga")
            {
                Fruity = ObjColis.gameObject;
                Inter();
            }
            if (ObjColis.gameObject.tag == "Manga_Half")
            {
                Fruity = ObjColis.gameObject;
                Half();
            }
            //Carambola
            if (ObjColis.gameObject.tag == "Carambola")
            {
                Fruity = ObjColis.gameObject;
                Inter();
            }
            if (ObjColis.gameObject.tag == "Carambola_Half")
            {
                Fruity = ObjColis.gameObject;
                Half();
            }
            //Caju
            if (ObjColis.gameObject.tag == "Caju")
            {
                Fruity = ObjColis.gameObject;
                Inter();
            }
            if (ObjColis.gameObject.tag == "Caju_Half")
            {
                Fruity = ObjColis.gameObject;
                Half();
            }

        }
    }
        void Nulling()
    {
        IsFull = false;
        Fruity = null;
        CurrentTime = 0;
        HalfFruity = false;
        InterFruity = false;
        Audio.PlayOneShot(ThrowSound);
    }
    void Inter()
    {
        Audio.PlayOneShot(Pickup);
        InterFruity = true;
        IsFull = true;
        CurrentTime = 0;
    }
    void Half()
    {
        Audio.PlayOneShot(Pickup);
        HalfFruity = true;
        IsFull = true;
        CurrentTime = 0;
    }
}
