using UnityEngine;
using UnityEngine.UI;

public class CharacterDisplay : MonoBehaviour
{
    [SerializeField] public RuntimeAnimatorController[] animatorControllers; // Array for animator controllers
    [SerializeField] public Animator activeAnimator; // Animator for the character (shared)
    [SerializeField] public SpriteRenderer characterSpriteRenderer; // Reference to the sprite renderer
    [SerializeField] public CapsuleCollider2D characterCollider; // Reference to the CapsuleCollider2D


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
        activeAnimator.runtimeAnimatorController = animatorControllers[characterID - 1];
        if (characterID == 4)
        {
            characterSpriteRenderer.transform.localScale = new Vector3(0.125f, 0.125f, 0.125f);
            characterCollider.offset = new Vector2(0f, -3.8f);
            characterCollider.size = new Vector2(2.7f, 0f);
        }
        else
        {
            characterSpriteRenderer.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
            characterCollider.offset = new Vector2(0f, -2.2f);
            characterCollider.size = new Vector2(1.4f, 0f);
        }

    }
}