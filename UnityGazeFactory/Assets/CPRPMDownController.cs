using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPRPMDownController : MonoBehaviour
{
    private ControllerCubeBehaviour controllerCubeBehaviour;

    void Awake()
    {
        // Get the ControllerCubeBehaviour component
        controllerCubeBehaviour = GameObject.Find("ControllerCube").GetComponent<ControllerCubeBehaviour>();
    }

    public void decreaseCPRPM()
    {
        if (controllerCubeBehaviour.getNPPSystemInterface().getCPRPM() > 400)
        {
            SharedRessource.currentCPRPMValue -= 400;
            controllerCubeBehaviour.getNPPSystemInterface().setCPRPM(SharedRessource.currentCPRPMValue);

        } else controllerCubeBehaviour.getNPPSystemInterface().setCPRPM(0);
    }
}
