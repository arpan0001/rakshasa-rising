using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpStateBehaviour : StateMachineBehaviour
{
    private CharacterController characterController;
    private float jumpForce = 8.0f;
    private bool isJumping = false;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Get a reference to the CharacterController component.
        characterController = animator.GetComponent<CharacterController>();

        // Set a trigger to play the jump animation (assuming you have an "isJumping" trigger).
        animator.SetTrigger("isJumping");

        // Apply the jump force vertically.
        characterController.Move(Vector3.up * jumpForce * Time.deltaTime);
        isJumping = true;
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Reset the jump trigger when exiting the jump state.
        animator.ResetTrigger("isJumping");
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Simulate gravity while jumping to bring the character back down.
        if (isJumping)
        {
            characterController.Move(Physics.gravity * Time.deltaTime);
        }
    }
}
