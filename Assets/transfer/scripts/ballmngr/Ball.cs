using System.Collections;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb;
    private BallManager ballManager;

    [Space]
    public bool isinVincible = false;
    public GameObject InvincibleGO;

    [Space]
    public bool isShieldOn = false;
    public GameObject Shield_GO;
    public float affected_gravityScale = 2;

    [Space]
    public float minScale = 0.2f; // Minimum scale before the ball is destroyed
    public bool isSplitOn = false;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ballManager = BallManager.Instance;

        InvincibleGO.SetActive(false);
        Shield_GO.SetActive(false);
    }

    private void Update()
    {
        Vector3 currentScale = transform.localScale;
        if (currentScale.x < minScale && currentScale.y < minScale)
        {
            BallManager.Instance.RemoveBall(gameObject);
            // Destroy the original ball
            //Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the ball is in the InvincibleBall layer
        if (gameObject.layer == LayerMask.NameToLayer("InvincibleBall"))
        {
            // Destroy destructible objects on contact
            if (collision.gameObject.layer == LayerMask.NameToLayer("DestructibleObjects"))
            {
                Destroy(collision.gameObject);
            }
        }

        if (isSplitOn)
        {
            Split();
        }
    }

    ///
    private void Split()
    {
        Vector3 currentScale = transform.localScale;

        if (currentScale.x > minScale && currentScale.y > minScale)
        {
            // Calculate new scale
            Vector3 newScale = currentScale * 0.6f;

            // Create two new balls with half the scale
            CreateNewBall(newScale);
            CreateNewBall(newScale);

            BallManager.Instance.RemoveBall(gameObject);
            // Destroy the original ball
            //Destroy(gameObject);
        }
    }

    private void CreateNewBall(Vector3 newScale)
    {
        GameObject newBall = Instantiate(gameObject, transform.position, Quaternion.identity);
        BallManager.Instance.AddTheBall(newBall);


        newBall.transform.localScale = newScale;
        Rigidbody2D rb = newBall.GetComponent<Rigidbody2D>();

        // Apply some force to the new balls to move them apart
        if (rb != null)
        {
            rb.AddForce(new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)) * 5f, ForceMode2D.Impulse);
        }
    }
    ///


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
        transform.localScale *= multiplier;
    }

    public void IncreaseSpeed(float multiplier)
    {
        rb.velocity *= multiplier;
    }

    public void DecreaseSpeed(float multiplier)
    {
        rb.velocity *= multiplier;
    }

    public void MakeInvincible(float duration)
    {
        StartCoroutine(InvincibilityCoroutine(duration));
    }

    private IEnumerator InvincibilityCoroutine(float duration)
    {
        // Store the original layer of the ball
        int originalLayer = gameObject.layer;
        isinVincible = true;
        // Change the ball's layer to InvincibleBall
        gameObject.layer = LayerMask.NameToLayer("InvincibleBall");

        InvincibleGO.SetActive(true);


        yield return new WaitForSeconds(duration);
        // Revert invincibility logic

        // Deactivate visual feedback
        InvincibleGO.SetActive(false);
        isinVincible = false;
        // Revert the ball's layer back to its original
        gameObject.layer = originalLayer;
    }

    public void MakeShieldPowerup(float duration)
    {
        StartCoroutine(IMakeShieldPowerup_Coroutine(duration));
    }

    private IEnumerator IMakeShieldPowerup_Coroutine(float duration)
    {

        isShieldOn = true;
        Shield_GO.SetActive(true);

        yield return new WaitForSeconds(duration);
        // Revert invincibility logic
        Shield_GO.SetActive(false);
        isShieldOn = false;
    }

    public void Add_doubleGravityPower(float duration)
    {
        StartCoroutine(Add_doubleGravityPower_Coroutine(duration));
    }

    private IEnumerator Add_doubleGravityPower_Coroutine(float duration)
    {
        if (rb != null)
        {
            rb.gravityScale = affected_gravityScale;
        }

        yield return new WaitForSeconds(duration);
        // Revert invincibility logic
        if (rb != null)
        {
            rb.gravityScale = 0f;
        }
    }


    void OnDestroy()
    {
        //if(gameObject)
           // ballManager.RemoveBall(gameObject);
    }

    public void isSplitModeOn()
    {
        StartCoroutine(splitPower());
    }

    IEnumerator splitPower()
    {
        isSplitOn = true;
        yield return new WaitForSeconds(10);
        isSplitOn = false;

    }

}
