using UnityEngine;

public class DestroyProj : MonoBehaviour
{
    public float delay = 5.0f; // Time in seconds before the object is destroyed

    void Start()
    {
        // Schedule the object for destruction after the delay
        Destroy(gameObject, delay);
    }
}
