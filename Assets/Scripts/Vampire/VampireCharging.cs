using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VampireCharging : StateMachineBehaviour
{
    [SerializeField]
    private Color litColor = Color.red;
    [SerializeField]
    private float gatheringTime = 1;

    private float time;

    private Material material;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        material = animator.gameObject.GetComponent<Renderer>().material;
        time = 0;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        if (material.color == litColor) {
            animator.SetBool("isCharged", true);
        } else {
            time += Time.deltaTime;
            material.color = Color.Lerp(material.color, litColor, time / gatheringTime);
        }
    }
}
