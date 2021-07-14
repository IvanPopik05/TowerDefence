using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    private Transform target; // Противник
    private int wavepointIndex = 0;
    private Enemy enemy;

    private void Start() {
        enemy = GetComponent<Enemy>();
        target = WayPoints.points[0];
    }

    private void Update() {
        Vector3 dir = (target.position - transform.position);
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime,Space.World);

        if(Vector3.Distance(transform.position,target.position) <= 1f)
        {
            GetNextWayPoints();
        }
        enemy.speed = enemy.startSpeed;
    }
    void GetNextWayPoints()
    {
        if(wavepointIndex == WayPoints.points.Length - 1) 
        {
            EndPath();
            return;
        }
        wavepointIndex ++;
        target = WayPoints.points[wavepointIndex];
    }
    void EndPath()
    {
        WaveSpawner.EnemiesAlives--; // Противников живых уничтожают
        PlayerStats.Lives --; // Отнимание жизней
        Destroy(gameObject); // Уничтожается противник
    }
}
