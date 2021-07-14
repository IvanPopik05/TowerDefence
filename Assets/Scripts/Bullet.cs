using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target; // Противник
    public float speed = 70f; // Скорость пули
    public int damage = 25; // Урон пули
    public float explosionRadius;
    public GameObject BulletImpactEffect; // Эффект взрыва пули
    public void Seek(Transform _target) // Ищем противника
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null) // Если пуля равна null
        {
            Destroy(gameObject); // То пуля уничтожается
            return;
        }
        Vector3 dir = target.position - transform.position; // Дистанция между противником и пулей
        float distanceThisFrame = speed * Time.deltaTime; // Скорость пули до дистанции противника
        if(dir.magnitude <= distanceThisFrame) // Если дистанция достигнута противника
        {
            HitTarget();  // Уничтожение цели
            return;
        }
        transform.Translate(dir.normalized * distanceThisFrame, Space.World); // Направление пули
        transform.LookAt(target);
    }
    void HitTarget()
    {
       GameObject effectInst = Instantiate(BulletImpactEffect, transform.position,transform.rotation); // Создание эффекта взрыва пули
       Destroy(effectInst, 0.45f); // Еффект уничтожается через 2 секунды
       if(explosionRadius > 0)
       {
           Explode();
       } else
       {
           Damage(target);
       }
       Destroy(gameObject); // Уничтожение пули
    }
    void Explode()
    {
       Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius); // Осколки от пули

       foreach (var collider in colliders)
       {
           if(collider.tag == "Enemy")
           {
               Damage(collider.transform);
           }
       }
    }
    void Damage(Transform enemy) // противник
    {
        Enemy e = enemy.GetComponent<Enemy>(); // Нахождение класса Enemy
        if(e != null) // Если противник не равен null
        {
            e.TakeDamage(damage); // Функцию добавляем
        }
    }
    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
