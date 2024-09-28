using UnityEngine;

public class MoveWorld : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of background movement
    public Animator animator; // Reference to the Animator component

    void Update()
    {
        Vector3 movement = Vector3.zero;

        // Check for input and move the background
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) // Right Arrow or D
        {
            movement -= Vector3.right * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.Q)) // Left Arrow or Q
        {
            movement -= Vector3.left * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Z)) // Up Arrow or Z
        {
            movement -= Vector3.up * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) // Down Arrow or S
        {
            movement -= Vector3.down * moveSpeed * Time.deltaTime;
        }

        // Move the background
        transform.position += movement;

        // Check if there is movement
        if (movement != Vector3.zero)
        {
            // If there is movement, ensure the animator is playing
            animator.speed = 1f; // Play animation at normal speed
        }
        else
        {
            // If there is no movement, pause the animation
            animator.speed = 0f; // Pause animation
        }
    }
}
