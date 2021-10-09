using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    // Start is called before the first frame update
    private BoxCollider boxC;
    private Animation PlantAnim;
    public bool Closed;
    //Cd
    private float CurrentTime;
    public float CDToOpen;

    private AudioSource Audio;
    public AudioClip Bite;
    void Start()
    {
        Audio = GetComponent<AudioSource>();
        boxC = GetComponent<BoxCollider>();
        PlantAnim = GetComponent<Animation>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CurrentTime += Time.fixedDeltaTime;
        if (CurrentTime > CDToOpen && Closed)
        {
            Closed = false;
            PlantAnim.Play("TrapPlantBiteReverse");
            boxC.isTrigger = false;
        }
    }
    private void OnCollisionEnter(Collision IsPlayer)
    {
            PlantAnim.Play("TrapPlantBite");
            Closed = true;
            CurrentTime = 0;
            boxC.isTrigger = true;
            Audio.PlayOneShot(Bite);
    }
}
