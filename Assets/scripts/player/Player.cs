using System.Collections.Generic;
using UnityEngine;
public class Player
{
    public List<Character> characters;  // Liste de personnages
    public int activeCharacterID = 1;  // ID du personnage actif

    public Player()
    {
        characters = new List<Character>(); 
    }

    public void SetActiveCharacter(int characterID)
    {
        if (characters.Exists(c => c.characterID == characterID))
        {
            activeCharacterID = characterID;
            Debug.Log($"Active character is : {activeCharacterID}");
        }
        else
        {
            Debug.LogError($"ID : {characterID} not found !");
        }
    }
}
