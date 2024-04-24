using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab of the projectile to be launched
    public Transform spawnPoint; // Point where the projectile will spawn
    public float shootInterval = 2.0f; // Time interval between shots
    public float projectileSpeed = 10.0f; // Speed of the projectile
    public float detectionRange = 10.0f; // Range to detect the player
    private Transform playerTransform; // Reference to the player's transform
    private float elapsedTime = 0.0f; // Time elapsed since the last shot
    public AudioSource audioSource;

    void Start()
    {
        // Find the player object by tag "Player"
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

   void Update()
{
    // Check if the player is within detection range
    if (Vector3.Distance(transform.position, playerTransform.position) <= detectionRange)
    {
        // Calculate direction to the player
        Vector3 directionToPlayer = playerTransform.position - transform.position;
        directionToPlayer.y = 0.0f; // Keep the direction horizontal

        // Rotate towards the player
        Quaternion lookRotation = Quaternion.LookRotation(directionToPlayer);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 2.0f);

        // Check if it's time to shoot
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= shootInterval)
        {
            Shoot();
            elapsedTime = 0.0f;
        }
    }
}

    void Shoot()
    {
        // Instantiate the projectile at the spawn point
        GameObject projectile = Instantiate(projectilePrefab, spawnPoint.position, spawnPoint.rotation);

        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.Play();
        }
        
        // Set the projectile's velocity
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb)
        {
            rb.velocity = spawnPoint.forward * projectileSpeed;
        }
    }
}
