using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunStateBehaviour : StateMachineBehaviour
{
    private Transform characterTransform;
    private float runSpeed = 8.0f;
    private Vector3 moveDirection;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Get a reference to the character's transform.
        characterTransform = animator.transform;

        // Calculate the movement direction based on the character's forward.
        moveDirection = characterTransform.forward;

        // Start the running animation or set any relevant parameters.
        animator.SetBool("IsRunning", true);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Move the character forward to simulate running.
        characterTransform.position += moveDirection * runSpeed * Time.deltaTime;
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Stop the running animation or reset any relevant parameters.
        animator.SetBool("IsRunning", false);
    }
}
