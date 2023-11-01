using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameStart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
    }
    public void GameEnd()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("StartScene");
    }
}
