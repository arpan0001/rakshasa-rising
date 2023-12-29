using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieRunStateBehaviour : StateMachineBehaviour
{
    private Transform zombieTransform;
    private float runSpeed = 4.0f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Get a reference to the zombie's transform.
        zombieTransform = animator.transform;

        // Start the running animation or set any relevant parameters.
        animator.SetBool("IsRunning", true);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Move the zombie forward to simulate running.
        zombieTransform.Translate(Vector3.forward * runSpeed * Time.deltaTime);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Stop the running animation or reset any relevant parameters.
        animator.SetBool("IsRunning", false);
    }
}
