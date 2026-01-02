using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    float currentScore = 0;
    
    float survivalTime = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        survivalTime += Time.deltaTime;
    }

    public float GetScore()
    {
        return currentScore;
    }
    public float GetSurvivalTime()
    {
        return survivalTime;
    }
    public void AddScore(float score)
    {
        currentScore += score;
    }
    public float GetDidffiultyMult()
    {
        float scoreFactor = currentScore / 1000.0f;
        float timeFactor = survivalTime / 60.0f;

        return 1.0f + scoreFactor + timeFactor;
    }

}
