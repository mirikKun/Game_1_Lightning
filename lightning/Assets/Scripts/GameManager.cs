using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public string playAgainLevelToLoad;
    public static GameManager gm;
    public  GameObject PauseUI;
    public static bool isDeath=false;
    [Range(-1f,30f)]
    public float cubeAcceleratioon = 1f;
    void Awake()
    {
        // setup reference to game manager
        if (gm == null)
            gm = this.GetComponent<GameManager>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        


    }

    public void Death()
    {
        PauseUI.GetComponent<PauseMenu>().RestartMenu();
        isDeath = true;

    }
    public void RestartGame()
    {
        isDeath = false;
        SceneManager.LoadScene(playAgainLevelToLoad);
    }
}
