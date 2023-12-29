using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombiewalkStateBehaviour : StateMachineBehaviour
{
    private Transform zombieTransform;
    private float walkSpeed = 2.0f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Get a reference to the zombie's transform.
        zombieTransform = animator.transform;

        // Start the walking animation or set any relevant parameters.
        animator.SetBool("IsWalking", true);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Move the zombie forward to simulate walking.
        zombieTransform.Translate(Vector3.forward * walkSpeed * Time.deltaTime);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Stop the walking animation or reset any relevant parameters.
        animator.SetBool("IsWalking", false);
    }
}
