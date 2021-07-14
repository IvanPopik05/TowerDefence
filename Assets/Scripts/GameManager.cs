using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static bool GameIsOver;
    public GameObject GameOver;
    public GameObject CompleteLevel;
    // public Button ArrowButton;
    // public bool isArrowSpeed;
    private void Start() {
        GameIsOver = false;
        // isArrowSpeed = false;
        Time.timeScale = 1f;
    }
    private void Update() {

        // ArrowSpeed();

        if(GameIsOver)
        {
            return;
        }

        if(PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }

    // public void ArrowSpeed()
    // {
    //     if(Input.GetMouseButtonDown(0))
    //     {
    //         Time.timeScale = 1.75f;
    //         isArrowSpeed = true;
    //     }
    //     if(Input.GetMouseButtonDown(2))
    //     {
    //         Time.timeScale = 1f;
    //         isArrowSpeed = false;
    //     }
    // }
    void EndGame()
    {
        GameOver.SetActive(true);
        GameIsOver = true;
        Debug.Log("Game Over");
        CompleteLevel.SetActive(false);
    }

    public void WinLevel()
    {
        GameIsOver = true;
        CompleteLevel.SetActive(true);
        GameOver.SetActive(false);
        Debug.Log("Вы выиграли");
    }
}
