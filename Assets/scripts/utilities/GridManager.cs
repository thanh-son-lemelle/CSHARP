using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    // Singleton pattern 
    public static GridManager instance;

    // Grid size
    public int gridWidth, gridHeight;
    public float tileSize;

    private void Awake()
    // Awake is called when the script instance is being loaded
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public Vector3 GetWorldPosition(Coordinates coordinates)
    {
        return new Vector3(coordinates.x * tileSize, 0, coordinates.y * tileSize);
    }

    public bool isWalkable(Coordinates coordinates)
    {
        return coordinates.x >= 0 && coordinates.x < gridWidth && coordinates.y >= 0 && coordinates.y < gridHeight;
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
