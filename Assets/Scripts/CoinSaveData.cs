using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSaveData : MonoBehaviour
{
    public int CoinSaved;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        DontDestroyOnLoad(gameObject);
    }
}
