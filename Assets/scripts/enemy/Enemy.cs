using UnityEngine; 
using System.Collections.Generic;
using JetBrains.Annotations;
[System.Serializable]
public class Enemy : Character
{

    public List <Character> enemies{get; set;}

    public Enemy( string characterName, int health, int maxHealth, int strength, int defense, int speed, int level, int experience, int experienceToNextLevel, int characterID) 
    : base(characterName, health, maxHealth, strength, defense, speed, level, experience, experienceToNextLevel, characterID){
        enemies = new List<Character>();
    }

    public enum Type{
        ORC,
        PROWLERORC,
        WARRIORORC,
        TROLL
    }

    public enum Rarity{
        COMMON,
        UNCOMMON,
        RARE,
        SUPERRARE
    }

    public Type EnemyType;
    public Rarity EnemyRarity;

    public int baseAttack, baseDefense;
    public int curAttack, curDefense;
}