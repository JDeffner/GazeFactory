using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerSphere : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject gameObject;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forwardMovement = transform.forward * (ControllerCubeBehaviour.nppSystemInterface.getWaterLevelReactor() / 2000) * Time.deltaTime;
        transform.position += forwardMovement;
    }
}
