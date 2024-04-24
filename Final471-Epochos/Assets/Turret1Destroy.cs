using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret1Destroy : MonoBehaviour
{
    public GameObject objectToDestroy;
    void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("projectile"))
        {   
            Debug.Log("ProjHit");
       
            Destroy(objectToDestroy);
        }
    }
}
