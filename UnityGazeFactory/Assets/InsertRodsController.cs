using UnityEngine;

public class InsertRodsController : MonoBehaviour
{
    private ControllerCubeBehaviour controllerCubeBehaviour;

    void Awake()
    {
        // Get the ControllerCubeBehaviour component
        controllerCubeBehaviour = GameObject.Find("ControllerCube").GetComponent<ControllerCubeBehaviour>();
    }

    public void insertRods()
    {
        controllerCubeBehaviour.getNPPSystemInterface().setReactorModeratorPosition(
            100 - controllerCubeBehaviour.getNPPSystemInterface().getRodPosition() - 5);
    }
}
