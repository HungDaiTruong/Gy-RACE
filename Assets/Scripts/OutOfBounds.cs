using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutOfBounds : MonoBehaviour
{
    public GameObject vehicle;
    public CheckpointScript checkpointScript;

    // Start is called before the first frame update
    void Start()
    {
        vehicle = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Out of Bounds");
        //UnityEditor.EditorApplication.isPlaying = false;
        //SceneManager.LoadScene("MenuScene");
        vehicle.transform.position = checkpointScript.collectionObject.transform.GetChild((CheckpointScript.count - 1) % 3).transform.position;
    }
}
