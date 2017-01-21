using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Antenna : MonoBehaviour {

    ScreenDebug screenDebug;

    [SerializeField]
    private int power = 10;

	void Start () {
        screenDebug = FindObjectOfType<ScreenDebug>();		
	}
	
	void Update () {
		
	}

    void OnMouseDown()
    {
        string message = "Moc anteny: " + power + "\n";
        City[] cities = FindObjectOfType<Cities>().GetCites();

        message += "---Odległość między miastami---\n";
        foreach (City c in cities){
            float distance = Vector3.Distance(c.transform.position, transform.position);

            message += c.getName() + ": " + distance + "\n";
        }


        screenDebug.write(message);

    }

    internal void Tick()
    {
        print("Antenna tick" + name);
    }
}
