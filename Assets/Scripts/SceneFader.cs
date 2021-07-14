using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
    public Image image;
    public AnimationCurve curve;
    [HideInInspector]
    
    private void Start() {
        StartCoroutine(FadeIn());
    }

    public void FadeTo(string scene)
    {
        StartCoroutine(FadeOut(scene));
    }

    IEnumerator FadeIn()
    {
        float timeColor = 1f;

        while(timeColor > 0)
        {
            timeColor -= Time.deltaTime;
            float curveTime = curve.Evaluate(timeColor);
            image.color = new Color(0,0,0,curveTime);
            yield return 0;
        }
    }

    IEnumerator FadeOut(string scene)
    {
        float timeColor = 0f;

        while(timeColor < 1f)
        {
            timeColor += Time.deltaTime;
            float curveTime = curve.Evaluate(timeColor);
            image.color = new Color(0,0,0,curveTime);
            yield return 0;
        }
        SceneManager.LoadScene(scene);
    }
}
