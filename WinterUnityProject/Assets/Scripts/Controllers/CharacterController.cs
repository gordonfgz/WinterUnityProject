using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float jumpForce = 300f;
    [Range(0, 0.3f)] [SerializeField] private float movementSmoothing = 0.1f;
    private bool jump = false;
    private bool grounded = true;
    private bool faceRight = true;
    private Vector3 velocity = Vector3.zero;
    private Rigidbody2D characterRigidbody2D;

    
    private void Awake() {
        characterRigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Movement(float moveAmount, bool jump, bool dash) {
        // horizontal
        if(!jump && !dash) {
            Horizontal(moveAmount);
        }
        // vertical
        if(grounded && jump) {
            grounded = false;
            Jump(jumpForce);
        }

        void Horizontal(float moveAmount) {
            // moving of character by finding the target velocity
            Vector3 targetVelocity = new Vector2(moveAmount * 10f, characterRigidbody2D.velocity.y);
            // smooth the movement out and apply it to character
            characterRigidbody2D.velocity = Vector3.SmoothDamp(characterRigidbody2D.velocity, targetVelocity, ref velocity, movementSmoothing);

            // flip the character based on the input
            if (moveAmount > 0 && !faceRight) {
                Flip();
            } else if (moveAmount < 0 && faceRight) {
                Flip();
            }
        }

        void Jump(float jumpAmount) {
            grounded = false;
            characterRigidbody2D.AddForce(new Vector2(0f, jumpAmount));
        }



        void Flip() {
            // change the lable of facing right
            faceRight = !faceRight;

            // player x local scale flipped
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }

    public bool GetJump() {
        return jump;
    }

    public void IsJumping() {
        jump = true;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Ground")
        {
            grounded = true;
            jump = false;
        }
        Debug.Log(other.gameObject.tag);
    }
}
