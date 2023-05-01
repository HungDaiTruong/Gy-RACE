using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointScript : MonoBehaviour
{
    public GameObject collectionObject;
    public int checkpointIndex;
    static private int checkpointNumber;

    // Start is called before the first frame update
    void Start()
    {
        collectionObject = transform.parent.gameObject;

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
        if(collider.GetComponent<PlayerLapper>())
        {
            PlayerLapper playerLapper = collider.GetComponent<PlayerLapper>();

            if (playerLapper.checkpointIndex == checkpointNumber - 1 && checkpointIndex == 0)
            {
                playerLapper.lap++;
                playerLapper.checkpointIndex = 0;
            }

            if (playerLapper.checkpointIndex == checkpointIndex + 1 || playerLapper.checkpointIndex == checkpointIndex - 1)
            {
                playerLapper.checkpointIndex = checkpointIndex;
            }
        }
    }
}
