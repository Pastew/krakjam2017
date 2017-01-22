using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    int MAX_SCORE = 5250000;
    City[] cities;
    public float previousMonthScore = 0;
    public float todayScore = 0;
    public GameObject winScreen, loseScreen;

    void Start () {
        cities = FindObjectsOfType<City>();
	}
	
	void Update () {
		
	}

    public void Tick()
    {
        todayScore = GetTotalScore();
        GetComponentInChildren<TextMesh>().text = todayScore.ToString();

        CheckScoreForWin();
        CheckAttentionForWin();
    }

    private void CheckScoreForWin()
    {
        if (todayScore >= 4200000)
            Win();
        if (todayScore <= -4200000)
            Lose();
    }

    private void CheckAttentionForWin()
    {
        if (FindObjectOfType<Government>().attention >= 100)
            Lose();
    }

    private void Win()
    {
        Instantiate(winScreen);
    }

    private void Lose()
    {
        Instantiate(loseScreen);
    }

    public int GetTotalScore()
    {
        float score = 0;

        foreach (City c in cities)
        {
            score += c.population / 1000f * c.mood;
        }
        return (int)score;
    }

    internal void ResetPreviousScore()
    {
        previousMonthScore = todayScore;
    }
}
