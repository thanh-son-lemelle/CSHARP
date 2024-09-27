using UnityEngine;

public enum ItemType
{
    Potion,
    Weapon,
    Keys,
    MagicScroll
}

public class Item
{
    public string Name { get; set; }
    public string Effect { get; set; }
    public ItemType Type { get; set; }
    public int Quantity { get; set; }
    public int SlotIndex { get; set; }

    public Item(string name, string effect, ItemType type, int quantity, int slotIndex = -1)
    {
        Name = name;
        Effect = effect;
        Type = type;
        Quantity = quantity;
        SlotIndex = slotIndex;
    }
}
