using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testPoerupAdd : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // make random powerups and add to powerupmanager stack
        
        //PowerUpManager.Instance.CollectPowerUp_instantly(new PowerUp(PowerUp.PowerUpType.RandomizeStack));
        //PowerUpManager.Instance.CollectPowerUp_instantly(new PowerUp(PowerUp.PowerUpType.ReverseStack));
        //PowerUpManager.Instance.CollectPowerUp_instantly(new PowerUp(PowerUp.PowerUpType.InvincibleBall));
        //PowerUpManager.Instance.CollectPowerUp_instantly(new PowerUp(PowerUp.PowerUpType.DecreaseSize));
        //PowerUpManager.Instance.CollectPowerUp_instantly(new PowerUp(PowerUp.PowerUpType.IncreaseSize));
        //PowerUpManager.Instance.CollectPowerUp_instantly(new PowerUp(PowerUp.PowerUpType.Explosive));
        //PowerUpManager.Instance.CollectPowerUp_instantly(new PowerUp(PowerUp.PowerUpType.DirectionalControl));
        //PowerUpManager.Instance.CollectPowerUp_instantly(new PowerUp(PowerUp.PowerUpType.HalfBalls));
        //PowerUpManager.Instance.CollectPowerUp_instantly(new PowerUp(PowerUp.PowerUpType.DoubleBalls));
        //PowerUpManager.Instance.CollectPowerUp_instantly(new PowerUp(PowerUp.PowerUpType.AddBall));
        //PowerUpManager.Instance.CollectPowerUp_instantly(new PowerUp(PowerUp.PowerUpType.RandomizeStack));
        //PowerUpManager.Instance.CollectPowerUp_instantly(new PowerUp(PowerUp.PowerUpType.ReverseStack));
        PowerUpManager.Instance.CollectPowerUp_instantly(new PowerUp(PowerUp.PowerUpType.AddBall));
        PowerUpManager.Instance.CollectPowerUp_instantly(new PowerUp(PowerUp.PowerUpType.DoubleBalls));
        PowerUpManager.Instance.CollectPowerUp_instantly(new PowerUp(PowerUp.PowerUpType.DoubleBalls));

        //spawn 2 balls 
        BallManager.Instance.SpawnBall(new Vector3(0, 0, 0), new Vector2(40, 40));
        //BallManager.Instance.SpawnBall_random();

    }

    // Update is called once per frame
    void Update()
    {
        InputMngr();
        //Debug.Log("balls in scene: " + BallManager.Instance.GetActiveBalls().Count);
        
    }

    void InputMngr()
    {

        //printAllPowerups
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("Printing all powerups");
            foreach (PowerUp powerUp in PowerUpManager.Instance.GetPowerUpStack())
            {
                Debug.Log(powerUp.powerUpType);
            }
        }

        //peak above value
        if (Input.GetKeyDown(KeyCode.O))
        {
            Debug.Log("Peaking above value");
            Debug.Log(PowerUpManager.Instance.GetPowerUpStack().Peek().powerUpType);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            PowerUpManager.Instance.UsePowerUp();
        }
    }
}
