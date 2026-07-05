using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] platformPrefabs;
    public float platformSpawnTime = 6f;
    public float platformSpeed = 3f;

    private float timeUntilPlatformSpawn;
      
    private void Spawn()
    {
        GameObject platformToSpawn = platformPrefabs[Random.Range(0, platformPrefabs.Length)];

        GameObject spawnedPlatform = Instantiate(platformToSpawn, transform.position, Quaternion.identity);

        Rigidbody2D platformRB = spawnedPlatform.GetComponent<Rigidbody2D>();
        platformRB.linearVelocity = Vector2.left * platformSpeed;
    }

    private void SpawnLoop()
    {
        timeUntilPlatformSpawn += Time.deltaTime;

        if (timeUntilPlatformSpawn >= platformSpawnTime)
        {
            Spawn();
            timeUntilPlatformSpawn = 0f;
        }
    }

    private void Update()
    {
        SpawnLoop();
    }

}
