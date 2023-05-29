using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class ShowController : 
{
    public bool showController = false;

    // Update is called once per frame
    void Update()
    {
        foreach (var hand in Player.instance.hands)
        {
            if(showController){
                hand.ShowController();
            } else {
                hand.HideController();  
            }
        }
    }
}
