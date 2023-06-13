using System.Collections;
using System.Collections.Generic;
using ConsoleApp1;
using UnityEngine;

public class ControllerWaterLevelUp : MonoBehaviour
{
    private ControllerCubeBehaviour controllerCubeBehaviour;

    void Awake()
    {
        // Get the ControllerCubeBehaviour component
        controllerCubeBehaviour = GameObject.Find("ControllerCube").GetComponent<ControllerCubeBehaviour>();
    }
    
    public void increaseWaterLevell()
    {
        if (controllerCubeBehaviour.getNPPSystemInterface().getWP1RPM() < 2000)
        {
            controllerCubeBehaviour.getNPPSystemInterface().setWP1RPM(ControllerCubeBehaviour.nppSystemInterface.getWP1RPM() + 200);
            
        } else controllerCubeBehaviour.getNPPSystemInterface().setWP1RPM(2000);
    }
}
