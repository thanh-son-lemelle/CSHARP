using UnityEngine;

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
    public string Name;
    public string Effect;
    public ItemType Type;
    public int Quantity;
    public int SlotIndex;

    public Item(string name, string effect, ItemType type, int quantity, int slotIndex = -1)
    {
        Name = name;
        Effect = effect;
        Type = type;
        Quantity = quantity;
        SlotIndex = slotIndex;
    }
}
