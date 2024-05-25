using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makeRectangle : DrawLine
{

    private void OnEnable()
    {
        GenerateSquare(Vector3.zero, 5); // Example: Generate a square at the origin
    }

    public void GenerateSquare(Vector3 center, float sideLength)
    {
        Vector3[] corners = {
            center + new Vector3(-sideLength / 2, -sideLength / 2, 0),
            center + new Vector3(sideLength / 2, -sideLength / 2, 0),
            center + new Vector3(sideLength / 2, sideLength / 2, 0),
            center + new Vector3(-sideLength / 2, sideLength / 2, 0)
        };

        for (int i = 0; i < 4; i++)
        {
            Vector3 start = corners[i];
            Vector3 end = corners[(i + 1) % 4];
            GenerateLine(start, end, transform);
        }
    }
}
