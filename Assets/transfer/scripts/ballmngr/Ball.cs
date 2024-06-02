using System.Collections;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb;
    private BallManager ballManager;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ballManager = BallManager.Instance;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Brick"))
        {
            //collision.gameObject.GetComponent<Brick>().Break();
        }
    }

    public void SetVelocity(Vector2 velocity)
    {
        rb.velocity = velocity;
    }

    public void IncreaseSize(float multiplier)
    {
        transform.localScale *= multiplier;
    }

    public void DecreaseSize(float multiplier)
    {
        transform.localScale /= multiplier;
    }

    public void IncreaseSpeed(float multiplier)
    {
        rb.velocity *= multiplier;
    }

    public void DecreaseSpeed(float multiplier)
    {
        rb.velocity /= multiplier;
    }

    public void MakeInvincible(float duration)
    {
        StartCoroutine(InvincibilityCoroutine(duration));
    }

    private IEnumerator InvincibilityCoroutine(float duration)
    {
        // Implement invincibility logic (e.g., disable collisions)
        yield return new WaitForSeconds(duration);
        // Revert invincibility logic
    }

    void OnDestroy()
    {
        ballManager.RemoveBall(gameObject);
    }
}
