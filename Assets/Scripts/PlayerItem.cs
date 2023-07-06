using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItem : MonoBehaviour
{
    [SerializeField]
    private GameObject currentItem; // The currently held item

    public void ReceiveItem(GameObject itemPrefab)
    {
        if (currentItem != null)
        {
            // Discard the previous item if one is already held
            Destroy(currentItem);
        }

        currentItem = Instantiate(itemPrefab, transform);
        currentItem.transform.SetParent(transform); // Set the parent to the player's transform
        currentItem.SetActive(false); // Deactivate the item
    }

    public void UseItem()
    {
        if (currentItem != null)
        {
            // Activate the item
            currentItem.SetActive(true);

            // Call the appropriate method on the current item script
            Item currentItemScript = currentItem.GetComponent<Item>();
            if (currentItemScript != null)
            {
                currentItemScript.Use();
                currentItem = null;
            }
        }
    }
}