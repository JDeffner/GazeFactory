using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WV1ButtonControll : MonoBehaviour
{
    public Material baseMaterial;
    public Material altMaterial;

    private ControllerCubeBehaviour controllerCubeBehaviour;

    void Awake()
    {
        // Get the ControllerCubeBehaviour component
        controllerCubeBehaviour = GameObject.Find("ControllerCube").GetComponent<ControllerCubeBehaviour>();
    }

    public void updateButtonMaterial()
    {
        Animator animator = GameObject.Find("ControllerCube").GetComponent<Animator>();
        if (animator != null)
        {
            if (this.gameObject.GetComponent<MeshRenderer>().sharedMaterial == baseMaterial)
            {
                this.gameObject.GetComponent<MeshRenderer>().sharedMaterial = altMaterial;
                controllerCubeBehaviour.getNPPSystemInterface().setWV1Status(true); // Set SV2 status to true
                animator.SetBool("WV1Status", true); // Set Animator's SV2Status to true
            }
            else
            {
                this.gameObject.GetComponent<MeshRenderer>().sharedMaterial = baseMaterial;
                controllerCubeBehaviour.getNPPSystemInterface().setWV1Status(false); // Set SV2 status to false
                animator.SetBool("WV1Status", false); // Set Animator's SV2Status to false
            }
        }
    }
}

