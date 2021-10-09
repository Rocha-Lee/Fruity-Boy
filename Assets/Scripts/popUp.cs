using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popUp : MonoBehaviour
{
    // Start is called before the first frame update
    private Animation Animat;
    void Start()
    {
        Animat = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Animat.Play("OpenText");


        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Animat.Play("CloseText");


        }
    }
}
