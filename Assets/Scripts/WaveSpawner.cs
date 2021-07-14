using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlives = 0;
    public Transform SpawnPoint; // Точка положения противников
    public float timeBetweenWave = 5f; // Время между волнами
    private float countdown = 1f; // Обратный отсчёт времени
    private int waveIndex = 0; // Число противников после timeBetweenWave 
    public Text waveCountdownText;
    public Wave[] waves;
    public GameManager gameManager;
    private void Update() {

        if(EnemiesAlives > 0)
        {
            return;
        }

        if(waveIndex == waves.Length)
        {
            gameManager.WinLevel();
            this.enabled = false;
        }

        if(countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWave;
            return;
        }
        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f,Mathf.Infinity);
        waveCountdownText.text = string.Format("{0:00.00}", countdown);
        // waveCountdownText.text = Mathf.Floor(countdown).ToString(); // Mathf.Floor возвращает самое большое число без дробных
    }
    IEnumerator SpawnWave()
    {
        PlayerStats.Rounds++;

        Wave wave = waves[waveIndex];

        EnemiesAlives = wave.count;

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate); // время появления за предыдущим противником
        }
        // Debug.Log("Wave Incoming");
        waveIndex ++;
    }
    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy,SpawnPoint.position,SpawnPoint.rotation);
    }
}
