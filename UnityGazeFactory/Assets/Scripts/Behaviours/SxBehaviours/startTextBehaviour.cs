using UnityEngine;

public class startTextBehaviour : StateMachineBehaviour
{
    private GameObject targetedObject;
    private PostProcessingController postController;
    private SimpleGazeText gazeText;
    
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) 
    {
        // Set targeted Object
        targetedObject = GameObject.Find("Cube (5)");        // Find GazeGuiding Components
        postController = FindObjectOfType<PostProcessingController>();
        gazeText = FindObjectOfType<SimpleGazeText>();
        // Change Targeted Objects
        postController.targetedObject = targetedObject;
        gazeText.targetedObject = targetedObject;
        // Set Text, TextColor and Mark Color
        string color = "#32CD32"; // 
        gazeText.text = "Aufgabe: Hochfahren des AKW, sodass:\n-Wasserlevel stabil bei 2100 mm\n-Ausgangspower bei 700 MW";
        gazeText.textColor = color;
        // Set GazeGuiding active
        postController.isActive = true;
        gazeText.isActive = true;
        gazeText.textSize = 0.08f;
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) 
    {
        gazeText.isActive = false;
    }
}