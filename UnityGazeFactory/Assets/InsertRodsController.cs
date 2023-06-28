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
        SharedRessource.currentRodValue -= 1;
        controllerCubeBehaviour.getNPPSystemInterface().setReactorModeratorPosition(
            SharedRessource.currentRodValue);
        SharedRessource.currentRodValue -= 1;
        controllerCubeBehaviour.getNPPSystemInterface().setReactorModeratorPosition(
            SharedRessource.currentRodValue);
        SharedRessource.currentRodValue -= 1;
        controllerCubeBehaviour.getNPPSystemInterface().setReactorModeratorPosition(
            SharedRessource.currentRodValue);
        SharedRessource.currentRodValue -= 1;
        controllerCubeBehaviour.getNPPSystemInterface().setReactorModeratorPosition(
            SharedRessource.currentRodValue);
        SharedRessource.currentRodValue -= 1;
        controllerCubeBehaviour.getNPPSystemInterface().setReactorModeratorPosition(
            SharedRessource.currentRodValue);
    }
}
