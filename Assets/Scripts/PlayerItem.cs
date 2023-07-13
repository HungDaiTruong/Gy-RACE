using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerItem : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> currentItems = new List<GameObject>(); // List to store the currently held items
    private bool canUseItem = false; // Flag to indicate if the player can use the item

    public Image firstItemSlotImage; // Reference to the first item slot's Image component
    public Image secondItemSlotImage; // Reference to the second item slot's Image component
    public Sprite defaultItemSlotImage; // Default image for the item slots
    public List<Sprite> allItemImages; // List of all available item images

    private void Start()
    {
        UpdateItemSlotImages();
    }

    public void ReceiveItem(GameObject itemPrefab)
    {
        if (currentItems.Count < 2)
        {
            StartCoroutine(RandomizeItemImage());

            GameObject newItem = Instantiate(itemPrefab, transform);
            newItem.transform.SetParent(transform); // Set the parent to the player's transform
            newItem.SetActive(false); // Deactivate the item
            currentItems.Add(newItem);
        }
    }

    public void UseItem()
    {
        if (currentItems.Count > 0 && canUseItem)
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

            UpdateItemSlotImages();
        }
    }

    private IEnumerator RandomizeItemImage()
    {
        canUseItem = false;

        // Randomize the item image for the first second
        float startTime = Time.time;
        Image itemSlotImage = (currentItems.Count == 0) ? firstItemSlotImage : secondItemSlotImage;
        if (itemSlotImage != null)
        {
            while (Time.time - startTime < 1f)
            {
                itemSlotImage.sprite = GetRandomItemSprite();
                yield return null;
            }

            canUseItem = true;
        }

        UpdateItemSlotImages();
    }

    private Sprite GetRandomItemSprite()
    {
        if (allItemImages.Count > 0)
        {
            int randomIndex = Random.Range(0, allItemImages.Count);
            return allItemImages[randomIndex];
        }

        return defaultItemSlotImage;
    }

    private void UpdateItemSlotImages()
    {
        if (firstItemSlotImage != null)
        {
            if (currentItems.Count > 0)
            {
                // Set the image of the first item slot to the image of the first item
                Item firstItem = currentItems[0].GetComponent<Item>();
                if (firstItem != null && firstItem.itemImage != null)
                {
                    firstItemSlotImage.sprite = firstItem.itemImage;
                }
            }
            else
            {
                // Set the image of the first item slot to the default image
                firstItemSlotImage.sprite = defaultItemSlotImage;
            }
        }

        if (secondItemSlotImage != null)
        {
            if (currentItems.Count > 1)
            {
                // Set the image of the second item slot to the image of the second item
                Item secondItem = currentItems[1].GetComponent<Item>();
                if (secondItem != null && secondItem.itemImage != null)
                {
                    secondItemSlotImage.sprite = secondItem.itemImage;
                }
            }
            else
            {
                // Set the image of the second item slot to the default image
                secondItemSlotImage.sprite = defaultItemSlotImage;
            }
        }
    }
}
