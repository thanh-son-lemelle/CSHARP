using UnityEngine;
using UnityEngine.UI;

public class CharacterDisplay : MonoBehaviour
{
    [SerializeField] public Image activeImage; // Image for displaying the current sprite
    [SerializeField] public Sprite[] characterSprites; // Array for character sprites
    [SerializeField] public RuntimeAnimatorController[] animatorControllers; // Array for animator controllers
    [SerializeField] public Animator activeAnimator; // Animator for the character (shared)
    public Slider playerHealthBar; // Player healthbar


    void Start()
    {
        // Initialize the active sprite and animator controller
        UpdateCharacterDisplay(PlayerController.Instance.player.activeCharacterID);
    }

    void Update()
    {
        UpdateCharacterDisplay(PlayerController.Instance.player.activeCharacterID);
        UpdatePlayerHealthBar();

    }

    public void UpdateCharacterDisplay(int characterID)
    {
        if (characterID < 1 || characterID > characterSprites.Length)
        {
            Debug.LogError("Invalid activeCharacterID.");
            return;
        }

        // Update sprite and animator
        activeImage.sprite = characterSprites[characterID - 1];
        activeAnimator.runtimeAnimatorController = animatorControllers[characterID - 1];
    }

    public void UpdatePlayerHealthBar() {

        foreach (Character character in PlayerController.Instance.player.characters) {

         if (character.characterID == PlayerController.Instance.player.activeCharacterID) {
                playerHealthBar.maxValue = character.maxHealth;
                playerHealthBar.value = character.health; 

                Debug.Log (character.health); 
                Debug.Log (character.maxHealth); 

            }

        }

    }


}
