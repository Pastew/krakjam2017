using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    int MAX_SCORE = 5250000;
    City[] cities;
    void Start () {
        cities = FindObjectsOfType<City>();
	}
	
	void Update () {
		
	}

    public void Tick()
    {
        GetComponentInChildren<TextMesh>().text = GetTotalScore().ToString();
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
}
