using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WP2RPMDownController : MonoBehaviour
{
    private ControllerCubeBehaviour controllerCubeBehaviour;

    void Awake()
    {
        // Get the ControllerCubeBehaviour component
        controllerCubeBehaviour = GameObject.Find("ControllerCube").GetComponent<ControllerCubeBehaviour>();
    }

    public void decreaseWP2RPM()
    {
        if (controllerCubeBehaviour.getNPPSystemInterface().getWP2RPM() > 200)
        {
            controllerCubeBehaviour.getNPPSystemInterface().setWP2RPM(controllerCubeBehaviour.getNPPSystemInterface().getWP2RPM() - 200);

        } else controllerCubeBehaviour.getNPPSystemInterface().setWP2RPM(0);
    }}
