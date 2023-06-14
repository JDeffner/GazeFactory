using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S1Behaviour : StateMachineBehaviour
{
    public GameObject cursorPrefab;
    public GameObject SV2Switch;
    private GameObject spawnedCursor;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) 
    {
        if (cursorPrefab != null && spawnedCursor == null)
        {
            SV2Switch = GameObject.Find("SV2Switch");  // Find the SV2 switch GameObject in the scene by its name

            if (SV2Switch != null)
            {
                Vector3 spawnPosition = SV2Switch.transform.position + new Vector3(0f, 0.5f, 0f);  // Add 1 to the y-position to offset upwards
                spawnedCursor = GameObject.Instantiate(cursorPrefab, spawnPosition, Quaternion.identity);
            }
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
