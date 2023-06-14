using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterLevelVisualizationController : MonoBehaviour
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
            transform.Translate(Vector3.up * 1 * Time.deltaTime);
        if (transform.position.y > controllerCubeBehaviour.getNPPSystemInterface().getWaterLevelReactor() * 0.0005f)
        {
            isMovingUp = false;
        }

        if (transform.position.y < controllerCubeBehaviour.getNPPSystemInterface().getWaterLevelReactor() * 0.0005f)
        {
            isMovingUp = true;
        }
        if(isMovingDown)
            transform.Translate(Vector3.down * 1 * Time.deltaTime);
        if (transform.position.y < controllerCubeBehaviour.getNPPSystemInterface().getWaterLevelReactor() * 0.0005f)
        {
            isMovingDown = false;
        }

        if (transform.position.y > controllerCubeBehaviour.getNPPSystemInterface().getWaterLevelReactor() * 0.0005f)
        {
            isMovingDown = true;
        }

        Debug.Log("Water" + controllerCubeBehaviour.getNPPSystemInterface().getWaterLevelReactor());
        Debug.Log("RPM" + controllerCubeBehaviour.getNPPSystemInterface().getWP1RPM());
        Debug.Log("movingDown" + isMovingDown + "isMovingUp" + isMovingUp);
        Debug.Log("Water Condenser: " + controllerCubeBehaviour.getNPPSystemInterface().getWaterLevelCondenser());
    }
}
