using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public Transform[] checkpoints; 
    private Transform currentCheckpoint; 
    void Start()
    {
        currentCheckpoint = checkpoints[0]; 
    }

    public void SetCheckpoint(Transform checkpoint)
    {
        currentCheckpoint = checkpoint;
    }

    public Transform GetCheckpoint()
    {
        return currentCheckpoint;
    }
}
