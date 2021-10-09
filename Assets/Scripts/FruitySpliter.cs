using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitySpliter : MonoBehaviour
{
    // Start is called before the first frame update
    public string FruityHalfTagName;
    public bool IsCutted = false;

    public GameObject SlahsSound;

    private Rigidbody fruityRigid;

    public bool OnPlayer;

    //AutoDest
    public float TimeTo;
    public float currentTime;

    void Start()
    {
        fruityRigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        InPlayer(OnPlayer);

        currentTime += Time.fixedDeltaTime;

        if (currentTime > TimeTo && fruityRigid.isKinematic)
            Destroy(gameObject);
        else if (fruityRigid.isKinematic == false)
            currentTime = 0;
      
        if (IsCutted)
        {
            var HalfsFruity0 = this.transform.GetChild(0).gameObject;
            var HalfsFruity1 = this.transform.GetChild(1).gameObject;
            HalfsFruity0.AddComponent<Rigidbody>();
            HalfsFruity1.AddComponent<Rigidbody>();
            HalfsFruity0.tag = FruityHalfTagName;
            HalfsFruity1.tag = FruityHalfTagName;
            HalfsFruity0.GetComponent<SphereCollider>().enabled = true;
            HalfsFruity1.GetComponent<SphereCollider>().enabled = true;
            HalfsFruity0.transform.parent = null;
            HalfsFruity1.transform.parent = null;
            Destroy(gameObject); // Destroy the Parent Istance
        }
        
    }
    private void OnCollisionEnter(Collision ObjColid)
    {
        if (ObjColid.gameObject.tag == "FruitySplitter")
        {
            IsCutted = true;
            Instantiate(SlahsSound, gameObject.transform.position,Quaternion.identity);
             
        }
        if (ObjColid.gameObject.tag == "Player")
        {
            OnPlayer = true;
           
        }
    }
    
    void InPlayer(bool inP)
    {
        if (inP)
        {
            currentTime = 0;
        }
        else
        {
            

        }

    }


}
