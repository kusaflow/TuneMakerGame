using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    public GameObject ballPrefab; // Prefab of the ball
    private List<GameObject> activeBalls = new List<GameObject>();
    private List<float> preservedSpeed = new List<float>();

    public int ballCount { get { return activeBalls.Count; } }

    public int BallLimitInTheScene = 500;

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
    public void SpawnBall_random()
    {
        if (ballCount >= BallLimitInTheScene)
            return;

        Vector2 position = new Vector2(Random.Range(-15.0f, 12.0f), Random.Range(-20.0f, 30.0f));
        Vector2 initialVelocity = new Vector2(Random.Range(-45.0f, 45.0f), Random.Range(-45.0f, 45.0f));

        GameObject newBall = Instantiate(ballPrefab, position, Quaternion.identity);
        Rigidbody2D rb = newBall.GetComponent<Rigidbody2D>();

        rb.velocity = initialVelocity;
        activeBalls.Add(newBall);
    }

    // Spawns a new ball and adds it to the active balls list
    public void SpawnBall(Vector3 position, Vector2 initialVelocity)
    {

        if (ballCount >= BallLimitInTheScene)
            return;

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

    // Sets the direction of all balls towards a target position
    public void SetBallsDirection(Vector3 targetPosition)
    {
        int i = 0;
        foreach (GameObject ball in activeBalls)
        {
            Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();

            // get speed from rb
            //float speed = rb.velocity.magnitude;


            Vector2 direction = (targetPosition - ball.transform.position).normalized;
            rb.velocity = direction * preservedSpeed[i];
            //rb.velocity = direction * speed;
            i++;
        }

        preservedSpeed.Clear();

    }

    //preserve the velocity of the balls
    public void PreserveSpeed()
    {
        preservedSpeed.Clear();
        foreach (GameObject ball in activeBalls)
        {
            Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();
            preservedSpeed.Add(rb.velocity.magnitude);
            //set current velocity to 0
            rb.velocity = Vector2.zero;
        }
    }

    //random direction to each ball
    public void setRandomDirectionWithSameSpeed()
    {
        foreach(GameObject ball in activeBalls)
        {
            Rigidbody2D rb = ball.GetComponent<Rigidbody2D> ();
            float speed = rb.velocity.magnitude;
            Vector3 targetPosition = new Vector3(Random.Range(-15.0f, 12.0f), Random.Range(-20.0f, 30.0f), 0);
            Vector2 direction = (targetPosition - ball.transform.position).normalized;
            rb.velocity = direction * speed;

        }

    }



}
