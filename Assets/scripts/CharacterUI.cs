using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class CharacterUI : MonoBehaviour
{

    // UI image to display character
    public Image characterSprite; 
    public Sprite character1;
    public Sprite character2;
    public Sprite character3;
    public Sprite character4;

    public Image characterImage; 
    public Text characterNameText; 
    public Slider healthBar; 
    public Text levelText; 
    public Slider experienceBar; 
    public Button attackButton;
    private Character character; 

    // Method to initialize the character's UI
    public void Initialize(Character character)
    {
        this.character = character;
        UpdateCharacterUI();
        if (attackButton != null)
        {
            attackButton.onClick.AddListener(OnAttackButtonClicked);
        }
    }

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

    // Method called when the attack button is clicked
    private void OnAttackButtonClicked()
    {
        // Attack another character or perform an action
        // Example: Simulate an attack on another character (to be defined)
        Character target = FindTargetCharacter(); // Implement this
        if (target != null)
        {
            character.AttackTarget(target); // Call the attack method
            UpdateCharacterUI(); // Update UI after the attack
        }
    }

    // Method to simulate finding a target character (implement according to your game's logic)
    private Character FindTargetCharacter()
    {
    
        return null; 
    }

    private void Update()
    {
        // Update the UI values each frame if needed
        UpdateCharacterUI();
    }

    // Method to update the character's UI
    public void UpdateCharacterUI()
    {

        if (character == null)return; 
        characterNameText.text = character.characterName;
        healthBar.maxValue = character.maxHealth;
        healthBar.value = character.health;
        levelText.text = "Level: " + character.level;
        experienceBar.value = character.experience;
    }

}

