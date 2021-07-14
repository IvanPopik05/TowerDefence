using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject uiMenu;
    public SceneFader sceneFader;
    public string MainMenu = "MainMenu";
    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            Toggle();
        }
    }
    public void Toggle()
    {
        uiMenu.SetActive(!uiMenu.activeSelf);

        if(uiMenu.activeSelf)
        {
            Time.timeScale = 0f;
        } else
        {
            Time.timeScale = 1f;
        }
    }
    
    public void Retry()
    {
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }
    public void Menu()
    {
        Toggle();
        sceneFader.FadeTo(MainMenu);
    }
}
