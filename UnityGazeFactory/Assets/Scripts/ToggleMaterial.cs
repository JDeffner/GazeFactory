using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;
public class ToggleMaterial : MonoBehaviour
{
    //public GameObject objToChange;
    public Material baseMaterial;
    public Material altMaterial;

    // Start is called before the first frame update
    public void updateButtonMaterial(){
        if (this.gameObject.GetComponent<MeshRenderer>().sharedMaterial == baseMaterial) {
            this.gameObject.GetComponent<MeshRenderer>().sharedMaterial = altMaterial;
            Debug.Log("Button material is the base Material");
        }
            
        else{
            Debug.Log("Button material is NOT the base Material");
            this.gameObject.GetComponent<MeshRenderer>().sharedMaterial = baseMaterial;
        }
    }
    void Start()
    {

    }

}
