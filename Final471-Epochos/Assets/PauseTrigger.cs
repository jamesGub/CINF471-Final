using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PauseTrigger : MonoBehaviour
{
    public GameObject panelObject;
    public float pauseDuration = 2f;

    private bool panelVisible = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !panelVisible)
        {
            // Show the panel
            panelObject.SetActive(true);
            panelVisible = true;

            // Pause the game
            Time.timeScale = 0f;

            // Wait for the specified duration
            StartCoroutine(ResumeAfterDelay(pauseDuration));
   
        }
    }

    IEnumerator ResumeAfterDelay(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);

        // Resume the game
        Time.timeScale = 1f;

        // Hide the panel
        panelObject.SetActive(false);
        panelVisible = false;
        Destroy(gameObject);
    }
}