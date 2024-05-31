using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawTrapezium : DrawLine
{
    [Header("Trapezium Settings")]
    public float topWidth = 4.0f;
    public float bottomWidth = 6.0f;
    public float height = 3.0f;
    public List<Vector2> NeglectParts;

    private void OnEnable()
    {
        GenerateTrapezium(transform.position, topWidth, bottomWidth, height);
        transform.Rotate(0, 0, extroRotaionAfterSpawn);
    }

    public void GenerateTrapezium(Vector3 center, float topWidth, float bottomWidth, float height)
    {
        Vector3[] corners = {
            center + new Vector3(-topWidth / 2, height / 2, 0),
            center + new Vector3(topWidth / 2, height / 2, 0),
            center + new Vector3(bottomWidth / 2, -height / 2, 0),
            center + new Vector3(-bottomWidth / 2, -height / 2, 0)
        };

        for (int i = 0; i < 4; i++)
        {
            Vector3 start = corners[i];
            Vector3 end = corners[(i + 1) % 4];
            GenerateLine(start, end, transform, NeglectParts[i]);
        }
    }
}
