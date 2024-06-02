using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    private Queue<PowerUp> powerUpQueue = new Queue<PowerUp>();
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
        StartCoroutine(AddPowerUpToQueueAfterDelay(powerUp));
    }

    private IEnumerator AddPowerUpToQueueAfterDelay(PowerUp powerUp)
    {
        yield return new WaitForSeconds(powerUpDelay);
        powerUpQueue.Enqueue(powerUp);
    }

    public void UsePowerUp()
    {
        if (powerUpQueue.Count > 0)
        {
            PowerUp powerUp = powerUpQueue.Dequeue();
            powerUp.ApplyEffect();
        }
    }

    public void ReverseStack()
    {
        powerUpQueue = new Queue<PowerUp>(new Stack<PowerUp>(powerUpQueue));
    }

    public void RandomizeStack()
    {
        List<PowerUp> powerUps = new List<PowerUp>(powerUpQueue);
        powerUpQueue.Clear();
        while (powerUps.Count > 0)
        {
            int randomIndex = Random.Range(0, powerUps.Count);
            powerUpQueue.Enqueue(powerUps[randomIndex]);
            powerUps.RemoveAt(randomIndex);
        }
    }
}
