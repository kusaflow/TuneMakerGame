using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawRhombus : DrawLine
{
    [Header("Rhombus Settings")]
    public float sideLength = 5.0f;
    public float angle = 45.0f; // Angle between adjacent sides
    public List<Vector2> NeglectParts;

    private void OnEnable()
    {
        GenerateRhombus(transform.position, sideLength, angle);
        transform.Rotate(0, 0, extroRotaionAfterSpawn);
    }

    public void GenerateRhombus(Vector3 center, float sideLength, float angle)
    {
        float radians = angle * Mathf.Deg2Rad;
        Vector3[] corners = {
            center + new Vector3(0, sideLength / 2, 0),
            center + new Vector3(sideLength * Mathf.Cos(radians), sideLength * Mathf.Sin(radians) - sideLength / 2, 0),
            center + new Vector3(0, -sideLength / 2, 0),
            center + new Vector3(-sideLength * Mathf.Cos(radians), sideLength * Mathf.Sin(radians) - sideLength / 2, 0)
        };

        for (int i = 0; i < 4; i++)
        {
            Vector3 start = corners[i];
            Vector3 end = corners[(i + 1) % 4];
            GenerateLine(start, end, transform, NeglectParts[i]);
        }
    }
}
