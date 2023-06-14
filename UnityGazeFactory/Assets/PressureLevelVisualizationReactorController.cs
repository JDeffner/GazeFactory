using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressureLevelVisualizationReactorController : MonoBehaviour
{
    private bool isMovingUp = true;
    private bool isMovingDown = true;
    private ControllerCubeBehaviour controllerCubeBehaviour;

    void Awake()
    {
        // Get the ControllerCubeBehaviour component
        controllerCubeBehaviour = GameObject.Find("ControllerCube").GetComponent<ControllerCubeBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isMovingUp)
            transform.Translate(Vector3.up * Time.deltaTime);
        if (transform.position.y > controllerCubeBehaviour.getNPPSystemInterface().getPressureReactor() * 0.00363636f)
        {
            isMovingUp = false;
        }

        if (transform.position.y < controllerCubeBehaviour.getNPPSystemInterface().getPressureReactor() * 0.00363636f)
        {
            isMovingUp = true;
        }

        if (isMovingDown)
            transform.Translate(Vector3.down * Time.deltaTime);
        if (transform.position.y < controllerCubeBehaviour.getNPPSystemInterface().getPressureReactor() * 0.00363636f)
        {
            isMovingDown = false;
        }

        if (transform.position.y > controllerCubeBehaviour.getNPPSystemInterface().getPressureReactor() * 0.00363636f)
        {
            isMovingDown = true;
        }
    }
}

