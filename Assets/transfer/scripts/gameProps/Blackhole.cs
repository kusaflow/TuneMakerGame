using System.Collections;
using UnityEngine;

public class Blackhole : MonoBehaviour
{
    public float activeDuration = 2.0f;
    public float suckRadius = 5.0f;
    public float suckForce = 10.0f;
    public float triggerRadius = 0.5f; // Radius of the trigger collider

    Animator animator;

    private CircleCollider2D triggerCollider;

    void Start()
    {
        // Add and configure the trigger collider
        triggerCollider = gameObject.AddComponent<CircleCollider2D>();
        triggerCollider.isTrigger = true;
        triggerCollider.radius = triggerRadius;
        animator = GetComponentInChildren<Animator>();
        animator.Play("init");

        Invoke("Deactivate", activeDuration);
    }

    void Update()
    {
        Collider2D[] objectsToSuck = Physics2D.OverlapCircleAll(transform.position, suckRadius);

        foreach (Collider2D obj in objectsToSuck)
        {
            if (obj.CompareTag("Ball"))
            {
                Vector2 direction = (transform.position - obj.transform.position).normalized;
                obj.GetComponent<Rigidbody2D>().AddForce(direction * suckForce);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            Destroy(other.gameObject);
        }
    }

    void Deactivate()
    {
        animator.Play("Exit");
        StartCoroutine(DestroyTheGameObject());
    }

    IEnumerator DestroyTheGameObject()
    {
        activeDuration = 0;
        suckForce = 0;
        suckRadius = 0;
        triggerRadius = 0;
        yield return new WaitForSeconds(1.0f);
        Destroy(gameObject);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, suckRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, triggerRadius);
    }
}
