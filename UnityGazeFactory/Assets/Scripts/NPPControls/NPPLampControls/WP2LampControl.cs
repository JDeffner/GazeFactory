using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WP2LampControl : MonoBehaviour
{
    public Material altMaterial;

    private ControllerCubeBehaviour controllerCubeBehaviour;

    void Awake()
    {
        // Get the ControllerCubeBehaviour component
        controllerCubeBehaviour = GameObject.Find("ControllerCube").GetComponent<ControllerCubeBehaviour>();
    }

    public void Update()
    {

            if (!controllerCubeBehaviour.getNPPSystemInterface().getWP2Status())
            {
                this.gameObject.GetComponent<MeshRenderer>().sharedMaterial = altMaterial;
            }

    }

}
