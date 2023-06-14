using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtractRodsController : MonoBehaviour
{
    private ControllerCubeBehaviour controllerCubeBehaviour;

    void Awake()
    {
        // Get the ControllerCubeBehaviour component
        controllerCubeBehaviour = GameObject.Find("ControllerCube").GetComponent<ControllerCubeBehaviour>();
    }

    public void extractRods()
    {
         controllerCubeBehaviour.getNPPSystemInterface().setReactorModeratorPosition(
             100 - controllerCubeBehaviour.getNPPSystemInterface().getRodPosition() + 5);
    }
}
