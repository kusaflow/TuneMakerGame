using System.Collections.Generic;
using UnityEngine;

public class PowerUp 
{
    public enum PowerUpType { 
        ///helper enum for powerup types
        AddBall=0, DoubleBalls, DirectionalControl, Explosive, 
        IncreaseSize, InvincibleBall, IncreaseSpeed, Shield, 
        slowMotion, magnet, tripleScrore, DoubleScore, 
        ExtraBounce, SplitBallOnCollision, extraTime,
    
        //Adverse Powers
        DecreaseSize, DecreaseSpeed, HalfBalls,
        RandomDirection, DoubleGravity,ReverseStack, 
        RandomizeStack, BlockRegeneration, popTop2Powers, 
        popTop4Powers
    }

    
    //contructor
    public PowerUp(PowerUpType powerUpType)
    {
        this.powerUpType = powerUpType;
    }

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
                Debug.Log("TODO : Direction control");
                // Implement directional control
                break;
            case PowerUpType.Explosive:
                Debug.Log("TODO : Explosive");
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
                BallManager.Instance.ApplyToAllBalls(ball => ball.GetComponent<Ball>().DecreaseSpeed(.5f));
                break;
            case PowerUpType.ReverseStack:
                PowerUpManager.Instance.ReverseStack();
                break;
            case PowerUpType.RandomizeStack:
                PowerUpManager.Instance.RandomizeStack();
                break;
            case PowerUpType.BlockRegeneration:
                // Implement block regeneration effect
                break;
            
        }
    }

    private void DuplicateBalls()
    {
        List<GameObject> balls = BallManager.Instance.GetActiveBalls();
        foreach (GameObject ball in balls)
        {
            BallManager.Instance.SpawnBall(ball.transform.position, ball.GetComponent<Rigidbody2D>().velocity*-1);
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

    //get the hint for the powerup
    public string GetHint(PowerUpType power)
    {
        string retStr;
        globalStatic.powerUpHints.TryGetValue(power, out retStr);

        return retStr;
    }
}
