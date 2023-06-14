using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SV1ButtonControl : MonoBehaviour
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
                controllerCubeBehaviour.getNPPSystemInterface().setSV1Status(true);  // Set SV1 status to true
                animator.SetBool("SV1Status", true);  // Set Animator's SV1Status to true
                Debug.Log("Button material is the base Material DUDE");
            }
            else
            {
                this.gameObject.GetComponent<MeshRenderer>().sharedMaterial = baseMaterial;
                controllerCubeBehaviour.getNPPSystemInterface().setSV1Status(false);  // Set SV1 status to false
                animator.SetBool("SV1Status", false);  // Set Animator's SV1Status to false
                Debug.Log("Button material is NOT the base Material CHAD");
            }
        }
    }

}
