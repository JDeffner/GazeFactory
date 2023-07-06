using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S3Behaviour : StateMachineBehaviour
{
    public GameObject SV1Switch;
    private SimpleGazeMark gazeMark;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) 
    {
            SV1Switch = GameObject.Find("SV1Switch");
            gazeMark =  FindObjectOfType<SimpleGazeMark>();

                gazeMark.targetedObject = SV1Switch;
                gazeMark.isActive = true;
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) 
    {
        //gazeMark.isActive = false;
    }
}
