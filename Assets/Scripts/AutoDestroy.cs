using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    public float TimeToDestroy;
    private float CurrentTiming;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CurrentTiming += Time.deltaTime;
        if (CurrentTiming >= TimeToDestroy)
        {
            Destroy(gameObject);
        }
    }
}
