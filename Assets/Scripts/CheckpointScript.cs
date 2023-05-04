using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointScript : MonoBehaviour
{
<<<<<<< Updated upstream
    public int checkpointIndex;
    static public int checkpointNumber;
    public GameObject collectionObject;
=======
    public GameObject vehicle;
    public GameObject collectionObject;
    public GameObject lastCheckpoint;
    public bool trigger = false;
    static public int lap = 0;
    static public int count = 0;
    static private int checkpointNumber;
>>>>>>> Stashed changes

    // Start is called before the first frame update
    void Start()
    {
        collectionObject = transform.parent.gameObject;
<<<<<<< Updated upstream

        // Count the child objects of the collectionObject for the total amount of checkpoints
        checkpointNumber = collectionObject.transform.childCount;
        // Index of the checkpoint
        checkpointIndex = transform.GetSiblingIndex();

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = collectionObject.transform.GetChild(0).transform.position - new Vector3(-15f, 0, 0);
        player.transform.rotation = Quaternion.Euler(0, -90f, 0);
        player = GameObject.FindGameObjectWithTag("Player2");
        player.transform.position = collectionObject.transform.GetChild(0).transform.position - new Vector3(-15f, 0, -5f);
        player.transform.rotation = Quaternion.Euler(0, -90f, 0);
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
=======
        foreach (Transform g in transform.GetComponentsInChildren<Transform>())
        {
            g.GetComponent<BoxCollider>().enabled = false;
            checkpointNumber++;
        }
        collectionObject.transform.GetChild(0).GetComponent<BoxCollider>().enabled = true;
        lastCheckpoint = collectionObject.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(count == checkpointNumber)
        {
            count = 0;
            lastCheckpoint.GetComponent<BoxCollider>().enabled = true;
            lap++;
            trigger = false;
        }
    }

    public void OnTriggerExit(Collider collider)
    {
        if(collider.gameObject == vehicle && transform.parent != null)
        {
            count++;
            trigger = true;
            collectionObject.transform.GetChild(count-1).GetComponent<BoxCollider>().enabled = false;
            if (count < checkpointNumber)
            {
                collectionObject.transform.GetChild(count).GetComponent<BoxCollider>().enabled = true;
            }
        }
        Debug.Log("count : " + count + "lap : " + lap);
>>>>>>> Stashed changes
    }
}
