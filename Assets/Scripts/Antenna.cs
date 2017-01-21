using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Antenna : MonoBehaviour {

    InfoPanel infoPanel;

    static int id = 0;
    private string antennaName;
    private bool turnedOn = true;
    private GameObject wave;

    [SerializeField]
    private int power = 10;


    void Start () {
        id++;
        antennaName = "#" + id.ToString();

        infoPanel = FindObjectOfType<InfoPanel>();
        wave = transform.Find("Wave").gameObject;
    }
	
    void OnMouseDown()
    {
        PopulateInfoPanel();
        ShowAntennaControlPanel();
    }

    private void ShowAntennaControlPanel()
    {
        AntennaControlPanel antennaCP = FindObjectOfType< AntennaControlPanel > ();
        antennaCP.SetSelectedAntenna(this);
    }

    private void PopulateInfoPanel()
    {
        string message = "Moc anteny: " + power + "\n";
        City[] cities = FindObjectOfType<Cities>().GetCites();

        print("---Odległość między miastami---");
        foreach (City c in cities)
        {
            float distance = Vector3.Distance(c.transform.position, transform.position);

            print(c.getName() + ": " + distance + "\n");
        }

        infoPanel.SetText(message);
    }

    internal string getName()
    {
        return antennaName;
    }

    public bool isTurnedOn()
    {
        return turnedOn;
    }

    public void turnOff()
    {
        print("Antena "+ antennaName + " turned off");
        turnedOn = false;
        wave.SetActive(false);
    }

    public void turnOn()
    {
        print("Antena " + antennaName + " turned on");
        turnedOn = true;
        wave.SetActive(true);
    }

    public void Tick()
    {
    }
}
