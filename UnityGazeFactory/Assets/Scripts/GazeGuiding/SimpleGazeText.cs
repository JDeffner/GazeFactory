using System.Collections.Generic;
using UnityEngine;

public class SimpleGazeText : MonoBehaviour
{
    public Camera vrCamera;
    public GameObject targetedObject;
    public Canvas canvas;
    public string text;
    public string textColor;
    public float textSize;
    public List<GameObject> targetedObjects; 
    public List<Vector3> textOffset;
    public bool isActive;

    void Start()
    {
        canvas.transform.localScale = new Vector3(-0.08f, 0.08f, 0.08f);
    }
    
    void Update()
    {
        changePosition();
        checkIsActive();
        editCanvas();
    }

    private void changePosition()
    {
        int currentIndex = targetedObjects.IndexOf(targetedObject);

        if (currentIndex >= 0 && currentIndex < textOffset.Count)
        {
            Vector3 newPosition = targetedObject.transform.position;
            newPosition.y = targetedObject.transform.position.y + textOffset[currentIndex].y;
            newPosition.z = targetedObject.transform.position.z + textOffset[currentIndex].z;
            newPosition.x = targetedObject.transform.position.x + textOffset[currentIndex].x;

            canvas.GetComponent<RectTransform>().position = newPosition;
        }
    }

    private void checkIsActive()
    {
        if (!isActive)
        {
            canvas.GetComponent<MeshRenderer>().enabled = false;
        }
        else
        {
            canvas.GetComponent<MeshRenderer>().enabled = true;
        }
    }

    private void editCanvas()
    {
        canvas.GetComponent<TextMesh>().text = text;
        canvas.transform.localScale = new Vector3(-textSize, textSize, textSize);
        
        Color color;
        if (ColorUtility.TryParseHtmlString(textColor, out color))
        {
            canvas.GetComponent<TextMesh>().color = color;
        }
    }

    private void LateUpdate()
    {
        Vector3 playerPos = vrCamera.transform.position;
        canvas.transform.LookAt(playerPos);
    }
}

