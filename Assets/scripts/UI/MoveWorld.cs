using UnityEngine;

public class MoveWorld : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of background movement
    public Animator characterAnimator; // Reference to the Animator component

    void Update()
    {
        Vector3 movement = Vector3.zero;
        bool isMoving = false; // Track if the character is moving

        // Check for input and move the background
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) // Right Arrow or D
        {
            movement += Vector3.right * moveSpeed * Time.deltaTime;
            isMoving = true;
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.Q)) // Left Arrow or Q
        {
            movement += Vector3.left * moveSpeed * Time.deltaTime;
            isMoving = true;
        }
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Z)) // Up Arrow or Z
        {
            movement += Vector3.up * moveSpeed * Time.deltaTime;
            isMoving = true;
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) // Down Arrow or S
        {
            movement += Vector3.down * moveSpeed * Time.deltaTime;
            isMoving = true;
        }

        // Move the background
        transform.position += movement;

        // Update animator based on movement
        if (isMoving)
        {
            characterAnimator.SetBool("IsMoving", true); // Assuming you have a parameter called IsMoving in your Animator
            Debug.Log("moving" + isMoving);
        }
        else
        {
            characterAnimator.SetBool("IsMoving", false); // Switch to idle animation
            Debug.Log("moving" + isMoving);

        }
    }
}
