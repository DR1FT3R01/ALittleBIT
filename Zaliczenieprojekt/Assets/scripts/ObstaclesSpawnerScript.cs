using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesSpawnerScript : MonoBehaviour
{
    public List<GameObject> obstaclesToSpawn;
    //public GameObject obstacleVariant;
    public float spawnRate = 5;
    private float timer;
    public bool alwaysSpawn = true;

    void Start()
    {
        spawnObstacle();
    }
    void Update()
    {
        if (timer < spawnRate)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            spawnObstacle();
            timer = 0;
        }
    }
    void spawnObstacle()
    {
        int randomObstacleVariant = Random.Range(0, obstaclesToSpawn.Count);
        
        if (alwaysSpawn)
        {
        GameObject obstacleVariant = obstaclesToSpawn[randomObstacleVariant];
        Instantiate(obstacleVariant, transform.position, transform.rotation);
        }
    }

}

