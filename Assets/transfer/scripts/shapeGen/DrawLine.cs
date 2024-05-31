using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    [Header("Line Settings")]
    public GameObject brickPrefab; // Prefab of the brick
    public float brickSize = 1.0f; // Size of each brick

    public Vector3 start= new Vector3(0, 0, 0); // Start and end points of the line

    public Vector3 end = new Vector3(5, 5, 5);

    public float extroRotaionAfterSpawn = 0.0f;

    public Vector2 ignorePart;

    public bool drawLine = false;

    void OnEnable()
    {
        if (drawLine)
        {
            GenerateLine(start, end, transform, ignorePart); // Example: Generate a line from (0, 0, 0) to (5, 5, 5)
            transform.transform.Rotate(0, 0, extroRotaionAfterSpawn);
        }
    }
    public void GenerateLine(Vector3 start, Vector3 end, Transform parent, Vector2 ignorePart)
    {
        float distance = Vector3.Distance(start, end);
        int brickCount = Mathf.CeilToInt(distance / brickSize);

        for (int i = 0; i <= brickCount; i++)
        {
            if (i>= ignorePart.x && i <= ignorePart.y)
                continue;
            Vector3 position = Vector3.Lerp(start, end, i / (float)brickCount);
            Quaternion rotation = Quaternion.LookRotation(Vector3.forward, end - start);
            Instantiate(brickPrefab, position, rotation, parent);
        }
    }
}
