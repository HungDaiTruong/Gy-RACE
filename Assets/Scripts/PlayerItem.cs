using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItem : MonoBehaviour
{
    private GameObject currentItem; // The currently held item

    public void ReceiveItem(GameObject itemPrefab)
    {
        if (currentItem != null)
        {
            // Discard the previous item if one is already held
            Destroy(currentItem);
        }

        currentItem = Instantiate(itemPrefab, transform);
    }

    public void UseItem()
    {
        if (currentItem != null)
        {
            // Call the appropriate method on the current item script
            Item currentItemScript = currentItem.GetComponent<Item>();
            if (currentItemScript != null)
            {
                currentItemScript.Use();
            }

            // Discard the item after using it
            Destroy(currentItem);
        }
    }
}
