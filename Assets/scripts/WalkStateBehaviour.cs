using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkStateBehaviour : StateMachineBehaviour
{
    private Transform characterTransform;
    private float walkSpeed = 3.0f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Get a reference to the character's transform.
        characterTransform = animator.transform;

        // Start walking animation or set any relevant parameters.
        animator.SetBool("IsWalking", true);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Move the character forward to simulate walking.
        characterTransform.Translate(Vector3.forward * walkSpeed * Time.deltaTime);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Stop walking animation or reset any relevant parameters.
        animator.SetBool("IsWalking", false);
    }
}
