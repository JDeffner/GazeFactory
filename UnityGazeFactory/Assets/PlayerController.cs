using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;
public class PlayerController : MonoBehaviour
{
    public SteamVR_Action_Vector2 inputMovementVector;
    public float speed = 1;
    private CharacterController characterController;

    // Start is called before the first frame update
    private void Start() {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // if test to prevent unexpected input value (e.g. teleporting)
        if(inputMovementVector.axis.magnitude > 0.1f) {
            Vector3 trueDirectionVector = Player.instance.hmdTransform.TransformDirection(new Vector3(inputMovementVector.axis.x, 0, inputMovementVector.axis.y));
            Vector3 gravityVector = new Vector3(0, 9.81f,0);

            // Char Controller based movement
            characterController.Move(speed * Time.deltaTime * Vector3.ProjectOnPlane(trueDirectionVector,Vector3.up) - gravityVector * Time.deltaTime);

            // transform based movement
            // transform.position += speed * Time.deltaTime * Vector3.ProjectOnPlane(trueDirectionVector,Vector3.up - gravityVector * Time.deltaTime);
        }
        

        
    }
}
