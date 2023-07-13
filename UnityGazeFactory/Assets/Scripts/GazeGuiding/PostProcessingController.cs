using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessingController : MonoBehaviour
{
    // public Section
    public PostProcessVolume postProcessVolume;
    public GameObject targetedObject;
    public Camera vrCameraObject;
    public float blinkInterval = 0.5f;
    public bool isBlinking = true;
    public bool isActive = false;
    public bool DebugMode = false;
    
    [SerializeField] 
    [Range(0, 1)]
    private float vignetteOffset = 0.1f;
    
    // private Section
    private Vignette vignette;
    private Transform objectToCheck;
    private float timer = 0f;
    private bool isOnObject = false;
    private Transform vrCamera;

    private void Start() 
    {
        postProcessVolume.profile.TryGetSettings(out vignette);
        vrCamera = vrCameraObject.transform;
    }

    private void Update()
    {
        objectToCheck = targetedObject.transform;
        checkBlink();
        CheckAngle();
        CheckVision();
    }

    public void SetLeft() {
        vignette.center.value = new Vector2(1f, vignette.center.value.y);
        if(DebugMode) Debug.Log("setLeft");
    }

    private void SetRight() {
        vignette.center.value = new Vector2(-0.05f, vignette.center.value.y);
        if(DebugMode) Debug.Log("setRight");
    }

    public void checkBlink() {
        if(isBlinking && isActive && !isOnObject) {
            timer += Time.deltaTime;

            if (timer >= blinkInterval)
            {
                if (postProcessVolume.enabled == false)
                {
                    postProcessVolume.enabled = true;
                }
                else
                {
                    postProcessVolume.enabled = false;
                }

                timer = 0f;
            }
        } else {
            if(isOnObject) postProcessVolume.enabled = false;
            if(!isActive) postProcessVolume.enabled = false;
        }
    }

    public void CheckAngle() {
        // Berechne die Position der Vignette relativ zur Kamera
        Vector3 objectPosition = objectToCheck.position;
        Vector4 viewPos = vrCamera.worldToLocalMatrix * new Vector4(objectPosition.x, objectPosition.y, objectPosition.z, 1);
        Vector2 dir = new Vector2(viewPos.x, viewPos.y);
        
        vignette.center.value = new Vector2(0.5f, 0.5f) + -dir.normalized * vignetteOffset;
    }

    public void CheckVision()
    {
        Plane[] cameraFrustum = GeometryUtility.CalculateFrustumPlanes(vrCameraObject);
        Collider collider = targetedObject.GetComponent<Collider>();
        var bounds = collider.bounds;
        if (GeometryUtility.TestPlanesAABB(cameraFrustum, bounds))
        {
            isOnObject = true;
            if(DebugMode) Debug.Log("IsOnObject");
        }
        else
        {
            isOnObject = false;
            if(DebugMode) Debug.Log("IsNotOnObject");
        }
    }
}
