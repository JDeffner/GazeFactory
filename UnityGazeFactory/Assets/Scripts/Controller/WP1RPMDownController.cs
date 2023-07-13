using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WP1RPMDownController : MonoBehaviour
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
            SharedRessource.currentWP1RPM -= 200;
            controllerCubeBehaviour.getNPPSystemInterface().setWP1RPM(SharedRessource.currentWP1RPM);

        } else controllerCubeBehaviour.getNPPSystemInterface().setWP1RPM(0);
    }
}
