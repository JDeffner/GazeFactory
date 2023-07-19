using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private Animator animator;
    public GameObject button;
    public Material redMaterial;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        var isButtonRed = button.GetComponent<Renderer>().material == redMaterial;
        animator.SetBool("IsButtonRed", isButtonRed);
    }
}

