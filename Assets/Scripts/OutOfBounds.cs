using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< Updated upstream
using UnityEngine.SceneManagement;

public class OutOfBounds : MonoBehaviour
{
    public CheckpointScript checkpointScript;

    // Start is called before the first frame update
    void Start()
    {
        checkpointScript = FindObjectOfType<CheckpointScript>();
=======

public class OutOfBounds : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
>>>>>>> Stashed changes
    }

    public void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Out of Bounds");
<<<<<<< Updated upstream

        // If a player reaches the out of bound area, it respawns according to its latest checkpoint's position and rotation
        if (collider.GetComponent<PlayerLapper>())
        {
            PlayerLapper playerLapper = collider.GetComponent<PlayerLapper>();

            collider.transform.position = checkpointScript.collectionObject.transform.GetChild(playerLapper.checkpointIndex).transform.position;
            collider.transform.rotation = checkpointScript.collectionObject.transform.GetChild(playerLapper.checkpointIndex).transform.rotation * Quaternion.Euler(0, -90, 0);
        }
=======
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
>>>>>>> Stashed changes
    }
}
