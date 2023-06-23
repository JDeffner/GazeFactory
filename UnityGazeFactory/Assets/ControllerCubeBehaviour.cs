using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using NPPImpl;
using UnityEngine;

public class ControllerCubeBehaviour : MonoBehaviour
{
    private GameObject itemObject;
    public static NPPSystemInterface nppSystemInterface;
        
    // Start is called before the first frame update
    void Start()
    {
        nppSystemInterface = new NPPSystemInterface();
        nppSystemInterface.Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public NPPSystemInterface getNPPSystemInterface()
    {
        return nppSystemInterface;
    }
}
