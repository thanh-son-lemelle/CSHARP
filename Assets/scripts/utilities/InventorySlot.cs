using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public Image icon; // Reference to the UI Image for the item icon
    public Text quantityText; // Reference to the UI Text for the item quantity
    public int Index { get; set; } // Index of the slot
    public InventoryItem currentItem;

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop method called.");

        InventoryItem draggedItem = eventData.pointerDrag.GetComponent<InventoryItem>();
        if (draggedItem != null)
        {
            Debug.Log("Inventory item found.");

            InventoryUI inventoryUI = FindObjectOfType<InventoryUI>();
            if (inventoryUI != null)
            {
                Debug.Log("Inventory UI found.");
                InventorySlot originalSlot = draggedItem.originalSlot;

                if (originalSlot != null)
                {
                    inventoryUI.UpdateSlot(originalSlot, this, draggedItem);
                }
                else
                {
                    Debug.LogError("Original slot not found.");
                }
            }
            else
            {
                Debug.LogError("Inventory UI not found.");
            }
        }
        else
        {
            Debug.LogError("Dragged item not found.");
        }
    }

    public void SetItem(Item item, InventoryUI inventoryUI)
    {
        InventoryItem inventoryItem = GetComponentInChildren<InventoryItem>();
        if (inventoryItem != null)
        {
            inventoryItem.UpdateItem(item, inventoryUI); // Update item in InventoryItem
        }
        else
        {
            Debug.LogWarning("No InventoryItem component found in slot.");
        }
    }

    public void ClearSlot()
    {
        if (icon != null)
        {
            icon.sprite = null;
            icon.enabled = false;
        }

        if (quantityText != null)
        {
            quantityText.text = "";
            quantityText.enabled = false;
        }
    }
}
