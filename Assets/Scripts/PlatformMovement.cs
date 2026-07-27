using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 6f;
    [SerializeField] private float spawnX = 0f;
    [SerializeField] private float destroyX = -20f;

    private bool hasSpawnedNext = false;

    private PlatformManager platformManager;

    private void Start()
    {
        platformManager = FindAnyObjectByType<PlatformManager>();
    }

    private void Update()
    {
        // Moves the platform left
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        // Spawns the next platform
        if (!hasSpawnedNext && transform.position.x <= spawnX)
        {
            platformManager.SpawnPlatform();
            hasSpawnedNext = true;
        }

        // Destroys this platform when it is off-screen
        if (transform.position.x <= destroyX)
        {
            Destroy(gameObject);
        }
    }
}