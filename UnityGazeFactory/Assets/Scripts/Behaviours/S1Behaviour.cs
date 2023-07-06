using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S1Behaviour : StateMachineBehaviour
{
    public GameObject CPRPMUp;
    private SimpleGazeMark gazeMark;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) 
    {
            CPRPMUp = GameObject.Find("CPRPMUp");
            gazeMark =  FindObjectOfType<SimpleGazeMark>();

                gazeMark.targetedObject = CPRPMUp;
                gazeMark.isActive = true;
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) 
    {
        //gazeMark.isActive = false;
    }
}
