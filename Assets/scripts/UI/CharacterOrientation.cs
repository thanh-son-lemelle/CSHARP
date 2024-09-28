using UnityEngine;

public class CharacterOrientation : MonoBehaviour
{
    public SpriteRenderer spriteRenderer; // Reference to the Sprite Renderer

    void Update()
    {
        // Move the character based on input
        float horizontalInput = Input.GetAxis("Horizontal");

        // Flip sprite based on movement direction
        if (horizontalInput < 0)
        {
            spriteRenderer.flipX = true; // Flip left
        }
        else if (horizontalInput > 0)
        {
            spriteRenderer.flipX = false; // Flip right
        }
    }
}
