using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterLevelVisualizationReactorController : MonoBehaviour
{
    private bool isMovingUp = true;
    private bool isMovingDown = true;
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
        if(isMovingUp)
            transform.Translate(Vector3.up * Time.deltaTime);
        if (transform.position.y > controllerCubeBehaviour.getNPPSystemInterface().getWaterLevelReactor() * 0.0005f)
        {
            isMovingUp = false;
        }

        if (transform.position.y < controllerCubeBehaviour.getNPPSystemInterface().getWaterLevelReactor() * 0.0005f)
        {
            isMovingUp = true;
        }
        if(isMovingDown)
            transform.Translate(Vector3.down * Time.deltaTime);
        if (transform.position.y < controllerCubeBehaviour.getNPPSystemInterface().getWaterLevelReactor() * 0.0005f)
        {
            isMovingDown = false;
        }

        if (transform.position.y > controllerCubeBehaviour.getNPPSystemInterface().getWaterLevelReactor() * 0.0005f)
        {
            isMovingDown = true;
        }
    }
}
