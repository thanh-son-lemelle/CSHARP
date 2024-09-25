using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MouseHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Color hoverColor;
    public Color defaultColor;
    private Image image;

    void Start()
    {
        image = GetComponentInChildren<Image>();

        if (image != null)
        {
            image.color = defaultColor;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (image != null)
        {
            image.color = hoverColor;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (image != null)
        {
            image.color = defaultColor;
        }
    }
}
