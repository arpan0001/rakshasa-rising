using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionToDeathBehaviour : StateMachineBehaviour
{
    private Animator characterAnimator;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Get a reference to the character's animator.
        characterAnimator = animator;

        // Transition to the "Death" state by setting the "IsDead" trigger.
        characterAnimator.SetTrigger("IsDead");
    }
}
