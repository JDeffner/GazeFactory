using System;
using NPPImpl;
using Unity.VisualScripting;
using UnityEngine;

public class DebugMode : MonoBehaviour
{
    public bool debugMode = false;
    public void Update()
    {
        if (debugMode)
        {
            Debug.Log("Water Reactor: " + ControllerCubeBehaviour.nppSystemInterface.getWaterLevelReactor());
            Debug.Log("Pressure Reactor: " + ControllerCubeBehaviour.nppSystemInterface.getPressureReactor());
            Debug.Log("Water Condenser : " + ControllerCubeBehaviour.nppSystemInterface.getWaterLevelCondenser());
            Debug.Log("Pressure Condenser: " + ControllerCubeBehaviour.nppSystemInterface.getPressureCondenser());
            Debug.Log("RPM: " + ControllerCubeBehaviour.nppSystemInterface.getWP1RPM());
            Debug.Log("Rod Status: " + ControllerCubeBehaviour.nppSystemInterface.getRodPosition());
            Debug.Log("Power: " + ControllerCubeBehaviour.nppSystemInterface.getPowerOutlet());
            Debug.Log("CPRPM: " + ControllerCubeBehaviour.nppSystemInterface.getCPRPM());
            Debug.Log("SV1: " + ControllerCubeBehaviour.nppSystemInterface.getSV1Status());
            Debug.Log("SV2: " + ControllerCubeBehaviour.nppSystemInterface.getSV2Status());
            Debug.Log("WV1: " + ControllerCubeBehaviour.nppSystemInterface.getWV1Status());
            Debug.Log("WV2: " + ControllerCubeBehaviour.nppSystemInterface.getWV2Status());
        }
    }
}