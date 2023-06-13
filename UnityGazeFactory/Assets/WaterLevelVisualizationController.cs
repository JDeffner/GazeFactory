using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterLevelVisualizationController : MonoBehaviour
{
    private bool isMoving = true;
    private ControllerCubeBehaviour controllerCubeBehaviour;

    void Awake()
    {
        // Get the ControllerCubeBehaviour component
        controllerCubeBehaviour = GameObject.Find("ControllerCube").GetComponent<ControllerCubeBehaviour>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isMoving)
            transform.Translate(Vector3.up * 1 * Time.deltaTime);
        if (transform.position.y > controllerCubeBehaviour.getNPPSystemInterface().getWaterLevelReactor() * 0.0005f)
        {
            isMoving = false;
        }

        if (transform.position.y < controllerCubeBehaviour.getNPPSystemInterface().getWaterLevelReactor() * 0.0005f)
        {
            isMoving = true;
        }

        Debug.Log(controllerCubeBehaviour.getNPPSystemInterface().getWaterLevelReactor());
    }
}
