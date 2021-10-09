using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinColletor : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject CoinPickPrefab;
    private Vector3 LastCoinTransform;
    private bool InstantEfect;
    public int CoinsAmount;
    public TextMeshProUGUI CoinUI;

    public GameObject CoinScore;


    public bool NoScore;
    void Start()
    {
        CoinScore = GameObject.Find("CoinScore");
        if(CoinScore == null)
        {

            NoScore = true;
            CoinsAmount = 0;
        }
        else
        {
            CoinsAmount = CoinScore.GetComponent<CoinSaveData>().CoinSaved;
        }
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(NoScore == false)
        {
            CoinScore.GetComponent<CoinSaveData>().CoinSaved = CoinsAmount;

            
            
        }
        CoinUI.SetText(CoinsAmount.ToString());


        if (InstantEfect)
        {
            Instantiate(CoinPickPrefab, LastCoinTransform, Quaternion.identity);
            InstantEfect = false;
        }
        else
        {
        }
    }
    private void OnCollisionStay(Collision ObjColis)
    {
        //Coin
        if (ObjColis.gameObject.tag == "Coin")
        {
            CoinsAmount++;
            InstantEfect = true;
            LastCoinTransform = ObjColis.gameObject.transform.position;
            Destroy(ObjColis.gameObject);
        }
    }
}
