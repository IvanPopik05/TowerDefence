using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public SceneFader sceneFader;
    public string MainMenu = "MainMenu";
    public void Retry()
    {
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }
    public void Menu()
    {
        sceneFader.FadeTo(MainMenu);
        Debug.Log("Появилось меню");
    }
    public void Play()
    {
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("Следующий раунд");
    }
}
