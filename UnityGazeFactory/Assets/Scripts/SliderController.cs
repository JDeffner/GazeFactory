using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderController : MonoBehaviour
{
    private Animator animator;
    public GameObject slider;
    public GameObject button; // Your button GameObject
    public Material baseMaterial; // The 'Base' material

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Tracking the slider's position.
        float currentZ = slider.transform.position.z;
        animator.SetFloat("SliderPosition", currentZ);

        // Check if button's material is base and set the 'isButtonBase' parameter.
        Material buttonMaterial = button.GetComponent<Renderer>().sharedMaterial;
        Debug.Log("Checking button material...");
        if (buttonMaterial == baseMaterial)
        {
            Debug.Log("Button is base material.");
            animator.SetBool("isButtonBase", true);
        }
        else
        {
            Debug.Log("Button is not base material.");
            animator.SetBool("isButtonBase", false);
        }
    }
}
