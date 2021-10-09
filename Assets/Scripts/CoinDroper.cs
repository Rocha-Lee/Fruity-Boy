using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDroper : MonoBehaviour
{
    private Rigidbody ShipRigid;
    public Mesh ConvexShipMesh;
    public GameObject cannon;
    public GameObject Player;
    public GameObject Coins;
    public Transform CannonPivot;

    private int shotsCoins;
    private int CannonShots;
    //CD
    public float TimeShoots;
    private float currentTime;
   
    void Start()
    {
        ShipRigid = GetComponent<Rigidbody>();
        shotsCoins = Random.Range(4, 8);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentTime += Time.deltaTime;
        if (gameObject.GetComponent<ShipBehaviour>().Done == true)
        {
            //ShipRigid.MovePosition(new Vector3(0, 0, 0));
            if (currentTime > TimeShoots && CannonShots < shotsCoins ) {
                cannon.transform.LookAt(Player.transform);
                Instantiate(Coins, CannonPivot.transform.position, Quaternion.identity);
                currentTime = 0;
                CannonShots++;
            }


            gameObject.GetComponent<MeshCollider>().convex = true;
            gameObject.GetComponent<MeshCollider>().sharedMesh = ConvexShipMesh;
            ShipRigid.isKinematic = false;
            ShipRigid.AddRelativeForce(Vector3.back * 10000 * Time.deltaTime);

        }
        else
        {
            

        }
    }
}
