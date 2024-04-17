using UnityEngine;

public class RotatingPlatform : MonoBehaviour
{
    public float rotationSpeed = 30f;
    private TimeRewind timeRewindScript;

    void Start()
    {
        timeRewindScript = FindObjectOfType<TimeRewind>();
    }

    void Update()
    {
        if (!timeRewindScript.isPaused)
        {
            transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
        }
    }
}
