using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Charactere : MonoBehaviour
{
    //* Basique stats for a character
    public int health;
    public int maxHealth;
    public int attack;
    public int defense;
    public int speed;
    public int level;
    public int experience;
    public int experienceToNextLevel;

    // List of abilities
    // Need to create a class for abilities
    // public List<Ability> abilities = new List<Ability>();

    //* Constructor
    public Charactere(string name, int health, int maxHealth, int attack, int defense, int speed, int level, int experience, int experienceToNextLevel)
    {
        this.name = name;
        this.health = health;
        this.maxHealth = maxHealth;
        this.attack = attack;
        this.defense = defense;
        this.speed = speed;
        this.level = level;
        this.experience = experience;
        this.experienceToNextLevel = experienceToNextLevel;
    }

    //* Basique function
    // Basique function to take damage
    // Need to be improved
    // Maybe with a listener to handle damage
    public void takeDamage(int amount)
    {
        health -= amount;
        if (health < 0)
        {
            health = 0;
        }
    }

    // Basique function to use an ability
    // Need to implement the ability system
    // public void UseAbility(Ability ability, Charactere target)
    // {
    //     // Need to implement the ability system
    // }

    public void attackTarget(Charactere target)
    {
        // Need to implement the attack system
    }

    public void gainExperience(int amount)
    {
        experience += amount;
        if (experience >= experienceToNextLevel)
        {
            levelUp();
        }
    }

    public void levelUp()
    {
        level++;
        experience = experience - experienceToNextLevel;
        experienceToNextLevel = experienceToNextLevel * 2;
        maxHealth = maxHealth + 10;
        health = maxHealth;
        attack = attack + 2;
        defense = defense + 2;
        speed = speed + 2;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
