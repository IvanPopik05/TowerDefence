using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turrent : MonoBehaviour
{
    public Transform target; // Противник
    private Enemy targetEnemy;
    public Transform RayPoint; // Точка луча

    [Header("General")]
    public float range = 9f; // Дистанция пушки

    [Header("Use Bullets (По умолчанию)")]
    public GameObject BulletPrefab; // Пули
    public float FireRate = 0.5f; // Скорострельность пули
    public float FireCountDown = 0f; // Обратный отсчёт пули

    [Header("Use Lazer")]
    public bool useLazer = true; // Лазер включён
    public LineRenderer lineRenderer; // Линия лазера
    public ParticleSystem LazerEffectParticles; // Еффект лазера
    public Light ImpactLightLazer; // Свет лазера
    public int damageOverTime = 30; // Урон с течением времени
    public float slowPct = 0.7f;

    [Header("Edditional options")]
    public Transform PartToRotate; // часть поворота пушки
    public float turnSpeed = 10f; // Скорость поворота пушки
    public string enemyTag = "Enemy"; // Нахождение противников по тегу
    public Transform firePoint; // Позиция пули
    void Start()
    {
        InvokeRepeating("UpdateTarget",0f,0.3f); // метод, запуск оборудования, запуск снаряда
    }
    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag); // Поиск противников по тегу
        float shortestDistance = Mathf.Infinity; // Самая короткая дистанция
        GameObject nearestEnemy = null; //Самый ближайший противник
        
        foreach (GameObject enemy in enemies)
        {
            float DistanceToEnemy = Vector3.Distance(transform.position,enemy.transform.position); // Дистанция между пушкой и противником
            if(DistanceToEnemy < shortestDistance)
            {
                shortestDistance = DistanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if(nearestEnemy != null && shortestDistance <= range) //  Поиск противника
        {
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<Enemy>();
        } else
        {
            target = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null) // Если противник не найден
        {
            if(useLazer)
            {
                if(lineRenderer.enabled)
                {
                    LazerEffectParticles.Stop(); // Останавливается еффект лазера
                    lineRenderer.enabled = false; // Линия лазаер отключается
                    ImpactLightLazer.enabled = false; // Свет лазера отключён
                }
            }
            return;
        }

        LockOnTarget();

        if(useLazer)
        {
            Lazer();
        } else
        {
            if(FireCountDown <= 0) // Проверяем обратный отсчёт атаки
            {
                Shoot(); // Атакуем
                FireCountDown = 1f * FireRate;
            }
            FireCountDown -= Time.deltaTime;
        }
    }

    void LockOnTarget()
    {
        Vector3 dir = target.position - transform.position; // Дистанция от противника до пушки
        Quaternion lookRotation = Quaternion.LookRotation(dir); //  Просмотр противника пушкой
        Vector3 rotation = Quaternion.Lerp(PartToRotate.rotation,lookRotation, Time.deltaTime * turnSpeed).eulerAngles; // Задаём поворот пушке
        PartToRotate.rotation = Quaternion.Euler(0f,rotation.y,0f); //Втсавляем поворот пушки к противнику
    }
    void Lazer()
    {
        targetEnemy.TakeDamage(damageOverTime * Time.deltaTime);
        targetEnemy.Slow(slowPct);

        if(!lineRenderer.enabled)
        {
            LazerEffectParticles.Play(); // Еффект лазера включён
            lineRenderer.enabled = true; // Лазер включён
            ImpactLightLazer.enabled = true; // Свет лазера включён
        }
        lineRenderer.SetPosition(0, firePoint.position); // Позиция точки начала лазера
        lineRenderer.SetPosition(1, target.position); // Позиция лазера до противника

        Vector3 dir = firePoint.position - target.position;
        LazerEffectParticles.transform.position = target.position + dir.normalized;
        LazerEffectParticles.transform.rotation = Quaternion.LookRotation(dir);
    }
    private void Shoot()
    {
        GameObject bulletGo = (GameObject)Instantiate(BulletPrefab,firePoint.position,firePoint.rotation); // Создаём пулю
        Bullet bullet = bulletGo.GetComponent<Bullet>(); // Файл с движением пули

        if(bullet != null) // Если пуля не равна null
        {
            bullet.Seek(target); // ищет противника
        } else
        {
        }
        Debug.Log("HeadShot");
    }
    private void RayTransform()
    {
        Ray ray = new Ray(RayPoint.position,target.position);
        Debug.DrawLine(RayPoint.position, target.position,Color.red);
    }
    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.yellow; // Цвет дистанции
        Gizmos.DrawWireSphere(transform.position,range); // начальная позиция дистанции и радиус
    }
}
