using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LivesUI : MonoBehaviour
{
    public TextMeshProUGUI LivesText;

    private void Update() {
        LivesText.text = PlayerStats.Lives.ToString();
    }
}
