using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S6Behaviour : StateMachineBehaviour
{
    public GameObject ExtractRodsButton;
    private SimpleGazeMark gazeMark;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) 
    {
            ExtractRodsButton = GameObject.Find("ExtractRodsButton");
            gazeMark =  FindObjectOfType<SimpleGazeMark>();

                gazeMark.targetedObject = ExtractRodsButton;
                gazeMark.isActive = true;
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) 
    {
        //gazeMark.isActive = false;
    }
}
