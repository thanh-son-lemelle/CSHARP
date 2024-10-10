using System.Collections;
using System.Collections.Generic;
// using UnityEditor.Tilemaps;
using UnityEngine;

namespace Cainos.PixelArtTopDown_Basic
{
    public class TopDownCharacterController : MonoBehaviour
    {
        public float speed;

        private Animator animator;
        private SpriteRenderer spriteRenderer;



        private void Start()
        {
            animator = GetComponent<Animator>();
            spriteRenderer = GetComponent<SpriteRenderer>();
        }


        private void Update()
        {
            Vector2 dir = Vector2.zero;
            if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
            {
                animator.SetBool("isWalking", false);
            }
            if (Input.GetKey(KeyCode.A))
            {
                dir.x = -1;
                // animator.SetInteger("Direction", 3);
                spriteRenderer.flipX = true;
                animator.SetBool("isWalking", true);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                dir.x = 1;
                // animator.SetInteger("Direction", 2);
                spriteRenderer.flipX = false;
                animator.SetBool("isWalking", true);
            }

            if (Input.GetKey(KeyCode.W))
            {
                dir.y = 1;
                // animator.SetInteger("Direction", 1);
                animator.SetBool("isWalking", true);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                dir.y = -1;
                // animator.SetInteger("Direction", 0);
                animator.SetBool("isWalking", true);
            }

            dir.Normalize();
            // animator.SetBool("isWalking", dir.magnitude > 0);

            GetComponent<Rigidbody2D>().velocity = speed * dir;
        }
    }
}
