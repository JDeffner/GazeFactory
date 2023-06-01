using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class SimpleGazeMark : MonoBehaviour {

    public GameObject targetedObject;
    public GameObject markPrefab;
    public float maxMarkDistance = 30;
    public List<GameObject> targetedObjects; // Liste der Zielobjekte
    public List<Vector3> markOffset; // Liste der Verschiebungen für den Mark
    public float markBlinkIntervall = 0.5f; // Intervall zwischen den Blink-Zustandsänderungen in Sekunden
    public float rotationSpeed = 10f; // Geschwindigkeit der Rotation
    public Color markColor = Color.white; // Farbe des Marks
    public float markAlpha = 0.3f; // Transparenz Level 0 is vollkommen Transparent 1 ist vollkommen sichtbar
    public bool isActive = false;
    private GameObject markInstance;
    private bool isMarkVisible = true; // Aktueller Zustand des Marks (sichtbar/unsichtbar)
    private float blinkTimer = 0f; // Timer für den Blink-Effekt
    private List<Renderer> markRendereres; // Liste der Renderer-Komponenten für den Mark

    // Use this for initialization
    void Start()
    {
        markInstance = Instantiate(markPrefab);
        markRendereres = new List<Renderer>(markInstance.GetComponentsInChildren<Renderer>());

        // Ändere die Farbe des Marks
        ChangeMarkColor(markColor);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMark();
        HandleMarkBlink();
    }

    private void UpdateMark()
    {
        if (targetedObjects != null && targetedObjects.Count > 0)
        {
            int currentIndex = targetedObjects.IndexOf(targetedObject);

            if (currentIndex >= 0 && currentIndex < markOffset.Count)
            {
                // Verwende die Position des Zielobjekts als Ausgangspunkt
                Vector3 markPosition = targetedObject.transform.position;

                // Addiere den Offset zur Y-Koordinate der Zielobjektsposition
                markPosition.y = targetedObject.transform.position.y + markOffset[currentIndex].y;

                // Füge den X-Offset zur X-Koordinate der Zielobjektsposition hinzu
                markPosition += targetedObject.transform.right * markOffset[currentIndex].x;

                markInstance.transform.position = markPosition;

                // Drehe den Mark um seine eigene Achse
                Vector3 markR = markInstance.transform.localEulerAngles;
                markR.y += rotationSpeed * Time.deltaTime;
                markInstance.transform.localEulerAngles = markR;
            }
        }
    }

    /// Handles the Mark blinking effect.
    private void HandleMarkBlink()
    {
        if (markBlinkIntervall <= 0f)
            return;

        blinkTimer += Time.deltaTime;

        if (blinkTimer >= markBlinkIntervall)
        {
            ToggleMarkVisibility();
            blinkTimer = 0f;
        }
    }

    /// Toggles the visibility of the Mark.
    private void ToggleMarkVisibility()
    {
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

    /// Changes the color of the Mark.
    /// <param name="color">The new color of the Mark.</param>
    private void ChangeMarkColor(Color color)
    {
    color.a = markAlpha; // Setze den Alpha-Wert auf 0.5 für halbtransparent

    foreach (Renderer renderer in markRendereres)
    {
        renderer.material.color = color;
    }
    }
}
