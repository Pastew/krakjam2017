using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cities : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
		
	}

    public City[] getCities()
    {
        //City[] cities = GetComponentInChildren<City>();
        return gameObject.GetComponentsInChildren<City>();
    }
}
