using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    public GameObject cursorPrefab; // Link your prefab here in the Unity editor
    private GameObject currentCursorInstance;

    public void SpawnCursor(Vector3 position)
    {
        if (currentCursorInstance == null)
        {
            currentCursorInstance = Instantiate(cursorPrefab, position, Quaternion.identity);
        }
    }

    public void DestroyCursor()
    {
        if (currentCursorInstance != null)
        {
            Destroy(currentCursorInstance);
            currentCursorInstance = null;
        }
    }
}
