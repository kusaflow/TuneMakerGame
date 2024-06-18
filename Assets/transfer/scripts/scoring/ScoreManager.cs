using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public TMPro.TMP_Text scoreText; // UI Text to display the score
    public int scorePerBlock = 10; // Score per block destroyed
    public double milestone = 100; // Score milestone to spawn a power-up
    public float milestoneDificulty = 1.2f; 


    private double score = 0;
    private double nextMilestone;

    private float scoreMultiplier = 1.0f; // Default multiplier

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

    void Start()
    {
        nextMilestone = milestone;
        UpdateScoreUI();
    }

    public void AddScore(int points)
    {
        score += Mathf.RoundToInt(points * scoreMultiplier);
        UpdateScoreUI();

        if (score >= nextMilestone)
        {
            SpawnPowerUp();
            milestone = (int)milestone * milestoneDificulty;
            nextMilestone += milestone;
        }
    }

    public void SetMultiplier(float multiplier, float duration)
    {
        StartCoroutine(ApplyMultiplier(multiplier, duration));
    }

    private IEnumerator ApplyMultiplier(float multiplier, float duration)
    {
        scoreMultiplier = multiplier;
        yield return new WaitForSeconds(duration);
        scoreMultiplier = 1.0f; // Reset to default
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = score.ToString();
        }
    }

    private void SpawnPowerUp()
    {
        SpawnPowerUp2Level.Instance.SpawnRandomPower();
    }
}
