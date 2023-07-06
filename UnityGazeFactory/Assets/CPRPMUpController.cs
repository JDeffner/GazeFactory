using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPRPMUpController : MonoBehaviour
{
    private ControllerCubeBehaviour controllerCubeBehaviour;

    void Awake()
    {
        // Get the ControllerCubeBehaviour component
        controllerCubeBehaviour = GameObject.Find("ControllerCube").GetComponent<ControllerCubeBehaviour>();
    }
    
    public void increaseCPRPM()
    {
        if (controllerCubeBehaviour.getNPPSystemInterface().getCPRPM() < 1601)
        {
            SharedRessource.currentCPRPMValue += 400;
            controllerCubeBehaviour.getNPPSystemInterface().setCPRPM(SharedRessource.currentCPRPMValue);

        } else controllerCubeBehaviour.getNPPSystemInterface().setCPRPM(2000);
    }
}
