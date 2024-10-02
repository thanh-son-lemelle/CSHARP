using UnityEngine;
using UnityEngine.UI;

public class CharacterOrientation : MonoBehaviour
{
    public Image image; // Reference to the Image component

    void Update()
    {
        // Move the character based on input
        float horizontalInput = Input.GetAxis("Horizontal");

        // Get the RectTransform component from the image
        RectTransform rectTransform = image.GetComponent<RectTransform>();

        // Flip the image by rotating the Y axis based on movement direction
        if (horizontalInput < 0)
        {
            rectTransform.localRotation = Quaternion.Euler(0, 180, 0); // Flip left
        }
        else if (horizontalInput > 0)
        {
            rectTransform.localRotation = Quaternion.Euler(0, 0, 0); // Flip right
        }
    }
}
