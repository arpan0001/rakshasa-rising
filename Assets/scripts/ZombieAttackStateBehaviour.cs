using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttackStateBehaviour : StateMachineBehaviour
{
    private Transform zombieTransform;
    private float attackRange = 2.0f;
    private float attackCooldown = 1.5f;
    private float lastAttackTime;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Get a reference to the zombie's transform.
        zombieTransform = animator.transform;

        // Trigger the attack animation.
        animator.SetTrigger("IsAttacking");

        // Record the time of the last attack.
        lastAttackTime = Time.time;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Check if it's time for another attack.
        if (Time.time - lastAttackTime > attackCooldown)
        {
            // Check for nearby targets to attack.
            Collider[] hitColliders = Physics.OverlapSphere(zombieTransform.position, attackRange);
            foreach (Collider hitCollider in hitColliders)
            {
                if (hitCollider.CompareTag("Player"))
                {
                    // Perform the attack action here.
                    Debug.Log("Zombie attacks the player!");

                    // Update the last attack time.
                    lastAttackTime = Time.time;
                }
            }
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Reset the "IsAttacking" trigger.
        animator.ResetTrigger("IsAttacking");
    }
}
