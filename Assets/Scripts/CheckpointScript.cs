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
        foreach (Transform g in transform.GetComponentsInChildren<Transform>())
        {
            g.GetComponent<BoxCollider>().enabled = false;
            checkpointNumber++;
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
            count = 0;
            lastCheckpoint.GetComponent<BoxCollider>().enabled = true;
            lapped = true;
            trigger = false;
        }

        if(count == 1 && lapped)
        {
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
            collectionObject.transform.GetChild(count-1).GetComponent<BoxCollider>().enabled = false;
            if (count < checkpointNumber)
            {
                collectionObject.transform.GetChild(count).GetComponent<BoxCollider>().enabled = true;
            }
        }
        Debug.Log("count : " + count + "lap : " + lap);
    }
}
