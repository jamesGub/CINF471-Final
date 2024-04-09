using UnityEngine;

public class RockFallingController : MonoBehaviour
{
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false; // Start with gravity disabled
    }

    public void TriggerRockFall()
    {
        rb.useGravity = true; // Enable gravity
        // Optionally, add force to the rock for a more realistic fall
        rb.AddForce(Vector3.down * 10f, ForceMode.Impulse); // Adjust the force as needed
    }
}
