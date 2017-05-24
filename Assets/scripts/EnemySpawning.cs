using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    public Combat player;      
    public GameObject enemy;               
    public float spawnTime = 10f;
    public float spawnRate;
    public Transform[] spawnPoints;       


    void Start()
    {
      
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }


    void Spawn()
    {
        
        if (player.health <= 0f)
        {
            
            return;
        }

        
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        
        enemy.SetActive(true);
        Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        enemy.SetActive(false);
    }
}