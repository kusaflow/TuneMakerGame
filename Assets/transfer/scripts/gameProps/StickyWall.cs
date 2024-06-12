using System.Collections;
using UnityEngine;

public class StickyWall : MonoBehaviour
{
    public float stickDuration = 2.0f;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            StartCoroutine(StickBall(collision.gameObject));
        }
    }

    private IEnumerator StickBall(GameObject ball)
    {
        Rigidbody2D ballRigidbody = ball.GetComponent<Rigidbody2D>();
        if (ballRigidbody != null)
        {
            Vector2 originalVelocity = ballRigidbody.velocity;
            ballRigidbody.velocity = Vector2.zero;
            ballRigidbody.isKinematic = true;

            yield return new WaitForSeconds(stickDuration);

            ballRigidbody.isKinematic = false;
            ballRigidbody.velocity = originalVelocity;
        }
    }
}
