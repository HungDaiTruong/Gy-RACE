using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    public GameObject[] itemPrefabs; // Array of item prefabs to choose from

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Player2") || other.CompareTag("AI")) // Check if the collider belongs to the player or AI opponent
        {
            PlayerItem playerItem = other.GetComponent<PlayerItem>();
            if (playerItem != null)
            {
                GameObject randomItemPrefab = itemPrefabs[Random.Range(0, itemPrefabs.Length)];
                playerItem.ReceiveItem(randomItemPrefab);
            }

            // Destroy the item box
            Destroy(gameObject);
        }
    }
}
