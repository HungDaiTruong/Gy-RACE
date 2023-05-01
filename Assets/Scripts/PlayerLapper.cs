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
        lap = 1;
        checkpointIndex = 0;
    }
}
