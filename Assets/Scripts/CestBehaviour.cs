using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CestBehaviour : MonoBehaviour
{
    //fruits
    public int MangaHalf;
    //fruits Needs
    public int MangaHalfNeed = 4;
    //
    public bool Done;
   
    void Start()
    {

    }
    void FixedUpdate()
    {
        diferrences();
    }
    private void OnCollisionEnter(Collision FruitObj)
    {
        if (FruitObj.gameObject.tag == "Manga_Half")
        {
            MangaHalf++;
        }
        
    }

    void OnCollisionExit(Collision FruitObj)
    {
        
        if (FruitObj.gameObject.tag == "Manga_Half")
        {
            MangaHalf--;
        }
    }
    void diferrences() { 
    
        

        if (MangaHalfNeed > 0)
            MangaHalfNeed -= MangaHalf;

        if(MangaHalfNeed <= 0)
        {
            Done = true;
        }
    }
}
