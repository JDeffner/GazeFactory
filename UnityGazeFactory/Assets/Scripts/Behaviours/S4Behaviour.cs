using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S4Behaviour : StateMachineBehaviour
{
    public GameObject SV2Switch;
    private SimpleGazeMark gazeMark;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) 
    {
            SV2Switch = GameObject.Find("SV2Switch");
            gazeMark =  FindObjectOfType<SimpleGazeMark>();

                gazeMark.targetedObject = SV2Switch;
                gazeMark.isActive = true;
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) 
    {
        //gazeMark.isActive = false;
    }
}
