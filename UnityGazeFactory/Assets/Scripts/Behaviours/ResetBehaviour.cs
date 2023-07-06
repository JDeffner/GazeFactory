using UnityEngine;

public class ResetBehaviour : StateMachineBehaviour
{
    private GameObject targetedObject;
    private SimpleGazeMark gazeMark;
    private PostProcessingController postController;
    
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) 
    {

        postController.isActive = false;
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) 
    {
        // gazeMark.isActive = false;
    }
}
