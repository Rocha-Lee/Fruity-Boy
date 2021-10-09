using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigDoor : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Door1;
    public GameObject Door2;
    public GameObject Lock1;
    public GameObject Lock2;

    public GameObject Condi1;
    public GameObject Condi2;

    public bool Condition1;
    public bool Condition2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Condition1)
            Lock1.SetActive(false);

        if (Condition2)
            Lock2.SetActive(false);

        Condition1 = Condi1.GetComponent<ShipBehaviour>().Done;
        Condition2 = Condi2.GetComponent<CestBehaviour>().Done;
        if (Condition1 && Condition2)
        {
            Door1.GetComponent<Rigidbody>().isKinematic = false;
            Door2.GetComponent<Rigidbody>().isKinematic = false;

        }
        else
        {
            


        }
    }
}
