using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeispielBehaviour : StateMachineBehaviour
{
    private GameObject targetedObject;
    private SimpleGazeMark gazeMark;
    private PostProcessingController postController;
    private SimpleGazeText gazeText;
    private SimpleGazeTextTwo gazeTextTwo;
    
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) 
    {
        // Set targeted Object
        targetedObject = GameObject.Find("CPRPMUp");
        // Find GazeGuiding Components
        gazeMark =  FindObjectOfType<SimpleGazeMark>();
        postController = FindObjectOfType<PostProcessingController>();
        gazeText = FindObjectOfType<SimpleGazeText>();
        gazeTextTwo = FindObjectOfType<SimpleGazeTextTwo>();
        // Change Targeted Objects
        gazeMark.targetedObject = targetedObject;
        postController.targetedObject = targetedObject;
        gazeText.targetedObject = targetedObject;
        gazeText.targetedObject = targetedObject;
        // Set Text, TextColor and Mark Color
        string color = "#FF4306"; // Hex Code
        gazeText.text = "Test \n ist \n gelungen!!!!"; // "\n" für Zeilenumbruch
        gazeText.textColor = color;
        gazeText.textSize = 0.08f; // 0.08f is normal Size -> U need to undo in next State
        gazeTextTwo.text = "Test";
        gazeTextTwo.textColor = color;
        gazeTextTwo.textSize = 0.08f;
        gazeMark.markColor = color;
        gazeMark.markSize = 0.06f; // 0.06f is normal Size -> U need to undo in next State
        // Set GazeGuiding active
        gazeMark.isActive = true;
        postController.isActive = true;
        gazeText.isActive = true;
        gazeTextTwo.isActive = true;
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) 
    {
        // gazeMark.isActive = false;
        // Wenn man Größe ändert
        // gazeText.textSize = 0.08f;
    }
}
