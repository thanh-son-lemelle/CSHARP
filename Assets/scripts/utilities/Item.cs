using UnityEngine;

[System.Serializable]
public enum ItemType
{
    Potion,
    Weapon,
    Keys,
    MagicScroll
}

[System.Serializable]
public class Item
{
    // public string Name { get; set; }
    // public string Effect { get; set; }
    // public ItemType Type { get; set; }
    // public int Quantity { get; set; }
    // public int SlotIndex { get; set; }

    public string Name ;
    public string Effect ;
    public ItemType Type ;
    public int Quantity ;
    public int SlotIndex ;

    public Item(string name, string effect, ItemType type, int quantity, int slotIndex = -1)
    {
        Name = name;
        Effect = effect;
        Type = type;
        Quantity = quantity;
        SlotIndex = slotIndex;
    }
    
}
