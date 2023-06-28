using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S2Behaviour : StateMachineBehaviour
{
    public GameObject WV1Switch;
    private SimpleGazeMark gazeMark;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) 
    {
            WV1Switch = GameObject.Find("WV1Switch");
            gazeMark =  FindObjectOfType<SimpleGazeMark>();

                gazeMark.targetedObject = WV1Switch;
                gazeMark.isActive = true;
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) 
    {
        gazeMark.isActive = false;
    }
}
