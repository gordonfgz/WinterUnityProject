using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private float horizontalSpeed = 30f;
    private float horizontalMove = 0f;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * horizontalSpeed;

        if(Input.GetKeyDown("w")) {
            controller.IsJumping();
            Debug.Log("w key pressed");
        }
    }

    private void FixedUpdate() {
        controller.Movement(horizontalMove * Time.fixedDeltaTime, controller.GetJump(), false);
    }
}
