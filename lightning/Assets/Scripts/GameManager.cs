using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public string playAgainLevelToLoad;
    public static GameManager gm;
    [Range(-1f,15f)]
    public float cubeAcceleratioon = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        


    }

    public void RestartGame()
    {
        // we are just loading a scene (or reloading this scene)
        // which is an easy way to restart the level
        SceneManager.LoadScene(playAgainLevelToLoad);
    }
}
