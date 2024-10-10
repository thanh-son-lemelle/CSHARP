using UnityEngine;

[System.Serializable]
public class Character
{
    [SerializeField] public string characterName;
    [SerializeField] public int health, maxHealth, attack, defense, speed, level, experience, experienceToNextLevel, characterID;


    public Coordinates coordinates;

    //Constructors


    public Character(string characterName, int health, int maxHealth, int attack, int defense, int speed, int level, int experience, int experienceToNextLevel, int characterID)
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
        this.characterID = characterID;
    }

    // Placeholder for a list of abilities (need to implement the Ability class)
    // public List<Ability> abilities = new List<Ability>();


    // Instead of a constructor, use this Initialize method to set character properties
    public void Initialize(string characterName, int health, int maxHealth, int attack, int defense, int speed, int level, int experience, int experienceToNextLevel, int characterID)
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
        this.coordinates = new Coordinates(0, 0); // Default coordinates or set dynamically
        this.characterID = characterID;
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

    // public void MoveTo(Coordinates newCoordinates)
    // {
    //     coordinates = newCoordinates;
    //     transform.position = GridManager.instance.GetWorldPosition(newCoordinates);
    //     Debug.Log($"{characterName} moved to {coordinates}");
    // }

    private void Update()
    {
    }


}
