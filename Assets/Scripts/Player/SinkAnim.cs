using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinkAnim : StateMachineBehaviour
{
    public GameObject PlayerObject;
    float originalPos;
    readonly float SinkSpeed = 0.003f;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        originalPos = 0;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.position = new Vector3(animator.transform.position.x, animator.transform.position.y - SinkSpeed, 0);
        originalPos += SinkSpeed;
        //PlayerObject.transform.position = new Vector3(PlayerObject.transform.position.x, PlayerObject.transform.position.y - 0.005f, 0);
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    { 
        base.OnStateExit(animator, stateInfo, layerIndex);
        animator.transform.position = new Vector3(animator.transform.position.x, animator.transform.position.y + originalPos, 0);
    }

}
