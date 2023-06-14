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
        if (controllerCubeBehaviour.getNPPSystemInterface().getCPRPM() < 2000)
        {
            controllerCubeBehaviour.getNPPSystemInterface().setCPRPM(controllerCubeBehaviour.getNPPSystemInterface().getCPRPM() + 200);

        } else controllerCubeBehaviour.getNPPSystemInterface().setCPRPM(2000);
    }
}
