using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMain : MonoBehaviour
{
    [Header("UI Pages")]
    public GameObject mainScreen;
    public GameObject settingsScreen;

    public void StartGame()
    {
        Application.LoadLevel("levelismi");
    }
    public void Settings()
    {
        mainScreen.SetActive(false);
        settingsScreen.SetActive(true);
    }

    public void backToMenu()
    {
        mainScreen.SetActive(true);
        settingsScreen.SetActive(false);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
