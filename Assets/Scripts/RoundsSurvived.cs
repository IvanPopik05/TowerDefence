using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundsSurvived : MonoBehaviour
{
    public Text RoundsText;

    void OnEnable()
    {
        StartCoroutine(AnimateText());
    }

    IEnumerator AnimateText()
    {
        RoundsText.text = "0";
        int round = 0;

        yield return new WaitForSeconds(0.7f);

        while(round < PlayerStats.Rounds)
        {
            round++;
            RoundsText.text = round.ToString();
            yield return new WaitForSeconds(0.05f);
        }
    }
}
