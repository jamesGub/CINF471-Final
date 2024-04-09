using UnityEngine;

public class FallController : MonoBehaviour
{
    public GameObject rock;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Overlap Detected");
            if (rock != null)
            {
                RockFallingController rockFallingController = rock.GetComponent<RockFallingController>();
                if (rockFallingController != null)
                {
                    rockFallingController.TriggerRockFall();
                }
            }
        }
    }
}
