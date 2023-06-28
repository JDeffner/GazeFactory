using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AULampControl : MonoBehaviour
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

            if (!controllerCubeBehaviour.getNPPSystemInterface().getAtomicStatus())
            {
                this.gameObject.GetComponent<MeshRenderer>().sharedMaterial = altMaterial;
            }

    }

}
