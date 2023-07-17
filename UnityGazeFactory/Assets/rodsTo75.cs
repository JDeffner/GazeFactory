using UnityEngine;

public class rodsTo75 : StateMachineBehaviour
{
    private GameObject targetedObject;
    private SimpleGazeMark gazeMark;
    private PostProcessingController postController;
    private SimpleGazeText gazeText;
    
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) 
    {
        // Set targeted Object
        targetedObject = GameObject.Find("ExtractRodsButton");        // Find GazeGuiding Components
        gazeMark =  FindObjectOfType<SimpleGazeMark>();
        postController = FindObjectOfType<PostProcessingController>();
        gazeText = FindObjectOfType<SimpleGazeText>();
        // Change Targeted Objects
        gazeMark.targetedObject = targetedObject;
        postController.targetedObject = targetedObject;
        gazeText.targetedObject = targetedObject;
        // Set Text, TextColor and Mark Color
        string color = "#32CD32"; // 
        gazeText.text = "Sequenz: Hochfahren\nAktion: Brennstäbe auf 75 setzen";
        gazeText.textColor = color;
        gazeMark.markColor = color;
        gazeMark.markSize = 0.06f;
        // Set GazeGuiding active
        gazeMark.isActive = true;
        postController.isActive = true;
        gazeText.isActive = true;
        gazeText.textSize = 0.08f;
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) 
    {
        // gazeMark.isActive = false;
    }
}