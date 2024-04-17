using UnityEngine;
using UnityEngine.SceneManagement;
public class DeadlyPlane : MonoBehaviour
{

    public string sceneName;
    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is the player
        if (other.CompareTag("Player"))
        {
            KillPlayer(other.gameObject);
        }
    }

    private void KillPlayer(GameObject player)
    {
        SceneManager.LoadScene(sceneName); 
        Destroy(player);
    }
}
