using System.Collections.Generic;
using UnityEngine;

public class DrawAlphabet : MonoBehaviour
{
    [Header("Alphabet Settings")]
    public GameObject brickPrefab; // Prefab of the brick
    public float brickSize = 1.0f; // Size of each brick
    public char letter = 'A'; // The letter to draw (A-Z)
    public float extroRotationAfterSpawn = 0.0f;

    private Dictionary<char, List<Vector3[]>> alphabetShapes;

    void Start()
    {
        InitializeAlphabetShapes();
        GenerateLetter(letter, transform.position);
        transform.Rotate(0, 0, extroRotationAfterSpawn);
    }

    void InitializeAlphabetShapes()
    {
        alphabetShapes = new Dictionary<char, List<Vector3[]>>();

        // A
        alphabetShapes['A'] = new List<Vector3[]>
        {
            new Vector3[] { new Vector3(-1, -1, 0), new Vector3(0, 1, 0) },
            new Vector3[] { new Vector3(0, 1, 0), new Vector3(1, -1, 0) },
            new Vector3[] { new Vector3(-0.4f, 0, 0), new Vector3(0.4f, 0, 0) }
        };

        // B
        alphabetShapes['B'] = new List<Vector3[]>
        {
            new Vector3[] { new Vector3(-1, -1, 0), new Vector3(-1, 1, 0) },
            new Vector3[] { new Vector3(-1, 1, 0), new Vector3(0, 1, 0) },
            new Vector3[] { new Vector3(0, 1, 0), new Vector3(1, 0.5f, 0) },
            new Vector3[] { new Vector3(1, 0.5f, 0), new Vector3(1, -0.5f, 0) },
            new Vector3[] { new Vector3(1, -0.5f, 0), new Vector3(0, -1, 0) },
            new Vector3[] { new Vector3(0, -1, 0), new Vector3(-1, -1, 0) },
            new Vector3[] { new Vector3(0, 0f, 0), new Vector3(-1, 0f, 0)}
        };

        // C
        alphabetShapes['C'] = new List<Vector3[]>
        {
            new Vector3[] { new Vector3(1, 1, 0), new Vector3(-1, 1, 0) },
            new Vector3[] { new Vector3(-1, 1, 0), new Vector3(-1, -1, 0) },
            new Vector3[] { new Vector3(-1, -1, 0), new Vector3(1, -1, 0) }
        };

        // D
        alphabetShapes['D'] = new List<Vector3[]>
        {
            new Vector3[] { new Vector3(-1, -1, 0), new Vector3(-1, 1, 0) },
            new Vector3[] { new Vector3(-1, 1, 0), new Vector3(0, 1, 0) },
            new Vector3[] { new Vector3(0, 1, 0), new Vector3(1, 0, 0) },
            new Vector3[] { new Vector3(1, 0, 0), new Vector3(0, -1, 0) },
            new Vector3[] { new Vector3(0, -1, 0), new Vector3(-1, -1, 0) }
        };

        // E
        alphabetShapes['E'] = new List<Vector3[]>
        {
            new Vector3[] { new Vector3(1, 1, 0), new Vector3(-1, 1, 0) },
            new Vector3[] { new Vector3(-1, 1, 0), new Vector3(-1, -1, 0) },
            new Vector3[] { new Vector3(-1, -1, 0), new Vector3(1, -1, 0) },
            new Vector3[] { new Vector3(-1, 0, 0), new Vector3(0, 0, 0) }
        };

        // F
        alphabetShapes['F'] = new List<Vector3[]>
        {
            new Vector3[] { new Vector3(-1, 1, 0), new Vector3(1, 1, 0) },
            new Vector3[] { new Vector3(-1, 1, 0), new Vector3(-1, -1, 0) },
            new Vector3[] { new Vector3(-1, 0, 0), new Vector3(0, 0, 0) }
        };

        // G
        alphabetShapes['G'] = new List<Vector3[]>
        {
            new Vector3[] { new Vector3(1, 1, 0), new Vector3(-1, 1, 0) },
            new Vector3[] { new Vector3(-1, 1, 0), new Vector3(-1, -1, 0) },
            new Vector3[] { new Vector3(-1, -1, 0), new Vector3(1, -1, 0) },
            new Vector3[] { new Vector3(1, -1, 0), new Vector3(1, 0, 0) },
            new Vector3[] { new Vector3(0, 0, 0), new Vector3(1, 0, 0) }
        };

        // H
        alphabetShapes['H'] = new List<Vector3[]>
        {
            new Vector3[] { new Vector3(-1, 1, 0), new Vector3(-1, -1, 0) },
            new Vector3[] { new Vector3(1, 1, 0), new Vector3(1, -1, 0) },
            new Vector3[] { new Vector3(-1, 0, 0), new Vector3(1, 0, 0) }
        };

        // I
        alphabetShapes['I'] = new List<Vector3[]>
        {
            new Vector3[] { new Vector3(0, 1, 0), new Vector3(0, -1, 0) },
            new Vector3[] { new Vector3(-1, 1, 0), new Vector3(1, 1, 0) },
            new Vector3[] { new Vector3(-1, -1, 0), new Vector3(1, -1, 0) }
        };

        // J
        alphabetShapes['J'] = new List<Vector3[]>
        {
            new Vector3[] { new Vector3(1, 1, 0), new Vector3(1, -1, 0) },
            new Vector3[] { new Vector3(1, -1, 0), new Vector3(-1, -1, 0) },
            new Vector3[] { new Vector3(-1, -1, 0), new Vector3(-1, 0, 0) }
        };

        // K
        alphabetShapes['K'] = new List<Vector3[]>
        {
            new Vector3[] { new Vector3(-1, 1, 0), new Vector3(-1, -1, 0) },
            new Vector3[] { new Vector3(-1, 0, 0), new Vector3(1, 1, 0) },
            new Vector3[] { new Vector3(-1, 0, 0), new Vector3(1, -1, 0) }
        };

        // L
        alphabetShapes['L'] = new List<Vector3[]>
        {
            new Vector3[] { new Vector3(-1, 1, 0), new Vector3(-1, -1, 0) },
            new Vector3[] { new Vector3(-1, -1, 0), new Vector3(1, -1, 0) }
        };

        // M
        alphabetShapes['M'] = new List<Vector3[]>
        {
            new Vector3[] { new Vector3(-1, -1, 0), new Vector3(-1, 1, 0) },
            new Vector3[] { new Vector3(-1, 1, 0), new Vector3(0, 0, 0) },
            new Vector3[] { new Vector3(0, 0, 0), new Vector3(1, 1, 0) },
            new Vector3[] { new Vector3(1, 1, 0), new Vector3(1, -1, 0) }
        };

        // N
        alphabetShapes['N'] = new List<Vector3[]>
        {
            new Vector3[] { new Vector3(-1, -1, 0), new Vector3(-1, 1, 0) },
            new Vector3[] { new Vector3(-1, 1, 0), new Vector3(1, -1, 0) },
            new Vector3[] { new Vector3(1, -1, 0), new Vector3(1, 1, 0) }
        };

        // O
        alphabetShapes['O'] = new List<Vector3[]>
        {
            new Vector3[] { new Vector3(-1, 1, 0), new Vector3(1, 1, 0) },
            new Vector3[] { new Vector3(1, 1, 0), new Vector3(1, -1, 0) },
            new Vector3[] { new Vector3(1, -1, 0), new Vector3(-1, -1, 0) },
            new Vector3[] { new Vector3(-1, -1, 0), new Vector3(-1, 1, 0) }
        };

        // P
        alphabetShapes['P'] = new List<Vector3[]>
        {
            new Vector3[] { new Vector3(-1, -1, 0), new Vector3(-1, 1, 0) },
            new Vector3[] { new Vector3(-1, 1, 0), new Vector3(0, 1, 0) },
            new Vector3[] { new Vector3(0, 1, 0), new Vector3(1, 0.5f, 0) },
            new Vector3[] { new Vector3(1, 0.5f, 0), new Vector3(0, 0, 0) },
            new Vector3[] { new Vector3(0, 0, 0), new Vector3(-1, 0, 0) }
        };

        // Q
        alphabetShapes['Q'] = new List<Vector3[]>
        {
            new Vector3[] { new Vector3(-1, 1, 0), new Vector3(1, 1, 0) },
            new Vector3[] { new Vector3(1, 1, 0), new Vector3(1, -1, 0) },
            new Vector3[] { new Vector3(1, -1, 0), new Vector3(-1, -1, 0) },
            new Vector3[] { new Vector3(-1, -1, 0), new Vector3(-1, 1, 0) },
            new Vector3[] { new Vector3(0, 0, 0), new Vector3(1, -1, 0) }
        };

        // R
        alphabetShapes['R'] = new List<Vector3[]>
        {
            new Vector3[] { new Vector3(-1, -1, 0), new Vector3(-1, 1, 0) },
            new Vector3[] { new Vector3(-1, 1, 0), new Vector3(0, 1, 0) },
            new Vector3[] { new Vector3(0, 1, 0), new Vector3(1, 0.5f, 0) },
            new Vector3[] { new Vector3(1, 0.5f, 0), new Vector3(0, 0, 0) },
            new Vector3[] { new Vector3(0, 0, 0), new Vector3(-1, 0, 0) },
            new Vector3[] { new Vector3(0, 0, 0), new Vector3(1, -1, 0) }
        };

        // S
        alphabetShapes['S'] = new List<Vector3[]>
        {
            new Vector3[] { new Vector3(1, 1, 0), new Vector3(-1, 1, 0) },
            new Vector3[] { new Vector3(-1, 1, 0), new Vector3(-1, 0, 0) },
            new Vector3[] { new Vector3(-1, 0, 0), new Vector3(1, 0, 0) },
            new Vector3[] { new Vector3(1, 0, 0), new Vector3(1, -1, 0) },
            new Vector3[] { new Vector3(1, -1, 0), new Vector3(-1, -1, 0) }
        };

        // T
        alphabetShapes['T'] = new List<Vector3[]>
        {
            new Vector3[] { new Vector3(0, 1, 0), new Vector3(0, -1, 0) },
            new Vector3[] { new Vector3(-1, 1, 0), new Vector3(1, 1, 0) }
        };

        // U
        alphabetShapes['U'] = new List<Vector3[]>
        {
            new Vector3[] { new Vector3(-1, 1, 0), new Vector3(-1, -1, 0) },
            new Vector3[] { new Vector3(-1, -1, 0), new Vector3(1, -1, 0) },
            new Vector3[] { new Vector3(1, -1, 0), new Vector3(1, 1, 0) }
        };

        // V
        alphabetShapes['V'] = new List<Vector3[]>
        {
            new Vector3[] { new Vector3(-1, 1, 0), new Vector3(0, -1, 0) },
            new Vector3[] { new Vector3(0, -1, 0), new Vector3(1, 1, 0) }
        };

        // W
        alphabetShapes['W'] = new List<Vector3[]>
        {
            new Vector3[] { new Vector3(-1, 1, 0), new Vector3(-0.5f, -1, 0) },
            new Vector3[] { new Vector3(-0.5f, -1, 0), new Vector3(0, 0, 0) },
            new Vector3[] { new Vector3(0, 0, 0), new Vector3(0.5f, -1, 0) },
            new Vector3[] { new Vector3(0.5f, -1, 0), new Vector3(1, 1, 0) }
        };

        // X
        alphabetShapes['X'] = new List<Vector3[]>
        {
            new Vector3[] { new Vector3(-1, 1, 0), new Vector3(1, -1, 0) },
            new Vector3[] { new Vector3(1, 1, 0), new Vector3(-1, -1, 0) }
        };

        // Y
        alphabetShapes['Y'] = new List<Vector3[]>
        {
            new Vector3[] { new Vector3(0, 0, 0), new Vector3(0, -1, 0) },
            new Vector3[] { new Vector3(-1, 1, 0), new Vector3(0, 0, 0) },
            new Vector3[] { new Vector3(0, 0, 0), new Vector3(1, 1, 0) }
        };

        // Z
        alphabetShapes['Z'] = new List<Vector3[]>
        {
            new Vector3[] { new Vector3(-1, 1, 0), new Vector3(1, 1, 0) },
            new Vector3[] { new Vector3(1, 1, 0), new Vector3(-1, -1, 0) },
            new Vector3[] { new Vector3(-1, -1, 0), new Vector3(1, -1, 0) }
        };
    }

    void GenerateLetter(char letter, Vector3 position)
    {
        if (!alphabetShapes.ContainsKey(letter))
        {
            Debug.LogWarning("Letter shape not defined");
            return;
        }

        foreach (var line in alphabetShapes[letter])
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
