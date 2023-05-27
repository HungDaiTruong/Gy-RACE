using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItem : MonoBehaviour
{
    // Add variables for bomb, laser, and shield

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            // Get the item's script component
            Item item = other.GetComponent<Item>();

            // Check the type of item and perform the corresponding action
            switch (item.itemType)
            {
                case ItemType.Bomb:
                    // TODO: Handle bomb item
                    break;
                case ItemType.Laser:
                    // TODO: Handle laser item
                    break;
                case ItemType.Shield:
                    // TODO: Handle shield item
                    break;
            }

            // Destroy the item object
            Destroy(other.gameObject);
        }
    }
}
