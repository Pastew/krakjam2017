using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cities : MonoBehaviour {

    City[] cities;

	void Start () {
        cities = GetCites();
	}
	
	void Update () {
		
	}

    public City[] GetCites()
    {
        return gameObject.GetComponentsInChildren<City>();
    }

    internal void TickCities()
    {
        foreach (City city in cities)
        {
            city.Tick();
        }
        foreach (City city in cities)
        {
            city.AfterTick();
        }
    }
}
