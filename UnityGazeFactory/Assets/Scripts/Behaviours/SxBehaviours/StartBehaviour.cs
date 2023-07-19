using UnityEngine;

public class StartBehaviour : StateMachineBehaviour
{
    private GameObject targetedObject;
    private GameObject targetedObject2;
    private SimpleGazeMark gazeMark;
    private PostProcessingController postController;
    private SimpleGazeText gazeText;
    private SimpleGazeTextTwo simpleGazeTextTwo;
    
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) 
    {
        // Set targeted Object
        targetedObject = GameObject.Find("SV2Switch");  
        targetedObject2 = GameObject.Find("Cube (5)");  // Find GazeGuiding Components
        gazeMark =  FindObjectOfType<SimpleGazeMark>();
        postController = FindObjectOfType<PostProcessingController>();
        gazeText = FindObjectOfType<SimpleGazeText>();
        simpleGazeTextTwo = FindObjectOfType<SimpleGazeTextTwo>();
        // Change Targeted Objects
        gazeMark.targetedObject = targetedObject;
        postController.targetedObject = targetedObject;
        gazeText.targetedObject = targetedObject;
        simpleGazeTextTwo.targetedObject = targetedObject2;
        // Set Text, TextColor and Mark Color
        string color = "#32CD32"; // 
        gazeText.text = "Sequenz: Hochfahren\nAktion: SV2 öffnen";
        gazeText.textColor = color;
        gazeMark.markColor = color;
        // Set GazeGuiding active
        gazeMark.isActive = true;
        postController.isActive = true;
        gazeText.isActive = true;

        simpleGazeTextTwo.textColor = color;
        simpleGazeTextTwo.text="Aufgabe: Hochfahren des AKW, sodass:\n-Wasserlevel stabil bei 2100 mm\n-Ausgangspower bei 700 MW";
        simpleGazeTextTwo.isActive = true;
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) 
    {
        simpleGazeTextTwo.isActive = false;
    }
}
