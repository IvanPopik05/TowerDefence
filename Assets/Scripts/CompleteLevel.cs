using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteLevel : MonoBehaviour
{
    public SceneFader sceneFader;
    public string nextLevel = "Level02";
    public float nextLevelIndex = 2;
    public string menuSceneName = "MainMenu";

    public void Continue()
    {
        PlayerPrefs.SetFloat("levelReached", nextLevelIndex);
        sceneFader.FadeTo(nextLevel);
    }

    public void Menu()
    {
        sceneFader.FadeTo(menuSceneName);
    }
}
