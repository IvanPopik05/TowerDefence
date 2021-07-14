using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class levelSelector : MonoBehaviour
{
    public SceneFader SceneFader;
    public Button[] levelButtons;

    private void Start() {

        float levelReached = PlayerPrefs.GetFloat("levelReached",1);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if(i + 1 > levelReached)
            levelButtons[i].interactable = false;
        }
    }

    public void Selector(string selectName)
    {
        SceneFader.FadeTo(selectName);
    }
}
