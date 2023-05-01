using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLapper : MonoBehaviour
{
    public int lap;
    public int checkpointIndex;

    // Start is called before the first frame update
    void Start()
    {
        // The vehicule's own laps and checkpoints counts
        lap = 1;
        checkpointIndex = 0;
    }
}
