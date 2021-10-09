using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform SpawnPivot;
    private Rigidbody RigidPlayer;
    public GameObject LifesParent;
    public AudioClip HurtSound;
    public List<Transform> LifesInCanvas = new List<Transform>();

    public GameObject Restart;
    public GameObject Discharge;
    public Color DeadHeartColor;
    public int MaxLife = 12;
    public int CurrentLife; //public for debug
    //Damage CoolDown
    public float DmgCD;
    private float CurrentCD;
    void Start()
    {
        CurrentLife = MaxLife;
        RigidPlayer = GetComponent<Rigidbody>();
        for (int i = 0; i < LifesParent.transform.childCount;i++){
            LifesInCanvas.Add(null);
            LifesInCanvas[i] = LifesParent.transform.GetChild(i);
        }
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CurrentCD += Time.fixedDeltaTime;
        var LifesParts2 = LifesInCanvas[2].GetComponentsInChildren<Image>();//Ajeitar isso
        var LifesParts1 = LifesInCanvas[1].GetComponentsInChildren<Image>();
        var LifesParts0 = LifesInCanvas[0].GetComponentsInChildren<Image>();
        if (CurrentLife <= 11)
            LifesParts2[1].color = DeadHeartColor; 
        if(CurrentLife <= 10)
            LifesParts2[3].color = DeadHeartColor;
        if (CurrentLife <= 9)
            LifesParts2[2].color = DeadHeartColor;
        if (CurrentLife <= 8)
            LifesParts2[0].color = DeadHeartColor;
        if (CurrentLife <= 7)
             LifesParts1[1].color = DeadHeartColor;
        if (CurrentLife <= 6)
             LifesParts1[3].color = DeadHeartColor;
        if (CurrentLife <= 5)
            LifesParts1[2].color = DeadHeartColor;
        if (CurrentLife <= 4)
            LifesParts1[0].color = DeadHeartColor;
        if (CurrentLife <= 3)
            LifesParts0[1].color = DeadHeartColor;
        if (CurrentLife <= 2)
            LifesParts0[3].color = DeadHeartColor;
        if (CurrentLife <= 1)
            LifesParts0[2].color = DeadHeartColor;
        if (CurrentLife <= 0){
            LifesParts0[0].color = DeadHeartColor;
            Debug.Log("Morreu, Restart");
            gameObject.GetComponent<PlayerControl>().PlayerSpeed = 0;
            gameObject.GetComponent<PlayerControl>().PlayerRotSpeed = 0;
            gameObject.GetComponent<PlayerControl>().JumpForce = 0;
            gameObject.GetComponent<Animator>().SetTrigger("Defeat");
            gameObject.GetComponent<AudioSource>().volume = 0;
            gameObject.GetComponent<ParticleSystem>().Pause(true);
            Restart.SetActive(true);
        }
                
    }

 
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "OutMap")
        {
            RigidPlayer.velocity = new Vector3(0,0,0); //não deixa o player atravessar o chão na hora do teleporte
            Damage(2);
            transform.position = SpawnPivot.position;
            Instantiate(Discharge, SpawnPivot.position, Quaternion.identity);
        }
        if (other.tag == "Trap")
        {
            Damage(1);
        }

    }
    
    void Damage(int DmgAmount)
    {
        if (CurrentCD > DmgCD)
        {
            CurrentLife -= DmgAmount;
            CurrentCD = 0;
            Blink();
            gameObject.GetComponent<AudioSource>().PlayOneShot(HurtSound);
            

        }

    }
    void Blink()
    {
        gameObject.GetComponent<Blinky>().Blink = true;
    }
    
}

