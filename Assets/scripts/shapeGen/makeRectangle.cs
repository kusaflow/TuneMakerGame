using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makeRectangle : DrawLine
{
    [Header("Rectangle Settings")]
    public float width;
    public float height;

    public List<Vector2> NeglectParts;

    private void OnEnable()
    {
        GenerateRectangle(transform.position, width, height); // Example: Generate a square at the origin
        transform.transform.Rotate(0, 0, extroRotaionAfterSpawn);
    }

    public void GenerateRectangle(Vector3 center, float width, float height)
    {
        Vector3[] corners = {
        center + new Vector3(-width / 2, -height / 2, 0),
        center + new Vector3(width / 2, -height / 2, 0),
        center + new Vector3(width / 2, height / 2, 0),
        center + new Vector3(-width / 2, height / 2, 0)
    };

        for (int i = 0; i < 4; i++)
        {
            Vector3 start = corners[i];
            Vector3 end = corners[(i + 1) % 4];
            GenerateLine(start, end, transform, NeglectParts[i]);
        }
    }


}
