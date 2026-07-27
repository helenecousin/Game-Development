using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    [SerializeField] private GameObject[] platformPrefabs;
    [SerializeField] private Transform spawnPoint;

    public void SpawnPlatform()
    {
        int randomIndex = Random.Range(0, platformPrefabs.Length);

        Instantiate(platformPrefabs[randomIndex], spawnPoint.position, Quaternion.identity);
    }
}