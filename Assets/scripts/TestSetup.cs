using UnityEngine;

public class TestSetup : MonoBehaviour
{
    public Inventory inventory;
    public GameController gameController;

    private void Start()
    {
        // Create and add test items
        Item healthPotion = new Item("Health Potion", "Restores 50 HP", ItemType.Potion, 1);
        Item sword = new Item("Sword", "A sharp blade", ItemType.Weapon, 1);
        Item key = new Item("Key", "Unlocks doors", ItemType.Keys, 1);
        Item magicScroll = new Item("Magic Scroll", "Contains powerful spells", ItemType.MagicScroll, 1);

        inventory.AddItem(healthPotion);
        inventory.AddItem(sword);
        inventory.AddItem(key);
        inventory.AddItem(magicScroll);

        // Trigger UI update
        gameController.UpdateInventoryUI();
    }
}