using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NPPImpl;

public class NPPSimulationAnimationBehaviour : MonoBehaviour
{
    // Reference to the Animator component
    private Animator animator;
    // Reference to ControllerCubeBehaviour component
    private ControllerCubeBehaviour controllerCubeBehaviour;
    // Reference to the NPPSystemInterface component
    private NPPSystemInterface systemInterface;

    void Start()
    {
        // Get the Animator component
        animator = GetComponent<Animator>();
        // Get the ControllerCubeBehaviour component
        controllerCubeBehaviour = GetComponent<ControllerCubeBehaviour>();
        // Get the NPPSystemInterface component
        systemInterface = controllerCubeBehaviour.getNPPSystemInterface();
    }

void Update()
{
    // Check if controllerCubeBehaviour and animator are not null
    if (controllerCubeBehaviour != null && animator != null)
    {

        animator.SetBool("WP1Status", systemInterface.getWP1Status());
        animator.SetInteger("WP1RPM", systemInterface.getWP1RPM());
        animator.SetBool("WP2Status", systemInterface.getWP2Status());
        animator.SetInteger("WP2RPM", systemInterface.getWP2RPM());
        animator.SetBool("CPStatus", systemInterface.getCPStatus());
        animator.SetInteger("CPRPM", systemInterface.getCPRPM());
        animator.SetBool("WV1Status", systemInterface.getWV1Status());
        animator.SetBool("WV2Status", systemInterface.getWV2Status());
        animator.SetBool("SV1Status", systemInterface.getSV1Status());
        animator.SetBool("SV2Status", systemInterface.getSV2Status());
        animator.SetInteger("WaterLevelReactor", systemInterface.getWaterLevelReactor());
        animator.SetInteger("WaterLevelCondenser", systemInterface.getWaterLevelCondenser());
        animator.SetInteger("PressureReactor", systemInterface.getPressureReactor());
        animator.SetInteger("PressureCondenser", systemInterface.getPressureCondenser());
        animator.SetInteger("StandardValue", systemInterface.getStandardValue());
        animator.SetInteger("PowerOutlet", systemInterface.getPowerOutlet());
        animator.SetBool("ReactorTankStatus", systemInterface.getReactorTankStatus());
        animator.SetBool("ReactorStatus", systemInterface.getReactorStatus());
        animator.SetBool("CondenserStatus", systemInterface.getCondenserStatus());
        animator.SetBool("TurbineStatus", systemInterface.getTurbineStatus());
        animator.SetBool("KPStatus", systemInterface.getKPStatus());
        animator.SetBool("AtomicStatus", systemInterface.getAtomicStatus());
        animator.SetInteger("RodPosition", systemInterface.getRodPosition());
        animator.SetInteger("WP1RPMSet", systemInterface.getWP1RPMSet());
        animator.SetInteger("WP2RPMSet", systemInterface.getWP2RPMSet());
        animator.SetInteger("CPRPMSet", systemInterface.getCPRPMSet());
    }
}

}