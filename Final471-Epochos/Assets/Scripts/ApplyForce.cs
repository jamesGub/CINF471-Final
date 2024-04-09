using UnityEngine;

public class ApplyForce : MonoBehaviour
{
    public float pushForce = 10f; // Adjust this value as needed

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with the player character
        if (collision.gameObject.CompareTag("Player"))
        {
            // Get the direction of the collision
            Vector3 pushDirection = collision.contacts[0].point - transform.position;
            pushDirection = -pushDirection.normalized;

            // Apply force to the box in the direction of the collision
            GetComponent<Rigidbody>().AddForce(pushDirection * pushForce, ForceMode.Impulse);
        }
    }
}
