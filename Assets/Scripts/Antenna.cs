using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Antenna : MonoBehaviour {

    InfoPanel infoPanel;

    [SerializeField]
    private int power = 10;

	void Start () {
        infoPanel = FindObjectOfType<InfoPanel>();		
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

        infoPanel.SetText(message);
    }

    internal void Tick()
    {
    }
}
