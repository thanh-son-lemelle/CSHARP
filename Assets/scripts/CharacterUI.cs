using UnityEngine;

public class CharacterUI : MonoBehaviour
{
    public SpriteRenderer characterSpriteRenderer; // The SpriteRenderer where the sprite will be displayed
    public Sprite character1;
    public Sprite character2;
    public Sprite character3;
    public Sprite character4;
    private bool isActive = false; 

    // This method will be called to update the character sprite based on its ID
    public void UpdateCharacterSprite(int characterID)
    {
        Debug.Log("Method called with characterID: " + characterID);

        // Check if SpriteRenderer is assigned
        if (characterSpriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer is not assigned!");
            return;
        }

        if (isActive) // Check if the character is active
        {
            // Use a switch to select the sprite based on the character's ID
            switch (characterID)
            {
                case 1:
                    characterSpriteRenderer.sprite = character1;
                    Debug.Log("Displaying sprite for Hero1");
                    break;
                case 2:
                    characterSpriteRenderer.sprite = character2;
                    Debug.Log("Displaying sprite for Hero2");
                    break;
                case 3:
                    characterSpriteRenderer.sprite = character3;
                    Debug.Log("Displaying sprite for Hero3");
                    break;
                case 4:
                    characterSpriteRenderer.sprite = character4;
                    Debug.Log("Displaying sprite for Hero4");
                    break;
                default:
                    Debug.LogError("Unrecognized character ID: " + characterID);
                    break;
            }

            // Activate the GameObject that contains the SpriteRenderer after updating the sprite
            characterSpriteRenderer.gameObject.SetActive(true);
        }
        else
        {
            // If isActive is false, hide the GameObject that contains the SpriteRenderer
            characterSpriteRenderer.gameObject.SetActive(false);
            Debug.Log("Character is not active, hiding sprite.");
        }
    }

    // Method to control whether the character is active or not
    public void SetCharacterActive(bool active)
    {
        isActive = active;
   
    }

    
}
