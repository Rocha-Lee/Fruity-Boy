using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public Button but;
    public int SceneIndex;
    void Start()
    {
        but.onClick.AddListener(Started);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void Started()
    {
        Debug.Log("Startou");
        SceneManager.LoadScene(SceneIndex);

    }
}
