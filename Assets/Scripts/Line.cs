using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Line : MonoBehaviour
{
    private LineRenderer _lineRenderer;
    private EdgeCollider2D _collider;

    private readonly List<Vector2> points = new List<Vector2>();

    // Maximum number of positions allowed in the LineRenderer
    private const int MAX_POSITION_COUNT = 50;

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _collider = GetComponent<EdgeCollider2D>();
        _collider.transform.position -= transform.position;
    }

    public void SetPosition(Vector2 pos)
    {
        if (_lineRenderer.positionCount >= MAX_POSITION_COUNT) return;

        if (_lineRenderer.positionCount == 0)
        {
            _lineRenderer.positionCount = 1;
        }
        else
        {
            _lineRenderer.positionCount++;
            points.Add(pos);
        }
        _lineRenderer.SetPosition(_lineRenderer.positionCount - 1, pos);
        _collider.points = points.ToArray();
    }

    public void ClearLine()
    {
        _lineRenderer.positionCount = 0;
    }

  
}

