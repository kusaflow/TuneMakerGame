using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public enum PowerUpType { AddBall, DoubleBalls, HalfBalls, DirectionalControl, Explosive, IncreaseSize, DecreaseSize, InvincibleBall, IncreaseSpeed, DecreaseSpeed, ReverseStack, RandomizeStack, PowerUpCooldown, BlockRegeneration, Blindfold, StickyBalls }
    public PowerUpType powerUpType;
    public float effectDuration = 5.0f;

    public void ApplyEffect()
    {
        switch (powerUpType)
        {
            case PowerUpType.AddBall:
                BallManager.Instance.SpawnBall(new Vector3(0, 0, 0), new Vector2(1, 1));
                break;
            case PowerUpType.DoubleBalls:
                DuplicateBalls();
                break;
            case PowerUpType.HalfBalls:
                RemoveHalfBalls();
                break;
            case PowerUpType.DirectionalControl:
                // Implement directional control
                break;
            case PowerUpType.Explosive:
                // Implement explosive effect
                break;
            case PowerUpType.IncreaseSize:
                BallManager.Instance.ApplyToAllBalls(ball => ball.GetComponent<Ball>().IncreaseSize(1.5f));
                break;
            case PowerUpType.DecreaseSize:
                BallManager.Instance.ApplyToAllBalls(ball => ball.GetComponent<Ball>().DecreaseSize(0.5f));
                break;
            case PowerUpType.InvincibleBall:
                BallManager.Instance.ApplyToAllBalls(ball => ball.GetComponent<Ball>().MakeInvincible(effectDuration));
                break;
            case PowerUpType.IncreaseSpeed:
                BallManager.Instance.ApplyToAllBalls(ball => ball.GetComponent<Ball>().IncreaseSpeed(1.5f));
                break;
            case PowerUpType.DecreaseSpeed:
                BallManager.Instance.ApplyToAllBalls(ball => ball.GetComponent<Ball>().DecreaseSpeed(0.5f));
                break;
            case PowerUpType.ReverseStack:
                PowerUpManager.Instance.ReverseStack();
                break;
            case PowerUpType.RandomizeStack:
                PowerUpManager.Instance.RandomizeStack();
                break;
            case PowerUpType.PowerUpCooldown:
                // Implement power-up cooldown effect
                break;
            case PowerUpType.BlockRegeneration:
                // Implement block regeneration effect
                break;
            case PowerUpType.Blindfold:
                // Implement blindfold effect
                break;
            case PowerUpType.StickyBalls:
                // Implement sticky balls effect
                break;
        }
    }

    private void DuplicateBalls()
    {
        List<GameObject> balls = BallManager.Instance.GetActiveBalls();
        foreach (GameObject ball in balls)
        {
            BallManager.Instance.SpawnBall(ball.transform.position, ball.GetComponent<Rigidbody2D>().velocity);
        }
    }

    private void RemoveHalfBalls()
    {
        List<GameObject> balls = BallManager.Instance.GetActiveBalls();
        for (int i = 0; i < balls.Count / 2; i++)
        {
            BallManager.Instance.RemoveBall(balls[i]);
        }
    }
}
