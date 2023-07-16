using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointScript : MonoBehaviour
{
    public int checkpointIndex;
    static public int checkpointNumber;
    public GameObject collectionObject;

    private void Awake()
    {
        // Parent object of all checkpoints
        collectionObject = transform.parent.gameObject;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Count the child objects of the collectionObject for the total amount of checkpoints
        checkpointNumber = collectionObject.transform.childCount;
        // Index of the checkpoint
        checkpointIndex = transform.GetSiblingIndex();

        SpawnPlayers();

        foreach (PlayerNavMesh pNM in FindObjectsOfType<PlayerNavMesh>())
        {
            pNM.SpawnNavMeshes();
        }
    }

    public void OnTriggerEnter(Collider collider)
    {
        // If a player crosses the checkpoint
        if(collider.GetComponent<PlayerLapper>())
        {
            PlayerLapper playerLapper = collider.GetComponent<PlayerLapper>();

            // If enough checkpoints are crossed when the first checkpoint is reached, a lap is counted
            if (playerLapper.checkpointIndex == checkpointNumber - 1 && checkpointIndex == 0)
            {
                playerLapper.lap++;
                playerLapper.checkpointIndex = 0;
            }

            // If the players cross the checkpoint before or after their current ones, the index updates to ensure the right order
            if (playerLapper.checkpointIndex == checkpointIndex + 1 || playerLapper.checkpointIndex == checkpointIndex - 1)
            {
                playerLapper.checkpointIndex = checkpointIndex;
            }
        }
    }

    // Spawns the Players at a certain location behind the first checkpoint
    public void SpawnPlayers()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = collectionObject.transform.GetChild(0).transform.position
                + (collectionObject.transform.GetChild(0).transform.right.normalized * 5f)
                - (collectionObject.transform.GetChild(0).transform.forward.normalized * 3f);
        player.transform.rotation = collectionObject.transform.GetChild(0).transform.rotation * Quaternion.Euler(0, -90, 0);

        // Spawn location of Player Two
        if (GameObject.FindGameObjectWithTag("Player2") != null)
        {
            player = GameObject.FindGameObjectWithTag("Player2");
            player.transform.position = collectionObject.transform.GetChild(0).transform.position
                + (collectionObject.transform.GetChild(0).transform.right.normalized * 10f);
            player.transform.rotation = collectionObject.transform.GetChild(0).transform.rotation * Quaternion.Euler(0, -90, 0);
        }
    }
}
