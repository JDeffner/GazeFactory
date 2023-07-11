using UnityEngine;
using System.Collections.Generic;

public class SimpleGazeMark : MonoBehaviour {

    public GameObject targetedObject;
    public GameObject markPrefab;
    public List<GameObject> targetedObjects; 
    public List<Vector3> markOffset; 
    public float markBlinkIntervall = 0.5f;
    public float rotationSpeed = 10f;
    public string markColor; 
    public float markAlpha = 0.3f; 
    public bool isActive = false;
    private GameObject markInstance;
    private bool isMarkVisible = true; 
    private float blinkTimer = 0f; 
    private List<Renderer> markRendereres; 
    
    void Start() {
        markInstance = Instantiate(markPrefab);
        markRendereres = new List<Renderer>(markInstance.GetComponentsInChildren<Renderer>());
    }
    
    void Update() {
        UpdateMark();
        HandleMarkBlink();
        Color color;
        if (ColorUtility.TryParseHtmlString(markColor, out color))
        {
            ChangeMarkColor(color);
        }
    }

    private void UpdateMark() {
        if (targetedObjects != null && targetedObjects.Count > 0)
        {
            int currentIndex = targetedObjects.IndexOf(targetedObject);

            if (currentIndex >= 0 && currentIndex < markOffset.Count)
            {
                Vector3 markPosition = targetedObject.transform.position;
                markPosition.y = targetedObject.transform.position.y + markOffset[currentIndex].y;
                markPosition.z = targetedObject.transform.position.z + markOffset[currentIndex].z;
                markPosition += targetedObject.transform.right * markOffset[currentIndex].x;

                markInstance.transform.position = markPosition;

                // Drehe den Mark um seine eigene Achse
                Vector3 markR = markInstance.transform.localEulerAngles;
                markR.y += rotationSpeed * Time.deltaTime;
                markInstance.transform.localEulerAngles = markR;
            }
        }
    }
    
    private void HandleMarkBlink() {
        if (markBlinkIntervall <= 0f)
            return;

        blinkTimer += Time.deltaTime;

        if (blinkTimer >= markBlinkIntervall)
        {
            ToggleMarkVisibility();
            blinkTimer = 0f;
        }
    }
    
    private void ToggleMarkVisibility() {
        if (isActive == false) {
            isMarkVisible = false;
        } else {
            isMarkVisible = !isMarkVisible;
        }   

        foreach (Renderer renderer in markRendereres)
        {
            renderer.enabled = isMarkVisible;
        }
    }
    
    private void ChangeMarkColor(Color color)
    {
        color.a = markAlpha;
        foreach (Renderer renderer in markRendereres)
        {
            renderer.material.color = color;
        }
    }
}
