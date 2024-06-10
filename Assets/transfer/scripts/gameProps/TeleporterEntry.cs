using System.Collections;
using UnityEngine;

public class TeleporterEntry : MonoBehaviour
{
    public Transform exitPoint; // The exit point linked to this entry point

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            Rigidbody2D ballRigidbody = other.GetComponent<Rigidbody2D>();
            if (ballRigidbody != null)
            {
                StartCoroutine(TeleportBall(other.gameObject, ballRigidbody));
            }
        }
    }

    private IEnumerator TeleportBall(GameObject ball, Rigidbody2D ballRigidbody)
    {
        // Disable the ball's collider to prevent multiple triggers
        Collider2D ballCollider = ball.GetComponent<Collider2D>();
        ballCollider.enabled = false;

        // Store the ball's current velocity
        Vector2 currentVelocity = ballRigidbody.velocity;

        // Wait for a frame to ensure the ball has exited the entry collider
        yield return null;

        // Move the ball to the exit point
        ball.transform.position = exitPoint.position;

        // Restore the ball's velocity
        ballRigidbody.velocity = currentVelocity;

        // Re-enable the ball's collider
        ballCollider.enabled = true;
    }
}
