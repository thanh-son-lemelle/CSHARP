using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Singleton instance
    public static GameController Instance { get; private set; }
    public Inventory inventory; // Reference to the Inventory system
    public InventoryUI inventoryUI; // Reference to the Inventory UI system
    public Player player; // Reference to the Player system
    public CharacterUI characterUI; // Reference to the Player system;
    public CharacterUIManager  characterUIManager; 
    public EnemyUIManager  enemyUIManager; 
    // public Enemy enemy; 

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

         // Initialize the player
        InitializePlayer();

        // Initialize Enemy
        // InitializeEnemy();
        // enemyUIManager.DisplayEnemies();



    }

    private void Start()
    {
        // Initialize the inventory with test items
        InitializeTestItems();       

        // Update the UI to reflect the new items
        UpdateInventoryUI();

        // characterUI.UpdateCharacterSprite(4);
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
        player = new Player();       
        // Add characters to the player's character list
        player.characters.Add(new Character("Hero1", 70, 100, 10, 5, 7, 1, 0, 100, 1));
        player.characters.Add(new Character("Hero2", 80, 50, 8, 4, 6, 1, 0, 100, 2));    
        player.characters.Add(new Character("Hero3", 50, 50, 8, 4, 6, 1, 0, 100, 3));    
        player.characters.Add(new Character("Hero4", 40, 50, 8, 4, 6, 1, 0, 100, 4));    

        // Debug to confirm that the player and characters are created
        Debug.Log("Player initialized with characters: " + player.characters.Count);
   }

//     public void InitializeEnemy()
//     {
//         enemy = new Enemy();       
//         // Add characters to the player's character list
//         enemy.enemies.Add(new Character("Enemy1", 10, 60, 10, 5, 7, 1, 0, 100, 1));
//         enemy.enemies.Add(new Character("Enemy2", 20, 40, 8, 4, 6, 1, 0, 100, 2));    

//         // Debug
//         Debug.Log("Enemy initialized with characters: " + enemy.enemies.Count);

//    }
}


