using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private string characterName;
    [SerializeField] private int health, maxHealth, attack, defense, speed, level, experience, experienceToNextLevel;

    // work in progress needs to be implemented
    // [SerializeField] private Coordinates coordinates;

    //* Constructors
    public Character(string characterName, int health, int maxHealth, int attack, int defense, int speed, int level, int experience, int experienceToNextLevel)
    {
        this.characterName = characterName;
        this.health = health;
        this.maxHealth = maxHealth;
        this.attack = attack;
        this.defense = defense;
        this.speed = speed;
        this.level = level;
        this.experience = experience;
        this.experienceToNextLevel = experienceToNextLevel;
    }

    // Placeholder for a list of abilities (need to implement the Ability class)
    // public List<Ability> abilities = new List<Ability>();

    // Initialize values in Unity's Start or Awake method
    private void Start()
    {
        // Initialize character stats (you can do this in the Inspector as well)
        // random values for now
        characterName = "Hero";
        health = 100;
        maxHealth = 100;
        attack = 10;
        defense = 5;
        speed = 7;
        level = 1;
        experience = 0;
        experienceToNextLevel = 100;
    }

    // Function to take damage
    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health < 0)
        {
            health = 0;
        }
    }

    // Function to attack another character
    public void AttackTarget(Character target)
    {
        int damage = Mathf.Max(0, attack - target.defense); // Simplified damage calculation
        target.TakeDamage(damage);
        Debug.Log($"{characterName} attacks {target.characterName} for {damage} damage!");
    }

    // Function to gain experience and level up
    public void GainExperience(int amount)
    {
        experience += amount;
        if (experience >= experienceToNextLevel)
        {
            LevelUp();
        }
    }

    // Level up function
    private void LevelUp()
    {
        level++;
        experience = experience - experienceToNextLevel;
        experienceToNextLevel *= 2;
        maxHealth += 10;
        health = maxHealth;
        attack += 2;
        defense += 2;
        speed += 2;
        Debug.Log($"{characterName} leveled up! Now at level {level}.");
    }

        public void move(string direction, Map map) {
        Coordinates newPosition = map.calculateNewPosition(this.position, direction);

        // Check if the new position is valid and traversable
        Terrain terrain = map.getTerrainAt(newPosition);

        if (terrain != null) {
            // Handle terrain-specific logic (e.g., movement penalties)
            terrain.enter(this);

            // Update the character's position if the terrain is traversable
            this.position = newPosition;
            Debug.Log($"{name} moved to new position: ({position.x}, {position.y})");
        } else {
            Debug.Log($"{name} cannot move in that direction.");
        }
    }

    // You can add Update logic here if needed
    private void Update()
    {
        // Example: check for level up condition or other updates
    }
}
