using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterLevelVisualizationCondenserController : MonoBehaviour
{
    private bool isMovingUp = true;
    private bool isMovingDown = true;
    public Material baseMaterial;
    public Material altMaterial;
    private ControllerCubeBehaviour controllerCubeBehaviour;

    void Awake()
    {
        // Get the ControllerCubeBehaviour component
        controllerCubeBehaviour = GameObject.Find("ControllerCube").GetComponent<ControllerCubeBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector3(0, controllerCubeBehaviour.getNPPSystemInterface().getWaterLevelCondenser() * 0.000125f, 0);
        
        if (controllerCubeBehaviour.getNPPSystemInterface().getWaterLevelCondenser() > 0)
        {
            this.gameObject.GetComponent<MeshRenderer>().sharedMaterial = altMaterial;
        }
        else
        {
            this.gameObject.GetComponent<MeshRenderer>().sharedMaterial = baseMaterial;
        }
    }
}
