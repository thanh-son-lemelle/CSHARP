using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyUIManager : MonoBehaviour{

   // UI image to display the Enemy
    // public Image EnemySprite; 
    // public Sprite Enemy1;
    // public Sprite Enemy2;
    // public Sprite Enemy3;
    // public Sprite Enemy4;

    public EnemyUI enemyUI; 
    // public Character character;


    public void DisplayEnemies()
{
    Debug.Log(">DISPLAY ENEMY");
    

    if (GameController.Instance != null && PlayerController.Instance.player != null)
    {
        foreach (Character enemie in GameController.Instance.enemy.enemies)
        {
            Debug.Log($"Enemy Name: {enemie.characterName}");
            Debug.Log($"Enemy Health: {enemie.health}");
            Debug.Log($"Enemy Level: {enemie.level}");
            // enemyUI.Initialize(character);

        }
    }
    else
    {
        Debug.LogError("GameController or Player is null!");
    }
}


}
