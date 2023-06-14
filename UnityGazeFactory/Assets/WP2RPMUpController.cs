using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WP2RPMUpController : MonoBehaviour
{
    private ControllerCubeBehaviour controllerCubeBehaviour;

    void Awake()
    {
        // Get the ControllerCubeBehaviour component
        controllerCubeBehaviour = GameObject.Find("ControllerCube").GetComponent<ControllerCubeBehaviour>();
    }
    
    public void increaseWP2RPM()
    {
        if (controllerCubeBehaviour.getNPPSystemInterface().getWP2RPM() < 2000)
        {
            controllerCubeBehaviour.getNPPSystemInterface().setWP2RPM(controllerCubeBehaviour.getNPPSystemInterface().getWP2RPM() + 200);

        } else controllerCubeBehaviour.getNPPSystemInterface().setWP2RPM(2000);
    }
}
