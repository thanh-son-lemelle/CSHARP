using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> itemList = new List<Item>();
    private const int MaxSlots = 20; // Fixed number of slots

    private void Awake()
    {
        InitializeInventory();
    }

    // Initialize the inventory with default empty slots
    public void InitializeInventory()
    {
        itemList.Clear(); // Clear any existing items

        for (int i = 0; i < MaxSlots; i++)
        {
            itemList.Add(new Item(null, null, ItemType.Potion, 0, i)); // Creating empty slots
        }
    }

    // Add an item to the inventory
    public void AddItem(Item item)
    {
        // Check if the item already exists and update its quantity if so
        Item existingItem = itemList.Find(i => i.Name == item.Name);
        if (existingItem != null)
        {
            existingItem.Quantity += item.Quantity;
            Debug.Log(item.Name + " quantity updated to: " + existingItem.Quantity);
        }
        else
        {
            // Find the first empty slot index
            int emptySlotIndex = GetEmptySlotIndex();
            if (emptySlotIndex != -1)
            {
                item.SlotIndex = emptySlotIndex;
                itemList[emptySlotIndex] = item; // Place item in the empty slot
                Debug.Log(item.Name + " added to inventory with slot " + item.SlotIndex);
            }
            else
            {
                Debug.LogWarning("No empty slots available for new item: " + item.Name);
            }
        }

        // Notify GameController to update UI
        if (GameController.Instance != null)
        {
            GameController.Instance.UpdateInventoryUI();
        }
        else
        {
            Debug.LogWarning("GameController instance not found! UI not updated.");
        }
    }

    // Remove an item from the inventory
    public void RemoveItem(Item item)
    {
        if (itemList.Contains(item))
        {
            int slotIndex = item.SlotIndex;
            itemList[slotIndex] = new Item(null, null, ItemType.Potion, 0, slotIndex); // Clear the slot
            Debug.Log(item.Name + " removed from inventory.");
        }
        else
        {
            Debug.LogWarning("Item not found in inventory: " + item.Name);
        }

        // Notify GameController to update UI
        if (GameController.Instance != null)
        {
            GameController.Instance.UpdateInventoryUI();
        }
        else
        {
            Debug.LogWarning("GameController instance not found! UI not updated.");
        }
    }

    // Find the first empty slot index
    private int GetEmptySlotIndex()
    {
        for (int i = 0; i < MaxSlots; i++)
        {
            if (itemList[i].Quantity == 0) // Check if the slot is empty
            {
                return i;
            }
        }
        return -1; // No empty slots available
    }
}
