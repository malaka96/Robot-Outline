using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawManager : MonoBehaviour
{
    private Camera _camera;
    [SerializeField] private Line _linePrefab;
    private Line currentLine;
    public bool _canDraw;
    public static bool _drawingStop = true;

    public const float RESOLUTION = .01f;



    void Start()
    {
        _camera = Camera.main;
    }


    void Update()
    {
        if (_canDraw)
        {
            if (_drawingStop) return;

            Vector2 mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);

            if (Input.GetMouseButtonDown(1))
            {
                // Clear the previous line if it exists
                if (currentLine != null)
                {
                    currentLine.ClearLine();
                    Destroy(currentLine.gameObject);
                }

                // Create a new line
                currentLine = Instantiate(_linePrefab, mousePos, Quaternion.identity);
            }

            if (Input.GetMouseButton(1) && currentLine != null)
            {
                currentLine.SetPosition(mousePos);
            }
        }
    }//update

    public void ClearOldLines()
    {
        if (currentLine != null)
        {
            currentLine.ClearLine();
            Destroy(currentLine.gameObject);
            currentLine = null;
        }
    }

}
