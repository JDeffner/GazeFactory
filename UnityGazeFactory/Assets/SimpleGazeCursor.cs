using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class SimpleGazeCursor : MonoBehaviour {

    public GameObject targetObject;
    public Camera viewCamera;
    public GameObject cursorPrefab;
    public float maxCursorDistance = 30;
    public List<GameObject> targetObjects; // Liste der Zielobjekte
    public List<Vector3> cursorRotationOffsets; // Liste der Richtungen, aus denen der Cursor erscheinen soll
    public List<Vector3> cursorOffsets; // Liste der Verschiebungen für den Cursor

    public float cursorBlinkInterval = 0.5f; // Intervall zwischen den Blink-Zustandsänderungen in Sekunden

    public Color cursorColor = Color.white; // Farbe des Cursors
    public float cursorAlpha = 0.3f; // Transparenz Level 0 is vollkommen Transparent 1 ist vollkommen sichtbar
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

    /// <summary>
    /// Updates the cursor based on what the camera is pointed at.
    /// </summary>
    private void UpdateCursor()
    {
        if (targetObjects != null && targetObjects.Count > 0)
        {
            int currentIndex = targetObjects.IndexOf(targetObject);

            if (currentIndex >= 0 && currentIndex < cursorRotationOffsets.Count && currentIndex < cursorOffsets.Count)
            {
                Vector3 cursorPosition = targetObject.transform.position + (targetObject.transform.up * cursorOffsets[currentIndex].y) + (targetObject.transform.right * cursorOffsets[currentIndex].x) + (targetObject.transform.forward * cursorOffsets[currentIndex].z);
                cursorInstance.transform.position = cursorPosition;

                Quaternion targetRotation = Quaternion.LookRotation(targetObject.transform.forward, targetObject.transform.up) * Quaternion.Euler(cursorRotationOffsets[currentIndex]);
                cursorInstance.transform.rotation = targetRotation;
            }
        }
    }

    /// <summary>
    /// Handles the cursor blinking effect.
    /// </summary>
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

    /// <summary>
    /// Toggles the visibility of the cursor.
    /// </summary>
    private void ToggleCursorVisibility()
    {
        isCursorVisible = !isCursorVisible;

        foreach (Renderer renderer in cursorRenderers)
        {
            renderer.enabled = isCursorVisible;
        }
    }

    /// <summary>
    /// Changes the color of the cursor.
    /// </summary>
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
