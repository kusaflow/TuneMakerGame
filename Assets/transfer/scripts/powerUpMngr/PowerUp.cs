using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp
{
    //magnet is regen block and make them spike

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
        popTop4Powers,


        EOL
    }

    
    
    public PowerUpType powerUpType;
    public float effectDuration = 10.0f;


    //contructor
    public PowerUp(PowerUpType powerUpType)
    {
        this.powerUpType = powerUpType;
    }

    public void ApplyEffect()
    {
        switch (powerUpType)
        {
            case PowerUpType.AddBall:
                BallManager.Instance.SpawnBall_random();
                break;
            case PowerUpType.DoubleBalls:
                DuplicateBalls();
                break;
            case PowerUpType.DirectionalControl:
                PowerUpManager.Instance.SpawnDirectionalControl();
                break;
            case PowerUpType.Explosive:
                PowerUpManager.Instance.SpawnExplosion();
                break;
            case PowerUpType.IncreaseSize:
                BallManager.Instance.ApplyToAllBalls(ball => ball.GetComponent<Ball>().IncreaseSize(1.5f));
                break;
            case PowerUpType.InvincibleBall:
                BallManager.Instance.ApplyToAllBalls(ball => ball.GetComponent<Ball>().MakeInvincible(effectDuration));
                break;
            case PowerUpType.IncreaseSpeed:
                BallManager.Instance.ApplyToAllBalls(ball => ball.GetComponent<Ball>().IncreaseSpeed(1.5f));
                break;
            case PowerUpType.Shield:
                BallManager.Instance.ApplyToAllBalls(ball => ball.GetComponent<Ball>().MakeShieldPowerup(effectDuration));
                break;
            case PowerUpType.slowMotion:
                PowerUpManager.Instance.SpawnSlowMotion();
                break;
            case PowerUpType.magnet:

                BlockManager.Instance.RegenerateButSpike();
                break;
            case PowerUpType.tripleScrore:
                ScoreManager.Instance.setScoreMul(3);
                break;
            case PowerUpType.DoubleScore:
                ScoreManager.Instance.setScoreMul(2);
                break;
            case PowerUpType.ExtraBounce:
                PowerUpManager.Instance.Dec_bounciness();
                break;
            case PowerUpType.SplitBallOnCollision:
                //BallManager.Instance.ApplyToAllBalls(ball => ball.GetComponent<Ball>().isSplitModeOn());
                break;
            case PowerUpType.extraTime:
                //TODO
                //
                //
                //
                //TODO
                break;

            case PowerUpType.DecreaseSize:
                BallManager.Instance.ApplyToAllBalls(ball => ball.GetComponent<Ball>().DecreaseSize(0.5f));
                break;
            case PowerUpType.DecreaseSpeed:
                BallManager.Instance.ApplyToAllBalls(ball => ball.GetComponent<Ball>().DecreaseSpeed(.5f));
                break;
            case PowerUpType.HalfBalls:
                RemoveHalfBalls();
                break;
            case PowerUpType.RandomDirection:
                BallManager.Instance.setRandomDirectionWithSameSpeed();
                break;
            case PowerUpType.DoubleGravity:
                BallManager.Instance.ApplyToAllBalls(ball => ball.GetComponent<Ball>().Add_doubleGravityPower(effectDuration));
                break;
            case PowerUpType.ReverseStack:
                PowerUpManager.Instance.ReverseStack();
                break;
            case PowerUpType.RandomizeStack:
                PowerUpManager.Instance.RandomizeStack();
                break;
            case PowerUpType.BlockRegeneration:
                BlockManager.Instance.RegenerateBlocks();
                break;
            case PowerUpType.popTop2Powers:
                PowerUpManager.Instance.PopPowers(2);
                break;
            case PowerUpType.popTop4Powers:
                PowerUpManager.Instance.PopPowers(4);
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

    //directional control

    
}
