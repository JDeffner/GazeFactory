using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderController : MonoBehaviour
{
    private Animator animator;
    public GameObject slider;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float currentZ = slider.transform.position.z;
        animator.SetFloat("SliderPosition", currentZ);
    }
}
