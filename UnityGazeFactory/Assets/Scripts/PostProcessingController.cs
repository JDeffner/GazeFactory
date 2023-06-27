using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessingController : MonoBehaviour
{
    // Vignette
    public PostProcessVolume postProcessVolume;
    private Vignette vignette;
    public Transform objectToCheck;
    public GameObject targetedObject;
    public Transform vrCamera;
    public float blinkInterval = 0.5f; 
    private float timer = 0f; 
    public bool isBlinking = true;
    public bool isActive = false;
    private bool isOnObject = false;
    public List<GameObject> targetedObjects;
    public List<float> VisionAngle;
    public bool DebugMode = false;
    
    private void Start()
    {
        postProcessVolume.profile.TryGetSettings(out vignette);
    }

    private void Update()
    {
        CheckAngle();
        if(isBlinking && isActive && !isOnObject) {
            timer += Time.deltaTime;

            if (timer >= blinkInterval)
            {
                if (vignette.intensity.value == 0f)
                {
                    vignette.intensity.value = 0.4f;
                }
                else
                {
                    vignette.intensity.value = 0f;
                }

                timer = 0f;
            }
        } else {
            if (isOnObject) vignette.intensity.value = 0f;
            if(!isActive) vignette.intensity.value = 0f;
        }
    }

    public void SetActive() {
        isActive = true;
        vignette.intensity.value = 0.4f;
    }

    public void SetInActive() {
        isActive = false;
        vignette.intensity.value = 0f;
    }

    public void SetLeft() {
        vignette.center.value = new Vector2(0.95f, vignette.center.value.y);
        if(DebugMode) Debug.Log("setLeft");
    }

    private void SetRight() {
        vignette.center.value = new Vector2(-0.05f, vignette.center.value.y);
        if(DebugMode) Debug.Log("setRight");
    }

    public void CheckAngle() {
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
        
        if(DebugMode) Debug.Log("Winkel zum Objekt: " + angle);
        if (angle < 0)
        {
            SetRight();
            if(DebugMode) Debug.Log("SetRight");
        }
        else
        {
            SetLeft();
            if(DebugMode) Debug.Log("SetLeft");
        }
        CheckVision(angle);
    }

    public void CheckVision(float angle)
    {
        if (targetedObjects != null && targetedObjects.Count > 0)
        {
            int currentIndex = targetedObjects.IndexOf(targetedObject);
            if (angle < VisionAngle[currentIndex] && angle > VisionAngle[currentIndex] * (-1))
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
}
