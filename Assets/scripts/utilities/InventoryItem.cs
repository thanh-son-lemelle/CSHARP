using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Header("UI")]
    public Image image;                // Reference to the UI Image for the item icon
    public Text quantityText;          // Reference to the UI Text for the item quantity
    [HideInInspector] public InventorySlot originalSlot; // Original slot before dragging
    [HideInInspector] public Transform parentAfterDrag;
    private Canvas parentCanvas;

    // Add a reference to the item
    public Item item; // Ensure this is assigned correctly

    private void Start()
    {
        parentCanvas = GetComponentInParent<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        image.raycastTarget = false;
        originalSlot = GetComponentInParent<InventorySlot>(); // Set originalSlot
        parentAfterDrag = transform.parent;
        transform.SetParent(parentCanvas.transform, true);
        transform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        image.raycastTarget = true;
        transform.SetParent(parentAfterDrag);
    }

    public void UpdateItem(Item item, InventoryUI inventoryUI)
    {
        this.item = item; // Assign the item to the component

        // Update the icon sprite based on item type
        image.sprite = GetSpriteForItem(item, inventoryUI);

        // Update the quantity text
        if (quantityText != null)
        {
            quantityText.text = item.Quantity.ToString();
        }
        SetItemVisibility(item.Quantity);
    }

    private Sprite GetSpriteForItem(Item item, InventoryUI inventoryUI)
    {
        switch (item.Type)
        {
            case ItemType.Potion:
                return inventoryUI.potionSprite;
            case ItemType.Weapon:
                return inventoryUI.weaponSprite;
            case ItemType.Keys:
                return inventoryUI.keysSprite;
            case ItemType.MagicScroll:
                return inventoryUI.magicScrollSprite;
            default:
                return null;
        }
    }

    private void SetItemVisibility(int quantity)
    {
        if (image != null)
        {
            Color iconColor = image.color;
            iconColor.a = quantity > 0 ? 1f : 0f; // Set alpha based on quantity
            image.color = iconColor;
        }

        if (quantityText != null)
        {
            Color textColor = quantityText.color;
            textColor.a = quantity > 0 ? 1f : 0f; // Set alpha based on quantity
            quantityText.color = textColor;
        }
    }
}
