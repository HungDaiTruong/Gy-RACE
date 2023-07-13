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
        checkpointScript = FindObjectOfType<CheckpointScript>();
    }

    public void OnTriggerEnter(Collider collider)
    {
        // If a player reaches the out of bound area, it respawns according to its latest checkpoint's position and rotation
        if (collider.GetComponent<PlayerLapper>())
        {
            PlayerLapper playerLapper = collider.GetComponent<PlayerLapper>();
            PlayerLocomotion playerLocomotion = collider.GetComponent<PlayerLocomotion>();

            collider.transform.position = checkpointScript.collectionObject.transform.GetChild(playerLapper.checkpointIndex).transform.position;
            collider.transform.rotation = checkpointScript.collectionObject.transform.GetChild(playerLapper.checkpointIndex).transform.rotation * Quaternion.Euler(0, -90, 0);

            playerLocomotion.realSpeed /= 2f;
            playerLocomotion.currentSpeed /= 2f;
        }
    }
}
