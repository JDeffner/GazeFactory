using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class WaterLevelStatusTextfield : MonoBehaviour
{
    public TextMeshPro text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = ControllerCubeBehaviour.nppSystemInterface.getWaterLevelReactor().ToString() + " mm";
    }
}

