using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f; // Начальная скорость противника
    public float speed; // Скорость противника
    public float startHealth = 100;// Начальное здровье противника
    public float health; // Здоровье противника
    public int value = 50; // Монеты противника
    public GameObject enemyEffect; // еффект противника
    public Image HealthImage; // Жизни противника
    private bool isDead = false;

    private void Start() {
        speed = startSpeed;
        health = startHealth;
    }
    public void TakeDamage(float amount) // урон пули
    {
        health -= amount; // Отнимают жизни в зависимости от пули
        HealthImage.fillAmount = health / startHealth;
        if(health <= 0 && !isDead) // Жизни меньше нуля
        {
            Die(); // Смерть
        }
    }
    public void Slow(float pct)
    {
        speed = startSpeed * (1f - pct);
    }

    void Die()
    {
        isDead = true;
        WaveSpawner.EnemiesAlives--; // Противников живых убивают
        GameObject enemyImpactEffect = Instantiate(enemyEffect, transform.position,Quaternion.identity); // Создание еффекта противника
        PlayerStats.Money += value; // Прибавление денег
        Destroy(enemyImpactEffect,1f); // Уничтожается еффект противника
        Destroy(gameObject); // Уничтожается противник
    }
}
