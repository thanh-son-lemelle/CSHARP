using UnityEngine;
using UnityEngine.UI;

public class CharacterDisplay : MonoBehaviour
{
    [SerializeField] public Image activeImage; // Image for displaying the current sprite
    [SerializeField] public Sprite[] playerSprites; // Array for character sprites
    [SerializeField] public RuntimeAnimatorController[] animatorControllers; // Array for animator controllers
    [SerializeField] public Animator activeAnimator; // Animator for the character (shared)

    void Start()
    {
        // Initialize the active sprite and animator controller
        UpdatePlayerDisplay(PlayerController.Instance.player.activeCharacterID);
    }

    void Update()
    {
        UpdatePlayerDisplay(PlayerController.Instance.player.activeCharacterID); 
    }

    public void UpdatePlayerDisplay(int characterID)
    {
        if (characterID < 1 || characterID > playerSprites.Length)
        {
            Debug.LogError("Invalid activeCharacterID.");
            return;
        }

        // Update sprite and animator
        activeImage.sprite = playerSprites[characterID - 1];
        activeAnimator.runtimeAnimatorController = animatorControllers[characterID - 1];
    }
}