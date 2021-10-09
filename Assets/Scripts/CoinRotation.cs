using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotation : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody CoinRigid;
    void Start()
    {
        CoinRigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CoinRigid.MoveRotation(CoinRigid.rotation * Quaternion.Euler(Time.fixedDeltaTime * 100, 0,0));
       
    }
}
