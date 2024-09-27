using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Singleton instance
    public static GameController Instance { get; private set; }

    public Inventory inventory; // Reference to the Inventory system
    public InventoryUI inventoryUI; // Reference to the Inventory UI system

    private void Awake()
    {
        // If an instance already exists and it's not this one, destroy this GameObject
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // Set the instance to this instance
        Instance = this;

    }

    private void Start()
    {
        // Initialize the inventory with test items
        InitializeTestItems();

        // Update the UI to reflect the new items
        UpdateInventoryUI();
    }

    // Method to add some test items to the inventory
    private void InitializeTestItems()
    {
        // Create some test items
        Item healthPotion = new Item("Health Potion", "Restores 50 HP", ItemType.Potion, 1);
        Item sword = new Item("Sword", "A sharp blade", ItemType.Weapon, 1);
        Item key = new Item("Key", "Unlocks doors", ItemType.Keys, 1);
        Item magicScroll = new Item("Magic Scroll", "Contains powerful spells", ItemType.MagicScroll, 2);

        // Add the items to the inventory
        inventory.AddItem(healthPotion);
        inventory.AddItem(sword);
        inventory.AddItem(key);
        inventory.AddItem(magicScroll);
    }

    public void UpdateInventoryUI()
    {
        if (inventoryUI != null && inventory != null)
        {
            inventoryUI.UpdateUI(inventory.itemList);
        }
        else
        {
            Debug.LogError("InventoryUI or Inventory not set.");
        }
    }
}