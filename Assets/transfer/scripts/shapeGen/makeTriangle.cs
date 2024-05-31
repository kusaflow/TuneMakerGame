using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makeTriangle : DrawLine
{
    [Header("Triangle Settings")]
    public float _sideLength = 6;
    private void OnEnable()
    {
        GenerateTriangle(transform.position, _sideLength); // Example: Generate a triangle at the origin
        transform.transform.Rotate(0, 0, extroRotaionAfterSpawn);
    }
    public void GenerateTriangle(Vector3 center, float sideLength)
    {
        Vector3[] corners = {
            center + new Vector3(0, sideLength / Mathf.Sqrt(3), 0),
            center + new Vector3(-sideLength / 2, -sideLength / (2 * Mathf.Sqrt(3)), 0),
            center + new Vector3(sideLength / 2, -sideLength / (2 * Mathf.Sqrt(3)), 0)
        };

        for (int i = 0; i < 3; i++)
        {
            Vector3 start = corners[i];
            Vector3 end = corners[(i + 1) % 3];
            GenerateLine(start, end, transform, new Vector2(0,0));
        }
    }
}
