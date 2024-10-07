using UnityEngine;
using UnityEngine.UI;

public class NewGame : MonoBehaviour
{
    public int CharacterNumber { set; get; }

    public Button rect1Button;
    public Button rect2Button;
    public Button rect3Button;
    public Button rect4Button;
    public Button playButton;

    private void Start()
    {
        rect1Button.onClick.AddListener(() => SetCharacterNumber(1));
        rect2Button.onClick.AddListener(() => SetCharacterNumber(2));
        rect3Button.onClick.AddListener(() => SetCharacterNumber(3));
        rect4Button.onClick.AddListener(() => SetCharacterNumber(4));
        playButton.onClick.AddListener(() => ChooseCharacter());

    }

    public void SetCharacterNumber(int number)
    {
        CharacterNumber = number;
        Debug.Log("Character number : " + CharacterNumber + " clicked !");
    }

    public void ChooseCharacter()
    {
        switch (CharacterNumber)
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
        Debug.Log("Player initialized with character number : " + CharacterNumber);
    }
}
