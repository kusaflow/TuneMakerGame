using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawStar : MonoBehaviour
{
    [Header("Star Settings")]
    public GameObject brickPrefab; // Prefab of the brick
    public float brickSize = 1.0f; // Size of each brick
    public float radius = 5.0f; // Radius of the star
    public int points = 5; // Number of points in the star
    public float innerRadiusRatio = 0.5f; // Ratio of inner radius to outer radius
    public float extroRotationAfterSpawn = 0.0f;
    //public List<Vector2> ignorePartList;

    void OnEnable()
    {
        GenerateStar(transform.position, radius, points, innerRadiusRatio);
        transform.Rotate(0, 0, extroRotationAfterSpawn);
    }

    public void GenerateStar(Vector3 center, float radius, int points, float innerRadiusRatio)
    {
        float innerRadius = radius * innerRadiusRatio;
        List<Vector3> vertices = new List<Vector3>();

        for (int i = 0; i < points * 2; i++)
        {
            float angle = i * Mathf.PI / points;
            float r = (i % 2 == 0) ? radius : innerRadius;
            Vector3 vertex = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * r + center;
            vertices.Add(vertex);
        }

        for (int i = 0; i < vertices.Count; i++)
        {
            
            Vector3 start = vertices[i];
            Vector3 end = vertices[(i + 1) % vertices.Count];
            GenerateLine(start, end, i);
        }
    }

    private void GenerateLine(Vector3 start, Vector3 end, int idx)
    {
        float distance = Vector3.Distance(start, end);
        int brickCount = Mathf.CeilToInt(distance / brickSize);

        for (int i = 0; i <= brickCount; i++)
        {
            
            //if (ignorePartList.Count > i && i>= ignorePartList[i].x && i <= ignorePartList[i].y)
               // continue;
            

            Vector3 position = Vector3.Lerp(start, end, i / (float)brickCount);
            Quaternion rotation = Quaternion.LookRotation(Vector3.forward, end - start);
            Instantiate(brickPrefab, position, rotation, transform);
        }
    }
}
