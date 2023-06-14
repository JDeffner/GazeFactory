using UnityEngine;

public class WP1RPMUpController : MonoBehaviour
{
    private ControllerCubeBehaviour controllerCubeBehaviour;

    void Awake()
    {
        // Get the ControllerCubeBehaviour component
        controllerCubeBehaviour = GameObject.Find("ControllerCube").GetComponent<ControllerCubeBehaviour>();
    }
    
    public void increaseWP1RPM()
    {
        if (controllerCubeBehaviour.getNPPSystemInterface().getWP1RPM() < 2000)
        {
            controllerCubeBehaviour.getNPPSystemInterface().setWP1RPM(controllerCubeBehaviour.getNPPSystemInterface().getWP1RPM() + 200);

        } else controllerCubeBehaviour.getNPPSystemInterface().setWP1RPM(2000);
    }
}
