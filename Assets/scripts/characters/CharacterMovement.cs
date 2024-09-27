using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Character character;
    public float moveTime = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        handleMovementInput();
    }

        void handleMovementInput()
    {
        if (Input.GetKeyDown(KeyCode.Z)) // Up
        {
            attemptMove(new Vector2Int(0, 1));
        }
        else if (Input.GetKeyDown(KeyCode.S)) // Down
        {
            attemptMove(new Vector2Int(0, -1));
        }
        else if (Input.GetKeyDown(KeyCode.Q)) // Left
        {
            attemptMove(new Vector2Int(-1, 0));
        }
        else if (Input.GetKeyDown(KeyCode.D)) // Right
        {
            attemptMove(new Vector2Int(1, 0));
        }
    }

    void attemptMove(Vector2Int direction)
    {
        Coordinates targetCoordinates = character.coordinates + direction;

        if (GridManager.instance.isWalkable(targetCoordinates))
        {
            character.MoveTo(targetCoordinates);
        }
    }
}

