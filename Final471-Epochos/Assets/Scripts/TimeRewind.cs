using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class TimeRewind : MonoBehaviour
{
    public bool isRewinding = false;
    public bool isPaused = false;
    public float timePauseDuration = 5f;
    List<PointInTime> pointsInTime;
    Rigidbody rb;
    float timePauseTimer;
    public TMP_Text countdownText;
    public TMP_Text rewindText; 
    void Start()
    {
        pointsInTime = new List<PointInTime>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartRewinding();
        }

        if (Input.GetKeyUp(KeyCode.R))
        {
            StopRewinding();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Paused!");
            TogglePause();
        }

        UpdateTimePauseTimer();
    }

    void FixedUpdate()
    {
        if (isRewinding)
            Rewind();
        else if (!isPaused)
            Record();
    }

    void Rewind()
    {
        if (pointsInTime.Count > 0)
        {
            PointInTime pointInTime = pointsInTime[0];
            transform.position = pointInTime.position;
            transform.rotation = pointInTime.rotation;
            pointsInTime.RemoveAt(0);
        }
        else
        {
            StopRewinding();
        }
    }

    void Record()
    {
        pointsInTime.Insert(0, new PointInTime(transform.position, transform.rotation));
    }

    public void StartRewinding()
    {
        isRewinding = true;
        rb.isKinematic = true;
        if (rewindText != null) { 
            rewindText.enabled = true; 
            rewindText.text = "Rewinding time..."; 
        }
        
    }

    public void StopRewinding()
    {
        isRewinding = false;
        rb.isKinematic = false;
        if(rewindText != null) { 
            rewindText.enabled = false; 
        }
    }

    void TogglePause()
    {
        if (!isPaused)
        {
            isPaused = true;
            GameObject[] objects = GameObject.FindGameObjectsWithTag("Freezable"); 
            foreach (GameObject obj in objects)  { 
                Rigidbody objRb = obj.GetComponent<Rigidbody>(); 
                if(objRb != null) { 
                    objRb.isKinematic = isPaused;
                }
            }
            if (isPaused) { 
                timePauseTimer = timePauseDuration;
            }
        
            StartCoroutine(CountdownAndResume());
        }
    }

    IEnumerator CountdownAndResume()
    {
        float timer = timePauseDuration;
        while (timer > 0)
        {
            countdownText.text = "Time Stopped: " + Mathf.CeilToInt(timer).ToString(); 
            yield return new WaitForSeconds(1f);
            timer -= 1f;
        }

        if (timer == 0) { 
            StopRewinding(); 
              if (countdownText != null) { 
                countdownText.enabled = false; 
            }
        }

        countdownText.text = "Time Freeze: 0"; 
        isPaused = false; 
    }

    void UpdateTimePauseTimer()
    {
        if (isPaused)
        {
            timePauseTimer -= Time.deltaTime;
        }
    }
}
