using System.Collections.Generic;
using UnityEngine;

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
        DisplayCharacters(); 
    }
  public void DisplayCharacters()
    {
        Debug.Log("DisplayCharacters called");

        if (GameController.Instance != null && GameController.Instance.player != null)
        {
            foreach(Transform child in uiContainer){
                Destroy(child.gameObject); 
            }

            foreach (Character character in GameController.Instance.player.characters)
            {
                Debug.Log($"Affichage du personnage: {character.characterName}, ID: {character.characterID}, Santé: {character.health}/{character.maxHealth}, Niveau: {character.level}");

                GameObject characterUIObject = Instantiate(characterUIPrefab, uiContainer);
                CharacterUI characterUI = characterUIObject.GetComponent<CharacterUI>();
                characterUI.Initialize(character);
            }
        }
        else
        {
            Debug.LogError("GameController ou Player est nul !");
        }
    }
}