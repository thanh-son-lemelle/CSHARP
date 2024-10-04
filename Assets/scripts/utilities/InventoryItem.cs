using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    [Header("UI")]
    public Image image;                // Reference to the UI Image for the item icon
    public Text quantityText;          // Reference to the UI Text for the item quantity
    [HideInInspector] public InventorySlot originalSlot; // Original slot before dragging
    [HideInInspector] public Transform parentAfterDrag;
    private Canvas parentCanvas;

    // Add a reference to the item
    public Item item;

    // Tooltip UI
    public GameObject tooltip;        // Tooltip GameObject reference
    public Image tooltipImage;        // Image inside the tooltip
    public TextMeshProUGUI tooltipTextTitle;          // Text inside the tooltip
    public TextMeshProUGUI tooltipTextDecription;          // Text inside the tooltip
    private void Start()
    {
        parentCanvas = GetComponentInParent<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        image.raycastTarget = false;
        originalSlot = GetComponentInParent<InventorySlot>(); // Set originalSlot
        parentAfterDrag = transform.parent;

        // Move the dragged item to the parent canvas to ensure it's above other UI elements
        transform.SetParent(parentCanvas.transform, true);
        transform.SetAsLastSibling();
        if (tooltip != null)
        {
            tooltip.SetActive(false);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        image.raycastTarget = true;
        transform.SetParent(parentAfterDrag);
        if (tooltip != null) tooltip.SetActive(true);
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

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Show the tooltip on hover
        if (tooltip != null && item != null && item.Quantity > 0)
        {
            tooltip.SetActive(true);
            tooltipTextTitle.text = item.Name;        // Set the tooltip text to the item's name or description
            tooltipTextDecription.text = "<size=24>" + item.Type + "</size>\n<line-height=1.5><size=18>" + item.Effect + "</size></line-height>";
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Hide the tooltip when not hovering
        if (tooltip != null)
        {
            tooltip.SetActive(false);
        }
    }
}
