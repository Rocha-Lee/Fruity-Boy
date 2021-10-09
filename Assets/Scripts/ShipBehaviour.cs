using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShipBehaviour : MonoBehaviour
{
    //fruits
    private int Manga; //não vetor para facilitar o debug no Inspector
    private int MangaHalf;
    private int Carambola;
    private int CarambolaHalf;
    private int Caju;
    private int CajuHalf; //5
    //fruits Needs
    private int MangaNeed; //0
    private int MangaHalfNeed;
    private int CarambolaNeed;
    private int CarambolaHalfNeed;
    private int CajuNeed;
    private int CajuHalfNeed; //5
    //
    public bool Done;
    //
    //FruityBehaviuour
    public bool Analised;
    public int FruitysVariety;
    public List<Vector2Int> FruityNeed = new List<Vector2Int>();// Primeiro inteiro é a fruta, e o segundo é a quantidade da fruta
    //Exibition
    public List<GameObject> Pivots = new List<GameObject>();
    public Texture2D CajuTex;
    public Texture2D CajuTexHalf;
    public Texture2D CarambolaTex;
    public Texture2D CarambolaTexHalf;
    public Texture2D MangaTex;
    public Texture2D MangaTexHalf;
    //
    void Start()
    {
        FruityNeed.Add(new Vector2Int(0, 0));
        FruityNeed.Add(new Vector2Int(0, 0));
        FruityNeed.Add(new Vector2Int(0, 0));
        //SeedRandomic
        var Seed = Time.realtimeSinceStartupAsDouble * 10000000;
        Random.InitState((int)Seed);
        //SeedRandomic
        FruitysVariety = Random.Range(1, 3);


        var x1 = Random.Range(0, 6);
        var x2 = Random.Range(0, 6);
        var x3 = Random.Range(0, 6);

        while (x1 == x2)
        x2 = Random.Range(0, 6);

        while (x3 == x2 || x3 == x1)//Garante que a mesma fruta nao seja escolhida mais de uma vez
        x3 = Random.Range(0, 6);



        FruityNeed[0] = new Vector2Int(x1, Random.Range(1, 2)); // randomiza uma das "seis" frutas e uma quantia dela.
        FruityNeed[1] = new Vector2Int(x2, Random.Range(1, 1)); // randomiza uma das "seis" frutas e uma quantia dela.
        FruityNeed[2] = new Vector2Int(x3, Random.Range(1, 1)); // randomiza uma das "seis" frutas e uma quantia dela.



        if (FruitysVariety == 1)
        {
            Pivots[0].GetComponentInChildren<TextMeshPro>().text = FruityNeed[0].y.ToString();
            Pivots[1].SetActive(false);
            Pivots[2].SetActive(false);
        }
        else if (FruitysVariety == 2)
        {
            Pivots[0].GetComponentInChildren<TextMeshPro>().text = FruityNeed[0].y.ToString();
            Pivots[1].GetComponentInChildren<TextMeshPro>().text = FruityNeed[1].y.ToString();
            Pivots[2].SetActive(false);
        }
        else if (FruitysVariety >= 3)
        {
            Pivots[0].GetComponentInChildren<TextMeshPro>().text = FruityNeed[0].y.ToString();
            Pivots[1].GetComponentInChildren<TextMeshPro>().text = FruityNeed[1].y.ToString();
            Pivots[2].GetComponentInChildren<TextMeshPro>().text = FruityNeed[2].y.ToString();
        }

        //
        if (Analised == false)
        {
            for (int i = 0; i < FruitysVariety; i++)
            {
                if (FruityNeed[i].x == 0)//manga
                {
                    Debug.Log("Precisa de " + FruityNeed[i].y + " Mangas");
                    Pivots[i].transform.GetChild(1).GetComponentInChildren<MeshRenderer>().material.mainTexture = MangaTex;
                    
                    MangaNeed = FruityNeed[i].y;
                }
                //meia manga
                if (FruityNeed[i].x == 1)
                {
                    Debug.Log("Precisa de " + FruityNeed[i].y + " meias Mangas");
                    MangaHalfNeed = FruityNeed[i].y;
                    Pivots[i].transform.GetChild(1).GetComponentInChildren<MeshRenderer>().material.mainTexture = MangaTexHalf;
                }
                //Carambola Inteira
                if (FruityNeed[i].x == 2)
                {
                    Debug.Log("Precisa de " + FruityNeed[i].y + " Carambolas");
                    CarambolaNeed = FruityNeed[i].y;
                    Pivots[i].transform.GetChild(1).GetComponentInChildren<MeshRenderer>().material.mainTexture = CarambolaTex;
                }
                //Meia Carambola
                if (FruityNeed[i].x == 3)
                {
                    Debug.Log("Precisa de " + FruityNeed[i].y + " meias Carambolas");
                    CarambolaHalfNeed = FruityNeed[i].y;
                    Pivots[i].transform.GetChild(1).GetComponentInChildren<MeshRenderer>().material.mainTexture = CarambolaTexHalf;
                }
                //Caju Inteiro
                if (FruityNeed[i].x == 4)
                {
                    Debug.Log("Precisa de " + FruityNeed[i].y + " Cajus");
                    CajuNeed = FruityNeed[i].y;
                    Pivots[i].transform.GetChild(1).GetComponentInChildren<MeshRenderer>().material.mainTexture = CajuTex;
                }
                //Meio Caju
                if (FruityNeed[i].x == 5)
                {
                    Debug.Log("Precisa de " + FruityNeed[i].y + " meios Cajus");
                    Pivots[i].transform.GetChild(1).GetComponentInChildren<MeshRenderer>().material.mainTexture = CajuTexHalf;
                    CajuHalfNeed = FruityNeed[i].y;
                }


            }
        }


    }
    void FixedUpdate()
    {
        

        diferrences();
        if (Done)
        {
            var script = gameObject.GetComponent<ShipBehaviour>();

            script.enabled = false;

            Debug.Log("missão completa ");
        }
    }
    private void OnCollisionEnter(Collision FruitObj)
    {
        if (FruitObj.gameObject.tag == "Manga")
        {
            Manga++;
        }
        if (FruitObj.gameObject.tag == "Manga_Half")
        {
            MangaHalf++;
        }
        if (FruitObj.gameObject.tag == "Carambola")
        {
            Carambola++; ;
        }
        if (FruitObj.gameObject.tag == "Carambola_Half")
        {
            CarambolaHalf++;
        }
        if (FruitObj.gameObject.tag == "Caju")
        {
            Caju++; ;
        }
        if (FruitObj.gameObject.tag == "Caju_Half")
        {
            CajuHalf++; 
        }
    }

    void OnCollisionExit(Collision FruitObj)
    {
        if (FruitObj.gameObject.tag == "Manga")
        {
            Manga--;
        }
        if (FruitObj.gameObject.tag == "Manga_Half")
        {
            MangaHalf--;
        }
        if (FruitObj.gameObject.tag == "Carambola")
        {
            Carambola--;
        }
        if (FruitObj.gameObject.tag == "Carambola_Half")
        {
            CarambolaHalf--;
        }
        if (FruitObj.gameObject.tag == "Caju")
        {
            Caju--;
        }
        if (FruitObj.gameObject.tag == "Caju_Half")
        {
            CajuHalf--;
        }
    }
    void diferrences() { 
    
        if(MangaNeed > 0)
            MangaNeed -= Manga;

        if (MangaHalfNeed > 0)
            MangaHalfNeed -= MangaHalf;

        if (CarambolaNeed > 0)
            CarambolaNeed -= Carambola;

        if (CarambolaHalfNeed > 0)
            CarambolaHalfNeed -= CarambolaHalf;

        if (CajuNeed > 0)
            CajuNeed -= Caju;

        if (CajuHalfNeed > 0)
            CajuHalfNeed -= CajuHalf;

        if(MangaNeed <=0 && MangaHalfNeed <= 0 && CarambolaNeed <= 0 && CarambolaHalfNeed <= 0 && CajuNeed <= 0 && CajuHalfNeed <= 0)
        {
            Done = true;
        }
    }
}
