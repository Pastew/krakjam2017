using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Antenna : MonoBehaviour {

    InfoPanel infoPanel;

    static int id = 0;
    private string antennaName;

    [SerializeField]
    private int power = 10;

	void Start () {
        id++;
        antennaName = "#" + id.ToString();

        infoPanel = FindObjectOfType<InfoPanel>();		
	}
	
    void OnMouseDown()
    {
        PopulateInfoPanel();
        ShowAntennaControlPanel();
    }

    private void ShowAntennaControlPanel()
    {
        FindObjectOfType<AntennaControlPanel>().SetSelectedAntenna(this);
    }

    private void PopulateInfoPanel()
    {
        string message = "Moc anteny: " + power + "\n";
        City[] cities = FindObjectOfType<Cities>().GetCites();

        message += "---Odległość między miastami---\n";
        foreach (City c in cities)
        {
            float distance = Vector3.Distance(c.transform.position, transform.position);

            message += c.getName() + ": " + distance + "\n";
        }

        infoPanel.SetText(message);
    }

    internal void turnOff()
    {
        print("Antena "+ antennaName + " turned off");
    }

    internal void turnOn()
    {
        print("Antena " + antennaName + " turned on");
    }

    internal void Tick()
    {
    }
}
