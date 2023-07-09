using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    public GameObject[] itemPrefabs; // Array of item prefabs to choose from
    public float disableDuration = 5f; // Duration to disable the item box in seconds

    private bool isTaken = false; // Flag to track if the item box is taken

    private Collider boxCollider;
    private Renderer boxRenderer;

    private void Awake()
    {
        boxCollider = GetComponent<Collider>();
        boxRenderer = GetComponent<Renderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isTaken) return; // Exit if the item box is already taken

        if (other.CompareTag("Player") || other.CompareTag("Player2") || other.CompareTag("AI")) // Check if the collider belongs to the player or AI opponent
        {
            PlayerItem playerItem = other.GetComponent<PlayerItem>();
            if (playerItem != null)
            {
                GameObject randomItemPrefab = itemPrefabs[Random.Range(0, itemPrefabs.Length)];
                playerItem.ReceiveItem(randomItemPrefab);
            }

            isTaken = true;
            boxCollider.enabled = false;
            boxRenderer.enabled = false;

            // Start coroutine to enable the item box after a delay
            StartCoroutine(EnableItemBoxAfterDelay());
        }
    }

    private IEnumerator EnableItemBoxAfterDelay()
    {
        yield return new WaitForSeconds(disableDuration);

        isTaken = false;
        boxCollider.enabled = true;
        boxRenderer.enabled = true;
    }
}
