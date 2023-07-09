using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItem : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> currentItems = new List<GameObject>(); // List to store the currently held items
    private bool canUseItem = true; // Flag to indicate if the player can pick up items

    public void ReceiveItem(GameObject itemPrefab)
    {
        if (currentItems.Count < 2)
        {
            GameObject newItem = Instantiate(itemPrefab, transform);
            newItem.transform.SetParent(transform); // Set the parent to the player's transform
            newItem.SetActive(false); // Deactivate the item
            currentItems.Add(newItem);

            StartCoroutine(RandomizeItems());
        }
    }

    public void UseItem()
    {
        if (currentItems.Count > 0)
        {
            GameObject itemToUse = currentItems[0];
            currentItems.RemoveAt(0);

            // Activate the item
            itemToUse.SetActive(true);

            // Call the appropriate method on the item's script
            Item itemScript = itemToUse.GetComponent<Item>();
            if (itemScript != null)
            {
                itemScript.Use();
            }
        }
    }

    private IEnumerator RandomizeItems()
    {
        canUseItem = false;

        yield return new WaitForSeconds(1f); // Wait for 1 second

        canUseItem = true;
    }
}
