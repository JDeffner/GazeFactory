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
            if (controllerCubeBehaviour.getNPPSystemInterface().getWP1RPM() == 0) SharedRessource.currentWP1RPM = 0;
            SharedRessource.currentWP1RPM += 200;
            controllerCubeBehaviour.getNPPSystemInterface().setWP1RPM(SharedRessource.currentWP1RPM);

        } else controllerCubeBehaviour.getNPPSystemInterface().setWP1RPM(2000);
    }
}
