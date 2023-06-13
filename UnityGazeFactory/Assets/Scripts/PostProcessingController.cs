using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessingController : MonoBehaviour
{
    public PostProcessVolume postProcessVolume;
    private Vignette vignette;

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

    public void setActive() {
        isActive = true;
        vignette.intensity.value = 0.4f;
    }

    public void setInActive() {
        isActive = false;
        vignette.intensity.value = 0f;
    }

    public void setLeft() {
        vignette.center.value = new Vector2(1, vignette.center.value.y);
        /// Just for Test Use
        Debug.Log("setLeft");
    }

    public void setRight() {
        vignette.center.value = new Vector2(0, vignette.center.value.y);
        /// Just for Test Use
        Debug.Log("setRight");
    }

    /// Just for Test Use
    public void changeIsBlinking() {
        if(isBlinking) {
            isBlinking = false;
        } else {
            isBlinking = true;
        }
    }
}
