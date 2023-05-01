using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutOfBounds : MonoBehaviour
{
    public CheckpointScript checkpointScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Out of Bounds");

        if (collider.GetComponent<PlayerLapper>())
        {
            PlayerLapper playerLapper = collider.GetComponent<PlayerLapper>();

            collider.transform.position = checkpointScript.collectionObject.transform.GetChild(playerLapper.checkpointIndex).transform.position;
            collider.transform.rotation = checkpointScript.collectionObject.transform.GetChild(playerLapper.checkpointIndex).transform.rotation * Quaternion.Euler(0, -90, 0);
        }
    }
}
