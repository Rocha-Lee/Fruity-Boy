using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeFruit : MonoBehaviour
{
    
    public List<GameObject> pivot = new List<GameObject>();
    public List<GameObject> FruityInstance = new List<GameObject>();

    public Vector3 Rotation;
    [Range(1, 3)]
    public int FruityChoice = 1;

    //cd 
    public float TimeToRespaw = 10;
    private float CurrentTime;



    void Start()
    {
        if (FruityChoice == 1)
        {

            for (int i = 0; i < 3; i++)
            {
                Instantiate(FruityInstance[0], pivot[i].transform.position, pivot[i].transform.rotation);

            }

        }
        else if (FruityChoice == 2)
        {

            for (int i = 0; i < 3; i++)
            {
                Instantiate(FruityInstance[1], pivot[i].transform.position, pivot[i].transform.rotation);

            }

        }
        else if (FruityChoice == 3)
        {

            for (int i = 0; i < 3; i++)
            {
                Instantiate(FruityInstance[2], pivot[i].transform.position, pivot[i].transform.rotation);

            }

        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CurrentTime += Time.fixedDeltaTime;
        if (CurrentTime > TimeToRespaw)
        {
            if (FruityChoice == 1)
            {

                for (int i = 0; i < 3; i++)
                {
                    Instantiate(FruityInstance[0], pivot[i].transform.position, pivot[i].transform.rotation);

                }

            }
            else if (FruityChoice == 2)
            {

                for (int i = 0; i < 3; i++)
                {
                    Instantiate(FruityInstance[1], pivot[i].transform.position, pivot[i].transform.rotation);

                }

            }
            else if (FruityChoice == 3)
            {

                for (int i = 0; i < 3; i++)
                {
                    Instantiate(FruityInstance[2], pivot[i].transform.position, pivot[i].transform.rotation);

                }

            }
            CurrentTime = 0;
        }
    }
}
