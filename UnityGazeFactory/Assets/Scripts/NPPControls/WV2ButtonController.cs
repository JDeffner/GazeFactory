using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WV2ButtonController : MonoBehaviour
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
                controllerCubeBehaviour.getNPPSystemInterface().setWV2Status(true);  // Set WV2 status to true
                animator.SetBool("WV2Status", true);  // Set Animator's SV2Status to true
                Debug.Log("Button material is the base Material DUDE");
            }
            else
            {
                this.gameObject.GetComponent<MeshRenderer>().sharedMaterial = baseMaterial;
                controllerCubeBehaviour.getNPPSystemInterface().setWV2Status(false);  // Set WV2 status to false
                animator.SetBool("WV2Status", false);  // Set Animator's SV2Status to false
                Debug.Log("Button material is NOT the base Material CHAD");
            }
        }
    }

}
