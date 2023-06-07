using UnityEngine;

public class SpawnDespawnCursor : StateMachineBehaviour
{
    public GameObject cursorPrefab;
    private GameObject spawnedCursor;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) 
    {
        // Instantiate the cursorPrefab at the position of the Slider object.
        // You can adjust the position as needed.
        if (cursorPrefab != null)
        {
            spawnedCursor = GameObject.Instantiate(cursorPrefab, animator.transform.position, Quaternion.identity);
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) 
    {
        // Destroy the cursor object when exiting the state.
        if (spawnedCursor != null)
        {
            GameObject.Destroy(spawnedCursor);
        }
    }
}