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
    public List<Vector3> cursorRotationOffsets; // Liste der Richtungen, aus denen der Cursor erscheinen soll
    public List<Vector3> cursorOffsets; // Liste der Verschiebungen für den Cursor
    public float cursorBlinkInterval = 0.5f; // Intervall zwischen den Blink-Zustandsänderungen in Sekunden
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

    /// Updates the cursor based on what the camera is pointed at.
    private void UpdateCursor()
    {
        if (targetedObjects != null && targetedObjects.Count > 0)
        {
            int currentIndex = targetedObjects.IndexOf(targetedObject);

            if (currentIndex >= 0 && currentIndex < cursorRotationOffsets.Count && currentIndex < cursorOffsets.Count)
            {
                Vector3 cursorPosition = targetedObject.transform.position + (targetedObject.transform.up * cursorOffsets[currentIndex].y) + (targetedObject.transform.right * cursorOffsets[currentIndex].x) + (targetedObject.transform.forward * cursorOffsets[currentIndex].z);
                cursorInstance.transform.position = cursorPosition;

                Quaternion targetRotation = Quaternion.LookRotation(targetedObject.transform.forward, targetedObject.transform.up) * Quaternion.Euler(cursorRotationOffsets[currentIndex]);
                cursorInstance.transform.rotation = targetRotation;
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
