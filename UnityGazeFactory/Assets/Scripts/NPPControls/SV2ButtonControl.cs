using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;
public class SV2ButtonControl : MonoBehaviour
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
                controllerCubeBehaviour.getNPPSystemInterface().setSV2Status(true);  // Set SV2 status to true
                animator.SetBool("SV2Status", true);  // Set Animator's SV2Status to true
                Debug.Log("Button material is the base Material DUDE");
            }
            else
            {
                this.gameObject.GetComponent<MeshRenderer>().sharedMaterial = baseMaterial;
                controllerCubeBehaviour.getNPPSystemInterface().setSV2Status(false);  // Set SV2 status to false
                animator.SetBool("SV2Status", false);  // Set Animator's SV2Status to false
                Debug.Log("Button material is NOT the base Material CHAD");
            }
        }
    }

}