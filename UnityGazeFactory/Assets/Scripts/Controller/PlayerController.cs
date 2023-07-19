using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;
public class PlayerController : MonoBehaviour
{
    public SteamVR_Action_Vector2 inputMovementVector;
    public float speed = 1;
    public Transform vrCameraTransform;
    private CharacterController characterController;

    // Start is called before the first frame update
    private void Start() {
        //characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
            //Playspace clip through remover
            //characterController.center = new Vector3(vrCameraTransform.localPosition.x, characterController.center.y, vrCameraTransform.localPosition.z);

            Vector3 trueDirectionVector = Player.instance.hmdTransform.TransformDirection(new Vector3(inputMovementVector.axis.x, 0, inputMovementVector.axis.y));
            Vector3 gravityVector = new Vector3(0, 9.81f,0);

            // Char Controller based movement
            //characterController.Move(speed * Time.deltaTime * Vector3.ProjectOnPlane(trueDirectionVector,Vector3.up));

            // transform based movement
            transform.position += speed * Time.deltaTime * Vector3.ProjectOnPlane(trueDirectionVector,Vector3.up);

        const float MINIMAL_RECOGNIZED_INPUT = 0.1f;
        if(inputMovementVector.axis.magnitude > MINIMAL_RECOGNIZED_INPUT) {

        }
        

        
    }
}
