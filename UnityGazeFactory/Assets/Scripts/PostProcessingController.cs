using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessingController : MonoBehaviour
{
    // public Section
    public PostProcessVolume postProcessVolume;
    public GameObject targetedObject;
    public Transform vrCamera;
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
    
    private void Start() 
    {
        postProcessVolume.profile.TryGetSettings(out vignette);
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
        
        if(DebugMode) Debug.Log(dir);
        
        vignette.center.value = new Vector2(0.5f, 0.5f) + -dir.normalized * vignetteOffset;
    }

    public void CheckVision()
    {
            // Zeichne eine Linie auf der Mitte der VRCamera
            Vector3 cameraPosition = vrCamera.position;
            Vector3 cameraForward = vrCamera.forward;
            Vector3 lineEndPosition = cameraPosition + cameraForward * 10f; // Länge der Linie (10f) anpassen, falls erforderlich
            if(DebugMode) Debug.DrawLine(cameraPosition, lineEndPosition, Color.red);
            
            // Berechne den Winkel zwischen der Linie und dem Zielobjekt
            Vector3 objectPosition = objectToCheck.position;
            Vector2 cameraToObjDirection = new Vector2(objectPosition.x - cameraPosition.x, objectPosition.z - cameraPosition.z);
            Vector2 cameraForwardDirection = new Vector2(cameraForward.x, cameraForward.z);
            float angle = Vector2.SignedAngle(cameraForwardDirection, cameraToObjDirection);
            
            // Wenn der Winkel von Kamera Mitte zu Objekt (nur x und z Koordinaten) mehr als 31 vom Objekt abweicht dann ist wird PostProcessing aktiv
            if (angle < 31 && angle > 31  * (-1))
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
