using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    //the normal speed at which this platform set moves towards the left
    [SerializeField] private float moveSpeed = 6f;

    // the X position at which this platform set creates the next platform
    [SerializeField] private float spawnX = 0f;

    // once the platform reaches this X position, it is far enough off-screen
    //that it can be destroyed to prevent unnecessary objects from remaining
    //in the scene
    [SerializeField] private float destroyX = -20f;


    private bool hasSpawnedNext = false;

    private PlatformManager platformManager;

    private void Start()
    {
        platformManager = FindAnyObjectByType<PlatformManager>();
    }

    private void Update()
    {
        if (!GameManager.Instance.isPlaying)
        {
            return;
        }
        
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