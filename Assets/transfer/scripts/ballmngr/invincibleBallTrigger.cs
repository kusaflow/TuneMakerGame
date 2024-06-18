using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invincibleBallTrigger : MonoBehaviour
{
    public GameObject ballParent;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (ballParent.layer == LayerMask.NameToLayer("InvincibleBall"))
        {
            // Destroy destructible objects on contact
            if (other.gameObject.layer == LayerMask.NameToLayer("DestructibleObjects"))
            {
                ScoreManager.Instance.AddScore(ScoreManager.Instance.scorePerBlock);
                Destroy(other.gameObject);
            }
        }
        
    }
}
