using UnityEngine;
using UnityEngine.UI;

public class CharacterUI : MonoBehaviour
{
    public Image characterSprite; 
    public Sprite character1;
    public Sprite character2;
    public Sprite character3;
    public Sprite character4;


    // This method will be called to update the character sprite based on its ID
    public void UpdateCharacterSprite(int characterID)
    {
        Debug.Log("Method called with characterID: " + characterID);
        RectTransform rect = characterSprite.GetComponent<RectTransform>();

        // Check if SpriteRenderer is assigned
        if (characterSprite== null)
        {
            Debug.LogError("Image is not assigned!");
            return;
        }

    
             Debug.Log("Updating sprite for characterID: " + characterID); 

            // Use a switch to select the sprite based on the character's ID
            switch (characterID)
            {
                case 1:
                    characterSprite.sprite = character1;
                    Debug.Log("Displaying sprite for Hero1");
                    break;
                case 2:
                    characterSprite.sprite = character2;
                    Debug.Log("Displaying sprite for Hero2");
                    break;
                case 3:
                    characterSprite.sprite = character3;
                    Debug.Log("Displaying sprite for Hero3");
                    break;
                case 4:
                    characterSprite.sprite = character4;
                    characterSprite.SetNativeSize();
                    Debug.Log("Displaying sprite for Hero4");
                    break;
                default:
                    Debug.LogError("Unrecognized character ID: " + characterID);
                    break;
            }
        rect.sizeDelta = new Vector2 
        (30,30);
    }

   
}
