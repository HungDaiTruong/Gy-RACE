using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointScript : MonoBehaviour
{
    public GameObject vehicle;
    public GameObject collectionObject;
    public GameObject lastCheckpoint;
    public bool trigger = false;
    static public int lap = 0;
    static public int count = 0;
    static private int checkpointNumber;
    private bool lapped = false;

    // Start is called before the first frame update
    void Start()
    {
        vehicle = GameObject.FindGameObjectWithTag("Player");
        collectionObject = transform.parent.gameObject;

        // Count the child objects of the collectionObject
        checkpointNumber = collectionObject.transform.childCount;

        // Disable all the checkpoint colliders except the first one
        for (int i = 1; i < checkpointNumber; i++)
        {
            collectionObject.transform.GetChild(i).GetComponent<BoxCollider>().enabled = false;
        }
        collectionObject.transform.GetChild(0).GetComponent<BoxCollider>().enabled = true;
        lastCheckpoint = collectionObject.transform.GetChild(0).gameObject;

        vehicle.transform.position = lastCheckpoint.transform.position - new Vector3(-15f, 0, 0);
        vehicle.transform.rotation = Quaternion.Euler(0, -90f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(count == checkpointNumber)
        {
            lastCheckpoint.GetComponent<BoxCollider>().enabled = true;
            lapped = true;
            trigger = false;
        }

        if(count == 4 && lapped)
        {
            count = 1;
            lap++;
            lapped = false;
        }
    }

    public void OnTriggerExit(Collider collider)
    {
        if(collider.gameObject == vehicle && transform.parent != null)
        {
            count++;
            trigger = true;
            collectionObject.transform.GetChild((count - 1) % 3).GetComponent<BoxCollider>().enabled = false;
            collectionObject.transform.GetChild(count % 3).GetComponent<BoxCollider>().enabled = true;
        }
        Debug.Log("count : " + count + "lap : " + lap);
    }
}
