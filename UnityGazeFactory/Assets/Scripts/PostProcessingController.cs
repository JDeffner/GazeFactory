using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using Valve.VR;

public class PostProcessingController : MonoBehaviour
{
    public PostProcessVolume postProcessVolume;
    private Vignette vignette;
    public Transform objectToCheck;
    public Transform vrCamera;
    public float blinkInterval = 0.5f; 
    private float timer = 0f; 
    public bool isBlinking = true;
    public bool isActive = false;

    private void Start()
    {
        postProcessVolume.profile.TryGetSettings(out vignette);
    }

    private void Update()
    {
        GetAngle();
        if(isBlinking && isActive) {
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
        /// Just for Test Use
        Debug.Log("setLeft");
    }

    private void SetRight() {
        vignette.center.value = new Vector2(-0.05f, vignette.center.value.y);
        /// Just for Test Use
        Debug.Log("setRight");
    }

    public void GetAngle() {
        // Zeichne eine Linie auf der Mitte der VRCamera
        Vector3 cameraPosition = vrCamera.position;
        Vector3 cameraForward = vrCamera.forward;
        Vector3 lineEndPosition = cameraPosition + cameraForward * 10f; // Länge der Linie (10f) anpassen, falls erforderlich
        Debug.DrawLine(cameraPosition, lineEndPosition, Color.red);
        
        // Berechne den Winkel zwischen der Linie und dem Zielobjekt
        Vector3 objectPosition = objectToCheck.position;
        Vector2 cameraToObjDirection = new Vector2(objectPosition.x - cameraPosition.x, objectPosition.z - cameraPosition.z);
        Vector2 cameraForwardDirection = new Vector2(cameraForward.x, cameraForward.z);
        float angle = Vector2.SignedAngle(cameraForwardDirection, cameraToObjDirection);
        
        // Gib den berechneten Winkel aus
        Debug.Log("Winkel zum Objekt: " + angle);
        if (angle < 0)
        {
            SetRight();
            Debug.Log("SetRight");
        }
        else
        {
            SetLeft();
            Debug.Log("SetLeft");
        }
    }
}
