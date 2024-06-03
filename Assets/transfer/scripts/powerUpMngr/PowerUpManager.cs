using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    private Stack<PowerUp> powerUpStack = new Stack<PowerUp>();
    private float powerUpDelay = 3.0f; // Delay before a power-up is added to the stack

    public static PowerUpManager Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
 
    }

    public void CollectPowerUp(PowerUp powerUp)
    {
        StartCoroutine(AddPowerUpToStackAfterDelay(powerUp));
    }

    public void CollectPowerUp_instantly(PowerUp powerUp)
    {
        powerUpStack.Push(powerUp);
    }

    private IEnumerator AddPowerUpToStackAfterDelay(PowerUp powerUp)
    {
        yield return new WaitForSeconds(powerUpDelay);
        powerUpStack.Push(powerUp);
    }

    public void UsePowerUp()
    {
        if (powerUpStack.Count > 0)
        {
            PowerUp powerUp = powerUpStack.Pop();
            powerUp.ApplyEffect();
        }
    }

    public void ReverseStack()
    {
        //reverse the stack
        Stack<PowerUp> tempStack = new Stack<PowerUp>();
        while (powerUpStack.Count > 0)
        {
            tempStack.Push(powerUpStack.Pop());
        }
        powerUpStack = tempStack;

    }

    public void RandomizeStack()
    {
        List<PowerUp> powerUps = new List<PowerUp>(powerUpStack);
        powerUpStack.Clear();
        while (powerUps.Count > 0)
        {
            int randomIndex = Random.Range(0, powerUps.Count);
            powerUpStack.Push(powerUps[randomIndex]);
            powerUps.RemoveAt(randomIndex);
        }
    }

    public Stack<PowerUp> GetPowerUpStack()
    {
        return powerUpStack;
    }
}
