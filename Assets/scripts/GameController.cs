using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Singleton instance
    public static GameController Instance { get; private set; }

    public Inventory inventory; // Reference to the Inventory system
    public InventoryUI inventoryUI; // Reference to the Inventory UI system

    public Player player; // Reference to the Player system
    public CharacterUI characterUI; // Reference to the Player system

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

        // Initialize the player
        InitializePlayer();

        // Update the UI to reflect the new items
        UpdateInventoryUI();

        Debug.Log("Start method called.");
    if (characterUI == null)
    {
        Debug.LogError("characterUI is not assigned in the GameController.");
        return; // Stop execution if characterUI is not assigned
    }

    else {

            Debug.LogError("GOOD");
    }

    characterUI.SetCharacterActive(true);

        characterUI.UpdateCharacterSprite(2);
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
    
    public void InitializePlayer()
    {
        // Ensure player is initialized
        if (player == null)
        {
            player = new Player(); // Initialize the player if it's null
        }

        // Create a GameObject for each character
        GameObject heroObject1 = new GameObject("HeroObject1");
        GameObject heroObject2 = new GameObject("HeroObject2");
        GameObject heroObject3 = new GameObject("HeroObject3");
        GameObject heroObject4 = new GameObject("HeroObject4");

        // Add the Character component to the GameObjects and initialize them
        Character hero1 = heroObject1.AddComponent<Character>();
        hero1.Initialize("Hero1", 100, 100, 10, 5, 7, 1, 0, 100, 1);
        Character hero2 = heroObject2.AddComponent<Character>();
        hero2.Initialize("Hero2", 80, 50, 8, 4, 6, 1, 0, 100, 2);
        Character hero3 = heroObject3.AddComponent<Character>();
        hero3.Initialize("Hero3", 60, 60, 8, 4, 6, 1, 0, 100, 3);
        Character hero4 = heroObject4.AddComponent<Character>();
        hero4.Initialize("Hero4", 45, 40, 8, 4, 6, 1, 0, 100, 4);
     
        // Add characters to the player's character list
        player.characters.Add(hero1);
        player.characters.Add(hero2);
        player.characters.Add(hero3);
        player.characters.Add(hero4);

        // Debug log to confirm that the player and characters are created
        Debug.Log("Player initialized with characters: " + player.characters.Count);
    }

    public void SwitchCharacter(int newCharacterID)
{
    // Update to the new character
    characterUI.UpdateCharacterSprite(newCharacterID);
}


}


