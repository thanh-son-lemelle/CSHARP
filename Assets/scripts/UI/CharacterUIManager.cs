using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterUIManager : MonoBehaviour
{
    public GameObject characterUIPrefab;
    public Transform uiContainer;

    // public Sprite character1;
    // public Sprite character2;
    // public Sprite character3;
    // public Sprite character4;

    private void Start()
    {
    }
    
    public void DisplayCharacters()
{
    Debug.Log("DisplayCharacters called");

    if (GameController.Instance != null && PlayerController.Instance.player != null)
    {
        foreach (Transform child in uiContainer)
        {
            Destroy(child.gameObject); 
        }

        foreach (Character character in PlayerController.Instance.player.characters)
        {
            Debug.Log($"Creating UI for character: {character.characterName}");

            GameObject characterUIObject = Instantiate(characterUIPrefab, uiContainer);

            // Ensure the whole GameObject is active
            characterUIObject.SetActive(true);

            CharacterUI characterUI = characterUIObject.GetComponent<CharacterUI>();

            // Check if the CharacterUI component is correctly attached to the prefab
            if (characterUI == null)
            {
                Debug.LogError("CharacterUI component not found on the instantiated prefab.");
                continue;
            }

            // Initialize the character's UI and ensure that each part is active
            characterUI.Initialize(character);

            // Optionally, force activation of individual UI elements
            characterUI.characterNameText.gameObject.SetActive(true);
            characterUI.healthBar.gameObject.SetActive(true);
            characterUI.levelText.gameObject.SetActive(true);

           
            
        }
    }
    else
    {
        Debug.LogError("GameController or Player is null!");
    }
}
}