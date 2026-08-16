using UnityEngine;

public class PlatformManager : MonoBehaviour
{

    //stores all of the platform layouts that can be randomly selected for the endless generation
    [SerializeField] private GameObject[] platformPrefabs;

    //determines the position where a new platform set enters the level
    [SerializeField] private Transform spawnPoint;

    public void SpawnPlatform()
    {
        int randomIndex = Random.Range(0, platformPrefabs.Length);

        Instantiate(platformPrefabs[randomIndex], spawnPoint.position, Quaternion.identity);
    }
}