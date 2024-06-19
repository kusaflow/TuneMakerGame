using System;
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

    public Slider milestoneSlider;


    public double score = 0;
    public double nextMilestone;

    public float scoreMultiplier = 1.0f; // Default multiplier

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
        milestoneSlider.maxValue = (long)milestone;
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

            if (milestoneSlider)
            {
                milestoneSlider.value = (long)score;
            }
        }
    }

    private void Update()
    {
        if (milestoneSlider)
        {
            milestoneSlider.maxValue = (long)Mathf.Lerp(milestoneSlider.maxValue, (float)nextMilestone, .05f);
        }
    }

    private void SpawnPowerUp()
    {
        SpawnPowerUp2Level.Instance.SpawnRandomPower();
    }

    public void setScoreMul(int v)
    {
        StartCoroutine(tempScoremul(v));
        
    }

    IEnumerator tempScoremul(int mul)
    {
        scoreMultiplier = mul;
        yield return new WaitForSeconds(7.0f);
        scoreMultiplier = 1.0f;
        
    }
}
