using UnityEngine;

public class S6Behaviour : StateMachineBehaviour
{
    private GameObject targetedObject;
    private SimpleGazeMark gazeMark;
    private PostProcessingController postController;
    private SimpleGazeText gazeText;
    
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) 
    {
        // Set targeted Object
        targetedObject = GameObject.Find("WP1RPMUp");        // Find GazeGuiding Components
        gazeMark =  FindObjectOfType<SimpleGazeMark>();
        postController = FindObjectOfType<PostProcessingController>();
        gazeText = FindObjectOfType<SimpleGazeText>();
        // Change Targeted Objects
        gazeMark.targetedObject = targetedObject;
        postController.targetedObject = targetedObject;
        gazeText.targetedObject = targetedObject;
        // Set Text, TextColor and Mark Color
        string color = "#32CD32"; // 
        gazeText.text = "Sequenz: Hochfahren\nAktion: Wasserlevel auf 2100 halten und\n langsam Brennstäbe herausfahren";
        gazeText.textColor = color;
        gazeMark.markColor = color;
        // Set GazeGuiding active
        gazeMark.isActive = true;
        postController.isActive = true;
        gazeText.isActive = true;
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) 
    {
        // gazeMark.isActive = false;
    }
}
