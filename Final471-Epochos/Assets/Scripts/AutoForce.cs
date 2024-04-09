using UnityEngine;

public class AutoForce : MonoBehaviour
{
    public Vector3 forceDirection = Vector3.forward; 
    public float forceMagnitude = 10f; 
    private bool appliedForce = false;

   
    private void ApplyForce()
    {
        if (!appliedForce)
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(forceDirection.normalized * forceMagnitude, ForceMode.Impulse);
                appliedForce = true;
            }
            else
            {
                Debug.LogWarning("No Rigidbody found on object. Please add a Rigidbody component.");
            }
        }
    }


    private void Start()
    {
        ApplyForce();
    }
}