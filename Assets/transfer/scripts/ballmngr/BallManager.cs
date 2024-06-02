using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    public GameObject ballPrefab; // Prefab of the ball
    private List<GameObject> activeBalls = new List<GameObject>();

    public static BallManager Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Spawns a new ball and adds it to the active balls list
    public void SpawnBall(Vector3 position, Vector2 initialVelocity)
    {
        GameObject newBall = Instantiate(ballPrefab, position, Quaternion.identity);
        Rigidbody2D rb = newBall.GetComponent<Rigidbody2D>();
        rb.velocity = initialVelocity;
        activeBalls.Add(newBall);
    }

    // Removes a ball from the active balls list
    public void RemoveBall(GameObject ball)
    {
        activeBalls.Remove(ball);
        Destroy(ball);
    }

    // Applies a global change to all active balls
    public void ApplyToAllBalls(System.Action<GameObject> action)
    {
        foreach (GameObject ball in activeBalls)
        {
            action(ball);
        }
    }

    // Returns the list of all active balls
    public List<GameObject> GetActiveBalls()
    {
        return new List<GameObject>(activeBalls);
    }
}
