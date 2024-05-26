using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawSineWave : MonoBehaviour
{
    [Header("Sine Wave Settings")]
    public GameObject brickPrefab; // Prefab of the brick
    public float brickSize = 1.0f; // Size of each brick
    public float amplitude = 1.0f; // Amplitude of the sine wave
    public float wavelength = 2.0f; // Wavelength of the sine wave
    public float length = 10.0f; // Total length of the sine wave
    public int brickCount = 50; // Number of bricks to use
    public float extroRotationAfterSpawn = 0.0f;
    public List<Vector2> ignorePartList;

    void OnEnable()
    {
        GenerateSineWave(transform.position, amplitude, wavelength, length, brickCount);
        transform.Rotate(0, 0, extroRotationAfterSpawn);
    }

    public void GenerateSineWave(Vector3 start, float amplitude, float wavelength, float length, int brickCount)
    {
        for (int i = 0; i <= brickCount; i++)
        {
            bool doSkip = false;
            foreach(Vector2 ignorePart in ignorePartList)
                if (i >= ignorePart.x && i <= ignorePart.y)
                    doSkip = true;
            if (doSkip)
                continue;

            float x = i * (length / brickCount);
            float y = amplitude * Mathf.Sin((2 * Mathf.PI / wavelength) * x);
            Vector3 position = new Vector3(x, y, 0) + start;
            Quaternion rotation = Quaternion.identity;
            Instantiate(brickPrefab, position, rotation, transform);
        }
    }
}
