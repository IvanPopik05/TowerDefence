using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string LevelScene = "MainLevel";
    public GameObject effect;
    public Transform positionEffect;
    public SceneFader sceneFader;
    public void Play()
    {
        Debug.Log("Play");
        GameObject effectEx = Instantiate(effect,positionEffect.position,Quaternion.identity);

        StartCoroutine(GoLoadScene());
        Destroy(effectEx, 2.5f);
    }
    IEnumerator GoLoadScene()
    {
        yield return new WaitForSeconds(2f);
        sceneFader.FadeTo(LevelScene);
    }
    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
