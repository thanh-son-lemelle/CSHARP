using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterDisplay : MonoBehaviour
{
    private Sprite activeSprite;
    [SerializeField] public Image activeImage; // Image for displaying the current sprite
    [SerializeField] public Sprite sprite1;    // Sprite for character 1
    [SerializeField] public Sprite sprite2;    // Sprite for character 2
    [SerializeField] public Sprite sprite3;    // Sprite for character 3
    [SerializeField] public Sprite sprite4;    // Sprite for character 4

    [SerializeField] public RuntimeAnimatorController animatorController1; // Animator controller for character 1
    [SerializeField] public RuntimeAnimatorController animatorController2; // Animator controller for character 2
    [SerializeField] public RuntimeAnimatorController animatorController3; // Animator controller for character 3
    [SerializeField] public RuntimeAnimatorController animatorController4; // Animator controller for character 4

    [SerializeField] public Animator activeAnimator; // Animator for the character (shared)

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the active sprite and animator controller
        UpdateCharacterDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCharacterDisplay();
    }

    // Method to update both sprite and animator controller based on the active character ID
    private void UpdateCharacterDisplay()
    {
        switch (GameController.Instance.player.activeCharacterID)
        {
            case 1:
                activeSprite = sprite1;
                activeAnimator.runtimeAnimatorController = animatorController1;
                break;
            case 2:
                activeSprite = sprite2;
                activeAnimator.runtimeAnimatorController = animatorController2;
                break;
            case 3:
                activeSprite = sprite3;
                activeAnimator.runtimeAnimatorController = animatorController3;
                break;
            case 4:
                activeSprite = sprite4;
                activeAnimator.runtimeAnimatorController = animatorController4;
                break;
            default:
                Debug.LogError("Invalid activeCharacterID.");
                return;
        }

        // Update the active image with the new sprite
        activeImage.sprite = activeSprite;
    }
}
