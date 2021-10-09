using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blinky : MonoBehaviour
{
    public bool Blink = false;
    public float Duration = 2;
    private float current;
    private Transform Mesh; //filho mesh index 0
    private float par;
    void Start()
    {
        current = 30;
        Mesh = transform.GetChild(0);
    }
    void FixedUpdate()
    {
        current += Time.deltaTime;

        if (Blink)
        {
            current = 0;
            Blink = false;
        }

        if (current < Duration)
        {
            if (par % 2 == 0) { 
                Mesh.transform.gameObject.SetActive(false);
                par++;
            }
            else{
                Mesh.transform.gameObject.SetActive(true);
                par++;
            }
        }
        else
        {
            par = 0;
            Mesh.transform.gameObject.SetActive(true);
        }


    }
}
