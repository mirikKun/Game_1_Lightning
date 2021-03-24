using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Slider xSensSlider;
    public Slider ySensSlider;
    public Toggle invertedBox;
    public void Start()
    {
        xSensSlider.value = GameOptions.xVelocity;
        ySensSlider.value = GameOptions.yVelocity;
        if (GameOptions.inverted == 1)
            invertedBox.isOn = true;
        else
            invertedBox.isOn = false;
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuiteGame()
    {
        Debug.Log("quite");
        Application.Quit();
    }
    public void SetXSensitivity(float xSens)
    {
        GameOptions.xVelocity = xSens;
    }
    public void SetYSensitivity(float ySens)
    {
        GameOptions.yVelocity = ySens;
    }
    public void SetInverting(bool inverted)
    {
        if (inverted)
            GameOptions.inverted = 1;
        else
            GameOptions.inverted = -1;
    }
}
