using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleFloating : MonoBehaviour
{
    // Start is called before the first frame update
    public float amp = 0.5f;          //Set in Inspector 
    public float speed = 1;
    public bool RandRotateY = false;
    private float floating;//Set in Inspector
    void Start()
    {
        //SeedRandomic
        var Seed = Time.realtimeSinceStartupAsDouble * 10000000;
        Random.InitState((int)Seed);
        floating = Random.Range(-amp, amp);
        speed = Random.Range(speed/0.8f, speed);
        if (RandRotateY)
            transform.rotation = Quaternion.Euler(transform.rotation.x, Random.Range(0, 360),transform.rotation.z);
    }
    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + (floating), transform.position.z);
        floating = amp / 100 * Mathf.Sin(speed * Time.time);
    }
}