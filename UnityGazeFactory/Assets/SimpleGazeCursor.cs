using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class SimpleGazeCursor : MonoBehaviour {

    public GameObject targetedObject;
    public Camera viewCamera;
    public GameObject cursorPrefab;
    public float maxCursorDistance = 30;
    public List<GameObject> targetedObjects; // Liste der Zielobjekte
    public List<Vector3> cursorOffsets; // Liste der Verschiebungen für den Cursor
    public float cursorBlinkInterval = 0.5f; // Intervall zwischen den Blink-Zustandsänderungen in Sekunden
    public float rotationSpeed = 10f; // Geschwindigkeit der Rotation
    public Color cursorColor = Color.white; // Farbe des Cursors
    public float cursorAlpha = 0.3f; // Transparenz Level 0 is vollkommen Transparent 1 ist vollkommen sichtbar
    public bool isActive = false;
    private GameObject cursorInstance;
    private bool isCursorVisible = true; // Aktueller Zustand des Cursors (sichtbar/unsichtbar)
    private float blinkTimer = 0f; // Timer für den Blink-Effekt
    private List<Renderer> cursorRenderers; // Liste der Renderer-Komponenten für den Cursor

    // Use this for initialization
    void Start()
    {
        cursorInstance = Instantiate(cursorPrefab);
        cursorRenderers = new List<Renderer>(cursorInstance.GetComponentsInChildren<Renderer>());

        // Ändere die Farbe des Cursors
        ChangeCursorColor(cursorColor);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCursor();
        HandleCursorBlink();
    }

    private void UpdateCursor()
    {
        if (targetedObjects != null && targetedObjects.Count > 0)
        {
            int currentIndex = targetedObjects.IndexOf(targetedObject);

            if (currentIndex >= 0 && currentIndex < cursorOffsets.Count)
            {
                // Verwende die Position des Zielobjekts als Ausgangspunkt
                Vector3 cursorPosition = targetedObject.transform.position;

                // Addiere den Offset zur Y-Koordinate der Zielobjektsposition
                cursorPosition.y = targetedObject.transform.position.y + cursorOffsets[currentIndex].y;

                // Füge den X-Offset zur X-Koordinate der Zielobjektsposition hinzu
                cursorPosition += targetedObject.transform.right * cursorOffsets[currentIndex].x;

                cursorInstance.transform.position = cursorPosition;

                // Drehe den Cursor um seine eigene Achse
                Vector3 cursorRotation = cursorInstance.transform.localEulerAngles;
                cursorRotation.y += rotationSpeed * Time.deltaTime;
                cursorInstance.transform.localEulerAngles = cursorRotation;
            }
        }
    }

    /// Handles the cursor blinking effect.
    private void HandleCursorBlink()
    {
        if (cursorBlinkInterval <= 0f)
            return;

        blinkTimer += Time.deltaTime;

        if (blinkTimer >= cursorBlinkInterval)
        {
            ToggleCursorVisibility();
            blinkTimer = 0f;
        }
    }

    /// Toggles the visibility of the cursor.
    private void ToggleCursorVisibility()
    {
        if (isActive == false) {
            isCursorVisible = false;
        } else {
            isCursorVisible = !isCursorVisible;
        }   

        foreach (Renderer renderer in cursorRenderers)
        {
            renderer.enabled = isCursorVisible;
        }
    }

    /// Changes the color of the cursor.
    /// <param name="color">The new color of the cursor.</param>
    private void ChangeCursorColor(Color color)
    {
    color.a = cursorAlpha; // Setze den Alpha-Wert auf 0.5 für halbtransparent

    foreach (Renderer renderer in cursorRenderers)
    {
        renderer.material.color = color;
    }
    }
}
