using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public string playAgainLevelToLoad;

    [Range(-1f,30f)]
    public float cubeAcceleratioon = 1f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        


    }

    public void RestartGame()
    {
        SceneManager.LoadScene(playAgainLevelToLoad);
    }
}
