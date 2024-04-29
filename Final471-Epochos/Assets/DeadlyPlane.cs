using UnityEngine;
using UnityEngine.SceneManagement;
public class DeadlyPlane : MonoBehaviour
{

    public string sceneName;
    private void OnTriggerEnter(Collider other)
    {
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
