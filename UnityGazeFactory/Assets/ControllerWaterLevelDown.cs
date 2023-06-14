using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerWaterLevelDown : MonoBehaviour
{
    private ControllerCubeBehaviour controllerCubeBehaviour;

    void Awake()
    {
        // Get the ControllerCubeBehaviour component
        controllerCubeBehaviour = GameObject.Find("ControllerCube").GetComponent<ControllerCubeBehaviour>();
    }
    
    public void decreaseWP1RPM()
    {
        if (controllerCubeBehaviour.getNPPSystemInterface().getWP1RPM() > 200)
        {
            controllerCubeBehaviour.getNPPSystemInterface().setWP1RPM(controllerCubeBehaviour.getNPPSystemInterface().getWP1RPM() - 200);

        } else controllerCubeBehaviour.getNPPSystemInterface().setWP1RPM(0);
    }
}
