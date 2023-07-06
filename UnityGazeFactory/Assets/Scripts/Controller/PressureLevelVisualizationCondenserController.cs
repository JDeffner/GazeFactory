using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressureLevelVisualizationCondenserController : MonoBehaviour
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
        if (transform.position.y > controllerCubeBehaviour.getNPPSystemInterface().getPressureCondenser() * 0.011111111111f)
        {
            isMovingUp = false;
        }

        if (transform.position.y < controllerCubeBehaviour.getNPPSystemInterface().getPressureCondenser() * 0.011111111111f)
        {
            isMovingUp = true;
        }

        if (isMovingDown)
            transform.Translate(Vector3.down * Time.deltaTime);
        if (transform.position.y < controllerCubeBehaviour.getNPPSystemInterface().getPressureCondenser() * 0.011111111111f)
        {
            isMovingDown = false;
        }

        if (transform.position.y > controllerCubeBehaviour.getNPPSystemInterface().getPressureCondenser() * 0.011111111111f)
        {
            isMovingDown = true;
        }
    }
}
