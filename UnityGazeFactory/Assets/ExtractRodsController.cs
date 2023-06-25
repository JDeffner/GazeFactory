using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtractRodsController : MonoBehaviour
{
    private ControllerCubeBehaviour controllerCubeBehaviour;

    void Awake()
    {
        // Get the ControllerCubeBehaviour component
        controllerCubeBehaviour = GameObject.Find("ControllerCube").GetComponent<ControllerCubeBehaviour>();
    }

    public void extractRods()
    {
        SharedRessource.currentRodValue += 1;
         controllerCubeBehaviour.getNPPSystemInterface().setReactorModeratorPosition(
             SharedRessource.currentRodValue);
         SharedRessource.currentRodValue += 1;
         controllerCubeBehaviour.getNPPSystemInterface().setReactorModeratorPosition(
             SharedRessource.currentRodValue);
         SharedRessource.currentRodValue += 1;
         controllerCubeBehaviour.getNPPSystemInterface().setReactorModeratorPosition(
             SharedRessource.currentRodValue);
         SharedRessource.currentRodValue += 1;
         controllerCubeBehaviour.getNPPSystemInterface().setReactorModeratorPosition(
             SharedRessource.currentRodValue);
         SharedRessource.currentRodValue += 1;
         controllerCubeBehaviour.getNPPSystemInterface().setReactorModeratorPosition(
             SharedRessource.currentRodValue);
    }
}
