using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    public GameObject[] items; // Array of item prefabs

    public void Interact()
    {
        // Generate a random item from the items array
        int randomIndex = Random.Range(0, items.Length);
        GameObject randomItem = items[randomIndex];

        // Instantiate the random item at the item box's position
        Instantiate(randomItem, transform.position, Quaternion.identity);
    }
}
