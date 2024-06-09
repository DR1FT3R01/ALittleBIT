using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawnerScript : MonoBehaviour
{
    public List<GameObject> platformToSpawn;
    //public GameObject platformVariant;
    public float spawnRate = 2;
    private float timer;
    public bool alwaysSpawn = true;

    void Start()
    {
        spawnPlatform();
    }
    void Update()
    {
        if (timer < spawnRate)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            spawnPlatform();
            timer = 0;
        }
    }
    void spawnPlatform()
    {
        int randomPlatformVariant = Random.Range(0, platformToSpawn.Count);
        //int obstacleVariant = 0;

        if (alwaysSpawn)
        {
            GameObject platformVariant = platformToSpawn[randomPlatformVariant];
            Instantiate(platformVariant, transform.position, transform.rotation);
        }
    }

}

