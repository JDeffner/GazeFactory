using UnityEngine;

public class State3Behaviour : StateMachineBehaviour
{
    public GameObject cursorPrefab;
    private GameObject spawnedCursor;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) 
    {
        if (cursorPrefab != null && spawnedCursor == null)
        {
            spawnedCursor = GameObject.Instantiate(cursorPrefab, animator.transform.position, Quaternion.identity);
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) 
    {
        if (spawnedCursor != null)
        {
            GameObject.Destroy(spawnedCursor);
            spawnedCursor = null;
        }
    }
}



