using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool isPaused = false;
    public GameObject pauseMenuUI;
    public GameObject restartMenuUI;
    private bool isDeath=false;

    private void Start()
    {
        isPaused = false;
        Time.timeScale = 1;
    }
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape)&&!isDeath)
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

    }
    void OnGUI()
    {
        if (!isPaused)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

    }
    public void Resume()
    {   Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;        
    }
    
    public void RestartMenu()
    {
        isDeath = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        restartMenuUI.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void LoadMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("quit");
    }
    public void RestartGame()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
        GameManager.gm.RestartGame();
    }
}
