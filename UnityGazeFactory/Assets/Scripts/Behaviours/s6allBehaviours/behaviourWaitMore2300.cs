﻿using UnityEngine;

public class behaviourWaitMore2300 : StateMachineBehaviour
{
    private GameObject targetedObject;
    private PostProcessingController postController;
    private SimpleGazeText gazeText;
    
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) 
    {
        // Set targeted Object
        targetedObject = GameObject.Find("WaitCube");        // Find GazeGuiding Components
        postController = FindObjectOfType<PostProcessingController>();
        gazeText = FindObjectOfType<SimpleGazeText>();
        // Change Targeted Objects
        postController.targetedObject = targetedObject;
        gazeText.targetedObject = targetedObject;
        // Set Text, TextColor and Mark Color
        string color = "#32CD32"; // 
        gazeText.text = "Warten bis Wasserlevel \n> 2300mm";
        gazeText.textColor = color;
        // Set GazeGuiding active
        postController.isActive = true;
        gazeText.isActive = true;
        gazeText.textSize = 0.18f;
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) 
    {
        // gazeMark.isActive = false;
    }
}