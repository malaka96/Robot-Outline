using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class LevelGenerate : MonoBehaviour
{
    public SpriteShapeController spriteShapeController;
    public Transform carTransform; // Reference to the car's transform
    public float segmentLength = 10f; // Length of each road segment
    public int initialSegments = 5; // Number of segments to generate initially
    public float roadWidth = 5f; // Width variation of the road
    public float deepSideFrequency = 0.1f; // Probability of deep side per segment (0 to 1)
    public float destroyDistanceBehindCar = 30f; // Distance behind the car to destroy road segments

    private float currentXPosition = 0f; // To track the end of the road

    void Start()
    {
        GenerateInitialRoad();
    }

    void Update()
    {
        // Check if the car is near the end of the current road and generate more if needed
        if (carTransform.position.x > currentXPosition - segmentLength * 2)
        {
            GenerateRoadSegment();
        }

        // Check for road segments to destroy
        RemoveOldRoadSegments();
    }

    void GenerateInitialRoad()
    {
        // Clear existing spline points
        Spline spline = spriteShapeController.spline;
        spline.Clear();

        // Create initial road segments
        for (int i = 0; i < initialSegments; i++)
        {
            AddRoadPoint();
        }
    }

    void GenerateRoadSegment()
    {
        // Randomly decide if this segment will be a deep side
        if (Random.value < deepSideFrequency)
        {
            AddDeepSideSegment();
        }
        else
        {
            AddRoadPoint();
        }
    }

    void AddRoadPoint()
    {
        Spline spline = spriteShapeController.spline;
        float yOffset = Random.Range(-roadWidth, roadWidth); // Randomize the Y position for variation
        Vector3 newPoint = new Vector3(currentXPosition, yOffset, 0);
        int pointIndex = spline.GetPointCount();
        spline.InsertPointAt(pointIndex, newPoint); // Add point to the end

        currentXPosition += segmentLength; // Move to the next segment position

        // Set tangent mode to Continuous for all but the first and last points
        SetTangentModeForAllButFirstAndLast();
    }

    void AddDeepSideSegment()
    {
        Spline spline = spriteShapeController.spline;
        float deepSideY = -10f; // Set a Y position for the deep side, making it impassable

        // Start the deep side
        Vector3 startPoint = new Vector3(currentXPosition, deepSideY, 0);
        int startIndex = spline.GetPointCount();
        spline.InsertPointAt(startIndex, startPoint);

        // Move to the next segment position
        currentXPosition += segmentLength;

        // End the deep side
        Vector3 endPoint = new Vector3(currentXPosition, deepSideY, 0);
        int endIndex = spline.GetPointCount();
        spline.InsertPointAt(endIndex, endPoint);

        // Set tangent mode to Continuous for all but the first and last points
        SetTangentModeForAllButFirstAndLast();
    }

    void SetTangentModeForAllButFirstAndLast()
    {
        Spline spline = spriteShapeController.spline;
        int pointCount = spline.GetPointCount();

        for (int i = 1; i < pointCount - 1; i++)
        {
            // Set tangent mode to Continuous
            spline.SetTangentMode(i, ShapeTangentMode.Continuous);

            // Calculate tangents based on surrounding points for smoother curves
            Vector3 pointPos = spline.GetPosition(i);

            // Calculate tangents based on previous and next points
            Vector3 prevPoint = spline.GetPosition(i - 1);
            Vector3 nextPoint = spline.GetPosition(i + 1);

            // Set tangents to be the direction towards the previous and next points
            Vector3 inTangent = (pointPos - prevPoint) * 0.5f; // Scale by 0.5 to smooth the tangent
            Vector3 outTangent = (nextPoint - pointPos) * 0.5f; // Scale by 0.5 to smooth the tangent

            // Assign calculated tangents
            spline.SetLeftTangent(i, inTangent);
            spline.SetRightTangent(i, outTangent);
        }
    }

    void RemoveOldRoadSegments()
    {
        Spline spline = spriteShapeController.spline;

        // Check each point in the spline
        for (int i = spline.GetPointCount() - 1; i >= 0; i--)
        {
            // If the point is behind the car by a certain distance, remove it
            if (carTransform.position.x - spline.GetPosition(i).x > destroyDistanceBehindCar)
            {
                spline.RemovePointAt(i);
            }
        }
    }
}
