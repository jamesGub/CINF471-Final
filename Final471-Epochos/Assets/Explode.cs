using UnityEngine;

public class Explode : MonoBehaviour
{
    public GameObject explosionPrefab; 

    void OnCollisionEnter(Collision collision)
    {
        Instantiate(explosionPrefab, collision.contacts[0].point, Quaternion.identity);

        Destroy(gameObject);
    }
}