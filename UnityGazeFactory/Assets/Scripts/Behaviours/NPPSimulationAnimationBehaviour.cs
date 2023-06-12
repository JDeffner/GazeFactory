using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPPSimulationAnimationBehaviour : MonoBehaviour
{
    // Reference to the Animator component
    private Animator animator;
    // Reference to ControllerCubeBehaviour component
    private ControllerCubeBehaviour controllerCubeBehaviour;

    void Start()
    {
        // Get the Animator component
        animator = GetComponent<Animator>();
        // Get the ControllerCubeBehaviour component
        controllerCubeBehaviour = GetComponent<ControllerCubeBehaviour>();
    }

    void Update()
    {
        // Check if controllerCubeBehaviour and animator are not null
        if (controllerCubeBehaviour != null && animator != null)
        {
            // Access SV2's status from controllerCubeBehaviour and assign to animator's parameter
            controllerCubeBehaviour.getNPPSystemInterface().getSV2Status();

        }
    }
}