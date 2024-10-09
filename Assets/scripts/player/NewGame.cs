using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NewGame : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public int CharacterNumber;
    public Button rectButton; // This will be assigned to each button in the Inspector
    public Button playButton;
    private Animator animator;
    public string isHover = "isHover"; // Make sure this matches the Animator parameter name
    public int CharacterChosed { set; get; }

    private void Start()
    {
        // Assign the button's onClick listener here
        rectButton.onClick.AddListener(() => SetCharacterNumber(CharacterNumber));
        playButton.onClick.AddListener(() => ChooseCharacter());

        // Find the Animator on the image child of this GameObject
        animator = GetComponentInChildren<Animator>(); // Assumes the Animator is on a child of this GameObject
    }

    public void SetCharacterNumber(int number)
    {
        CharacterChosed = number;
        Debug.Log("Character number: " + CharacterChosed + " clicked!");
    }

    public void ChooseCharacter()
    {
        if (CharacterChosed > 0)
        {
            switch (CharacterChosed)
            {
                case 1:
                    PlayerController.Instance.player.characters.Add(new Character("Hero1", 70, 100, 10, 5, 7, 1, 0, 100, 1));
                    break;
                case 2:
                    PlayerController.Instance.player.characters.Add(new Character("Hero2", 80, 50, 8, 4, 6, 1, 0, 100, 2));
                    break;
                case 3:
                    PlayerController.Instance.player.characters.Add(new Character("Hero3", 50, 50, 8, 4, 6, 1, 0, 100, 3));
                    break;
                case 4:
                    PlayerController.Instance.player.characters.Add(new Character("Hero4", 40, 50, 8, 4, 6, 1, 0, 100, 4));
                    break;
            }
        PlayerController.Instance.player.SetActiveCharacter(CharacterChosed);
        Debug.Log("Player initialized with character number: " + CharacterChosed);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        animator.SetBool(isHover, true); // Switch to Attacking animation
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        animator.SetBool(isHover, false); // Switch back to Idle animation
    }
}
