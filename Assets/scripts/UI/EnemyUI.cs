using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;

public class EnemyUI : MonoBehaviour
{
   public EnemyUIManager enemyUIManager;
    public Image ImageEnemy; 
    public TextMeshProUGUI textEnemyName; 
    public Slider healthBarEnemy; 
    public TextMeshProUGUI textLevelEnemy; 
    private Character character; 

    
    public void Initialize(Character character)
    {
        UpdateEnemyUI(character);
        this.character = character;      
    }


    
    public void UpdateEnemyUI(Character character)
    {
        textEnemyName.text = character.characterName;
        healthBarEnemy.value = character.health;
        textLevelEnemy.text = "Level: " + character.level;

        // Add debug
        Debug.Log("> UPDATE ENEMY UI: \n");
        Debug.Log("Enemy Name: " + character.characterName);
        Debug.Log("Enemy Health: " + character.health);
        Debug.Log("Enemy Level: " + character.level);

    }

}

