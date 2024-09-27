using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventorySlotPrefab; // Assign this in the Unity Editor
    public Transform inventoryPanel; // The parent UI element to hold inventory slots

    public Sprite potionSprite; // Assign these sprites in the Unity Editor
    public Sprite weaponSprite;
    public Sprite keysSprite;
    public Sprite magicScrollSprite;

    private List<InventorySlot> slots = new List<InventorySlot>();

    public void UpdateUI(List<Item> items)
    {
        // Clear existing UI slots
        foreach (Transform child in inventoryPanel)
        {
            Destroy(child.gameObject);
        }

        int itemCount = Mathf.Max(items.Count, 20); // Ensure we have 20 slots to cover all cases

        for (int i = 0; i < itemCount; i++)
        {
            GameObject slot = Instantiate(inventorySlotPrefab, inventoryPanel);
            InventorySlot slotScript = slot.GetComponent<InventorySlot>();
            slotScript.Index = i; // Set index for each slot

            if (i < items.Count && items[i] != null)
            {
                InventoryItem itemUI = slot.GetComponentInChildren<InventoryItem>();
                itemUI.UpdateItem(items[i], this); // Pass `this` to access the sprites
                slotScript.currentItem = itemUI;
            }
            else
            {
                slotScript.currentItem = null; // Clear slot if no item exists
            }
        }
    }

    public void UpdateSlot(InventorySlot originalSlot, InventorySlot newSlot, InventoryItem draggedItem)
    {
        int originalIndex = originalSlot.Index;
        int newIndex = newSlot.Index;

        // Validate indices
        if (originalIndex < 0 || originalIndex >= GameController.Instance.inventory.itemList.Count ||
            newIndex < 0 || newIndex >= GameController.Instance.inventory.itemList.Count)
        {
            Debug.LogError($"Invalid slot index: OriginalIndex = {originalIndex}, NewIndex = {newIndex}");
            return;
        }

        // Swap items
        Item tempItem = GameController.Instance.inventory.itemList[originalIndex];
        GameController.Instance.inventory.itemList[originalIndex] = GameController.Instance.inventory.itemList[newIndex];
        GameController.Instance.inventory.itemList[newIndex] = tempItem;

        // Update slot indices
        GameController.Instance.inventory.itemList[originalIndex].SlotIndex = originalIndex;
        GameController.Instance.inventory.itemList[newIndex].SlotIndex = newIndex;

        Debug.Log($"Item moved from slot {originalIndex} to slot {newIndex}");

        // Update the UI
        UpdateUI(GameController.Instance.inventory.itemList);
    }
}
