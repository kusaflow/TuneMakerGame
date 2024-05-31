using UnityEngine;

public class ShapeGenerator : MonoBehaviour
{
    public GameObject brickPrefab; // Prefab of the brick
    public float brickSize = 1.0f; // Size of each brick

    void OnEnable()
    {
        GenerateCircle(Vector3.zero, 5, 100); // Example: Generate a circle at the origin
        GenerateSquare(Vector3.zero, 5);     // Example: Generate a square at the origin
        GenerateTriangle(Vector3.zero, 5);   // Example: Generate a triangle at the origin
    }

    public void GenerateCircle(Vector3 center, float radius, int brickCount)
    {
        for (int i = 0; i < brickCount; i++)
        {
            float angle = i * Mathf.PI * 2 / brickCount;
            Vector3 position = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * radius + center;
            Instantiate(brickPrefab, position, Quaternion.identity, transform);
        }
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
            GenerateLine(start, end);
        }
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
            GenerateLine(start, end);
        }
    }

    public void GenerateLine(Vector3 start, Vector3 end)
    {
        float distance = Vector3.Distance(start, end);
        int brickCount = Mathf.CeilToInt(distance / brickSize);

        for (int i = 0; i <= brickCount; i++)
        {
            Vector3 position = Vector3.Lerp(start, end, i / (float)brickCount);
            Quaternion rotation = Quaternion.LookRotation(Vector3.forward, end - start);
            Instantiate(brickPrefab, position, rotation, transform);
        }
    }
}
