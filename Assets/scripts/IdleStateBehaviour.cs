using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleStateBehaviour : StateMachineBehaviour
{
    // This method is called when entering the "Idle" state.
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Add your code to run when entering the "Idle" state here.
        // For example, you can stop any character movement or animations.
        Debug.Log("Entering Idle State");
    }

    // This method is called when exiting the "Idle" state.
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Add your code to run when exiting the "Idle" state here.
        // You can prepare the character for other animations or actions.
        Debug.Log("Exiting Idle State");
    }
}
