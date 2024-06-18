using UnityEngine;

public class Spike : MonoBehaviour
{
    public int health = 100;
    public int damagePerHit = 20;
    public float sizeMultiplier = 1.0f; // Multiplier for damage based on ball size

    [Space]
    public Color color = Color.white;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Ball ball = collision.gameObject.GetComponent<Ball>();
            if (!ball)
                return;

            if (AudioStackMngr.Instance.stack.Count <= 2)
                AudioStackMngr.Instance.stack.Enqueue(GetComponent<AudioSource>().clip);

            if (ball.isinVincible)
            {
                Destroy(gameObject);
                return;
            }

            float ballSize = collision.gameObject.transform.localScale.x/.8f;
            int damage = Mathf.RoundToInt(damagePerHit * ballSize * sizeMultiplier);


            
            health -= damage;

            float mulForColor = health / 100.0f;
            //Debug.Log(mulForColor);
            GetComponent<SpriteRenderer>().color = new Color(color.r* mulForColor, color.g* mulForColor, color.b * mulForColor, 1);

            if (health <= 0)
            {
                Destroy(gameObject);
            }

            if (!ball.isShieldOn)
            {
                ScoreManager.Instance.AddScore(-2*ScoreManager.Instance.scorePerBlock);
                Destroy(collision.gameObject);
            }
        }
    }
}
