using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Antenna : MonoBehaviour {

    InfoPanel infoPanel;

    static int id = 0;
    private string antennaName;
    private bool turnedOn = false;
    private GameObject wave;

    [SerializeField]
    private int power = 10;


    void Start () {
        id++;
        antennaName = "#" + id.ToString();

        infoPanel = FindObjectOfType<InfoPanel>();
        wave = transform.Find("Wave").gameObject;
        turnOff();
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            print("RIGHT CLICK");
            FindObjectOfType<Hand>().selectAntenna(gameObject);
        }

    }
    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            print("LEFT CLICK");

            PopulateInfoPanel();
            ShowAntennaControlPanel();
            FindObjectOfType<Diary>().WriteToDiary("Clicked antenna: " + antennaName);
        }

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
        if(wave)
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
