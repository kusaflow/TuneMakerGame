using System.Collections.Generic;
using UnityEngine;

public class DrawNumber : MonoBehaviour
{
    [Header("Number Settings")]
    public GameObject brickPrefab; // Prefab of the brick
    public float brickSize = 1.0f; // Size of each brick
    public int number = 0; // The number to draw (0-9)
    public float extroRotationAfterSpawn = 0.0f;

    private Dictionary<int, List<Vector3[]>> numberShapes;

    void Start()
    {
        InitializeNumberShapes();
        GenerateNumber(number, transform.position);
        transform.Rotate(0, 0, extroRotationAfterSpawn);
    }

    void InitializeNumberShapes()
    {
        numberShapes = new Dictionary<int, List<Vector3[]>>();

        // Define shapes for numbers 0-9
        numberShapes[0] = new List<Vector3[]>
        {
            new Vector3[] { new Vector3(-1, 1, 0), new Vector3(1, 1, 0) },
            new Vector3[] { new Vector3(1, 1, 0), new Vector3(1, -1, 0) },
            new Vector3[] { new Vector3(1, -1, 0), new Vector3(-1, -1, 0) },
            new Vector3[] { new Vector3(-1, -1, 0), new Vector3(-1, 1, 0) }
        };

        numberShapes[1] = new List<Vector3[]>
        {
            new Vector3[] { new Vector3(0, 1, 0), new Vector3(0, -1, 0) }
        };

        numberShapes[2] = new List<Vector3[]>
        {
            new Vector3[] { new Vector3(-1, 1, 0), new Vector3(1, 1, 0) },
            new Vector3[] { new Vector3(1, 1, 0), new Vector3(1, 0, 0) },
            new Vector3[] { new Vector3(1, 0, 0), new Vector3(-1, 0, 0) },
            new Vector3[] { new Vector3(-1, 0, 0), new Vector3(-1, -1, 0) },
            new Vector3[] { new Vector3(-1, -1, 0), new Vector3(1, -1, 0) }
        };

        numberShapes[3] = new List<Vector3[]>
        {
            new Vector3[] { new Vector3(-1, 1, 0), new Vector3(1, 1, 0) },
            new Vector3[] { new Vector3(1, 1, 0), new Vector3(1, -1, 0) },
            new Vector3[] { new Vector3(1, 0, 0), new Vector3(-1, 0, 0) },
            new Vector3[] { new Vector3(1, -1, 0), new Vector3(-1, -1, 0) }
        };

        numberShapes[4] = new List<Vector3[]>
        {
            new Vector3[] { new Vector3(-1, 1, 0), new Vector3(-1, 0, 0) },
            new Vector3[] { new Vector3(-1, 0, 0), new Vector3(1, 0, 0) },
            new Vector3[] { new Vector3(1, 1, 0), new Vector3(1, -1, 0) }
        };

        numberShapes[5] = new List<Vector3[]>
        {
            new Vector3[] { new Vector3(1, 1, 0), new Vector3(-1, 1, 0) },
            new Vector3[] { new Vector3(-1, 1, 0), new Vector3(-1, 0, 0) },
            new Vector3[] { new Vector3(-1, 0, 0), new Vector3(1, 0, 0) },
            new Vector3[] { new Vector3(1, 0, 0), new Vector3(1, -1, 0) },
            new Vector3[] { new Vector3(1, -1, 0), new Vector3(-1, -1, 0) }
        };

        numberShapes[6] = new List<Vector3[]>
        {
            new Vector3[] { new Vector3(1, 1, 0), new Vector3(-1, 1, 0) },
            new Vector3[] { new Vector3(-1, 1, 0), new Vector3(-1, -1, 0) },
            new Vector3[] { new Vector3(-1, -1, 0), new Vector3(1, -1, 0) },
            new Vector3[] { new Vector3(1, -1, 0), new Vector3(1, 0, 0) },
            new Vector3[] { new Vector3(1, 0, 0), new Vector3(-1, 0, 0) }
        };

        numberShapes[7] = new List<Vector3[]>
        {
            new Vector3[] { new Vector3(-1, 1, 0), new Vector3(1, 1, 0) },
            new Vector3[] { new Vector3(1, 1, 0), new Vector3(0, -1, 0) }
        };

        numberShapes[8] = new List<Vector3[]>
        {
            new Vector3[] { new Vector3(-1, 1, 0), new Vector3(1, 1, 0) },
            new Vector3[] { new Vector3(1, 1, 0), new Vector3(1, -1, 0) },
            new Vector3[] { new Vector3(1, -1, 0), new Vector3(-1, -1, 0) },
            new Vector3[] { new Vector3(-1, -1, 0), new Vector3(-1, 1, 0) },
            new Vector3[] { new Vector3(-1, 0, 0), new Vector3(1, 0, 0) }
        };

        numberShapes[9] = new List<Vector3[]>
        {
            new Vector3[] { new Vector3(-1, -1, 0), new Vector3(1, -1, 0) },
            new Vector3[] { new Vector3(1, -1, 0), new Vector3(1, 1, 0) },
            new Vector3[] { new Vector3(1, 1, 0), new Vector3(-1, 1, 0) },
            new Vector3[] { new Vector3(-1, 1, 0), new Vector3(-1, 0, 0) },
            new Vector3[] { new Vector3(-1, 0, 0), new Vector3(1, 0, 0) }
        };
    }

    void GenerateNumber(int number, Vector3 position)
    {
        if (!numberShapes.ContainsKey(number))
        {
            Debug.LogWarning("Number shape not defined");
            return;
        }

        foreach (var line in numberShapes[number])
        {
            GenerateLine(line[0] + position, line[1] + position);
        }
    }

    private void GenerateLine(Vector3 start, Vector3 end)
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
