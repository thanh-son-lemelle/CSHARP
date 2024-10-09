using UnityEngine;
using System.Collections.Generic;

public class Enemy
{
    public List<Character> enemies { get; set; }
    public Enemy()
    {
        enemies = new List<Character>
        {
            new("Enemy1", 10, 60, 10, 5, 7, 1, 0, 100, 1),
            new("Enemy2", 20, 40, 8, 4, 6, 1, 0, 100, 2)
        };
    }
}