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
            float ballSize = collision.gameObject.transform.localScale.x/.8f;
            int damage = Mathf.RoundToInt(damagePerHit * ballSize * sizeMultiplier);

            health -= damage;

            float mulForColor = health / 100.0f;
            Debug.Log(mulForColor);
            GetComponent<SpriteRenderer>().color = new Color(color.r* mulForColor, color.g* mulForColor, color.b * mulForColor, 1);

            if (health <= 0)
            {
                Destroy(gameObject);
            }

            Destroy(collision.gameObject);
        }
    }
}
